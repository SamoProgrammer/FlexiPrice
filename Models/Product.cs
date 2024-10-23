namespace FlexiPrice.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal BasePrice { get; set; }
        public int StockLevel { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}
