using System.ComponentModel.DataAnnotations;

namespace AvonaleApiVendas.Models
{
    public class Purchase
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]

        public int ProductId { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]

        public CreditCard CreditCard { get; set; }

        public decimal PurchasePrice { get; set; }

        [MinLength(1, ErrorMessage = "Precisa comprar no mínimo 1 unidade!")]

        public int QuatityPurchased { get; set; }

        public bool Buy(Product product)
        {

            if (QuatityPurchased <= product.QuantityStock)
            {
                //Preço de compra
                PurchasePrice = QuatityPurchased * product.ProductPrice;
                //Remove qtd do estoque
                product.QuantityStock -= QuatityPurchased;
                //Define a Horae data da ultima venda
                product.LastSaleTime = System.DateTime.Now;
                //Define o valor atual como o da ultima venda
                product.LastSalePrice = PurchasePrice;

                return true;

            }
            else
            {
                return false;
            }

        }
    }
}