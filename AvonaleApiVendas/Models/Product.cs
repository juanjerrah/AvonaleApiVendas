using System.ComponentModel.DataAnnotations;

namespace AvonaleApiVendas.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        public decimal ProductPrice { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [MinLength(1, ErrorMessage = "Precisa de pelo menos 1 produto em estoque!")]
        public int QuantityStock { get; set; }

        public DateTime LastSaleTime { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        public decimal LastSalePrice { get; set; }
    }
}
