using AvonaleApiVendas.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AvonaleApiVendas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        [HttpPost]
        public Payment Pay(Purchase purchase)
        {
            return (purchase.PurchasePrice <= 100) ? 
                new Payment(purchase.PurchasePrice, "Rejeitado") : 
                    new Payment(purchase.PurchasePrice, "Aprovado");
        }
    }
}
