namespace Ecommerce.Models
{
    public class ProductOrder
    {

        public long ProductId { get; set; }
        public int OrderId { get; set; }

        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }

    }
}
