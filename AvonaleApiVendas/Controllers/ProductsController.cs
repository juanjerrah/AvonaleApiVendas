using AvonaleApiVendas.Data;
using AvonaleApiVendas.Models;
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

        [HttpGet]
        public async Task<ActionResult<List<Product>>> AllProducts()
        {
            try
            {
               return Ok(await _context.Product.ToListAsync());
            }catch{
                return BadRequest();
            }

        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Product>> ProductById(int id)
        {
            var product = await _context.Product.FindAsync(id);
            if(product == null)
            {
                return BadRequest("Produto não encontrado!");
            }
            return Ok(product);
            
        }

        [HttpPost]
        public async Task<ActionResult<List<Product>>> InsertProduct(Product product)
        {
            _context.Product.Add(product);
            await _context.SaveChangesAsync();

            return Ok(await _context.Product.ToListAsync());

        }

        [HttpPut]
        public async Task<ActionResult<List<Product>>> UpdateProduct(Product product)
        {
            var products = await _context.Product.FindAsync(product.Id);
            if(products == null)
            {
                return BadRequest("Produto não encontrado!");
            }

            products.ProductName = product.ProductName;
            products.ProductPrice = product.ProductPrice;
            products.QuantityStock = product.QuantityStock;
            products.LastSalePrice = product.LastSalePrice;
            products.LastSaleTime = DateTime.Now;

            await _context.SaveChangesAsync();

            return Ok(await _context.Product.ToListAsync());
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<List<Product>>> DeleteProduct(int id)
        {
            var product = await _context.Product.FindAsync(id);
            if(product == null)
            {
                return BadRequest("Produto não encontrado!");
            }

            _context.Product.Remove(product);
            await _context.SaveChangesAsync();

            return Ok(await _context.Product.ToListAsync());

        }
    }
}
