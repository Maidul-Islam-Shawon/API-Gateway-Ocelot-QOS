namespace OrderProcessing.Product.Entities
{
    public class Products
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int Quantity_In_Stock { get; set; }
        public decimal Unit_Price { get; set; }
    }
}
