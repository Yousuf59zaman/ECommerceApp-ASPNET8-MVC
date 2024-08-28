namespace ECommerceApp.ViewModels
{
    public class ProductViewModel
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDesc { get; set; }
        public int ProductUnitPrice { get; set; }
        public string ProductImage { get; set; }  // Path to the image file
        public string CategoryName { get; set; }
        public int Quantity { get; set; } = 1;  // Default quantity is 1
    }
}
