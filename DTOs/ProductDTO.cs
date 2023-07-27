namespace ConstruAppAPI.DTOs
{
    public partial class ProductDTO
    {
        public ProductDTO()
        { }

        public int ProductId { get; set; }
        public string Name { get; set; } = null!;
        public string Label { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string ProductMark { get; set; } = null!;
        public decimal Price { get; set; }
        public string? ImageUri { get; set; }
        public int StockQtd { get; set; }
        public int SoldQtd { get; set; }
        public int? Status { get; set; }
        public int CategoryId { get; set; }
    }
}
