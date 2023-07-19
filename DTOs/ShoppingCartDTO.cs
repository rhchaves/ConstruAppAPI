namespace ConstruAppAPI.DTOs
{
    public partial class ShoppingCartDTO
    {
        public int ShoppingCartId { get; set; }
        public string UserClientId { get; set; } = null!;
        public string Payment { get; set; } = null!;
        public int ProductId { get; set; }
        public int? QtdProduct { get; set; }
        public bool? Status { get; set; }
    }
}
