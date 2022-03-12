using System.ComponentModel.DataAnnotations;

namespace AvonaleApiVendas.Models
{
    public class Payment
    {
        [Key]
        public int Id { get; set; }
        public decimal Price { get; set; }

        public string Status { get; set; }

        //Constructor
        public Payment(decimal price, string status)
        {
            Price = price;
            Status = status;
        }
    }
}
