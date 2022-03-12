using AvonaleApiVendas.Data;
using AvonaleApiVendas.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AvonaleApiVendas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly DataContext _context;

        public ProductsController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<Product>> InsertProduct(Product product)
        {
            _context.Product.Add(product);
            await _context.SaveChangesAsync();

            return Ok(await _context.Product.ToListAsync());

        }
    }
}
