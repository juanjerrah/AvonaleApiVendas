using AvonaleApiVendas.Data;
using AvonaleApiVendas.Models;
using Microsoft.AspNetCore.Mvc;

namespace AvonaleApiVendas.Controllers
{
    public class PurchasesController
    {
        private readonly DataContext _context;

        public PurchasesController(DataContext context)
        {
            _context = context;
        }

        /*[HttpPost]
        public Task<ActionResult<Purchase>> MakePurchase(Purchase purchase)
        {
            (!ModelState.isValid)
        }*/
    }
}
