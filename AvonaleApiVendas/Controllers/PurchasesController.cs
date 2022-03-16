using AvonaleApiVendas.Data;
using AvonaleApiVendas.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace AvonaleApiVendas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchasesController : ControllerBase
    {
        private readonly DataContext _context;

        public PurchasesController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<Purchase>> MakePurchase(Purchase purchase)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            Product product = await _context.Product.FindAsync(purchase.ProductId);

            if(product == null)
            {
                return NotFound("Produto não encontrado");
            }

            if (purchase.Buy(product) != true)
            {
                return BadRequest();
            }

            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.PostAsJsonAsync("https://localhost:7134/api/Payments", purchase);

            response.EnsureSuccessStatusCode();
            
            var responseBody = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            Payment payment = JsonConvert.DeserializeObject<Payment>(responseBody);
            

            if(payment.Status == "Aprovado")
            {
                if (product.QuantityStock == 0)
                {
                    _context.Remove(product);
                }
                else
                {
                    _context.Entry(product).State = EntityState.Modified;
                }
            }

            _context.Entry(purchase).State = EntityState.Added;

            await _context.SaveChangesAsync();

            return Ok(purchase);

        }
    }
}