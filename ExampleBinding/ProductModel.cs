namespace ExampleBinding
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal SellPrice { get; set; }

        public ProductModel(int id, string name, decimal sellPrice)
        {
            Id = id;
            Name = name;
            SellPrice = sellPrice;
        }

    }
}
