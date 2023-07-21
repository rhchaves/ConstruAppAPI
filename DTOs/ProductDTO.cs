namespace ConstruAppAPI.DTOs
{
    public partial class ProductDTO
    {
        public ProductDTO()
        { }

        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Label { get; set; }
        public string Description { get; set; }
        public string ProductMark { get; set; }
        public decimal Price { get; set; }
        public string? ImageUri { get; set; }
        public int StockQtd { get; set; }
        public int SoldQtd { get; set; }
        public bool? Status { get; set; }
        public int CategoryId { get; set; }
    }
}
