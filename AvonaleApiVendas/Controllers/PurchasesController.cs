using AvonaleApiVendas.Data;

namespace AvonaleApiVendas.Controllers
{
    public class PurchasesController
    {
        private readonly DataContext _context;

        public PurchasesController(DataContext context)
        {
            _context = context;
        }


    }
}
