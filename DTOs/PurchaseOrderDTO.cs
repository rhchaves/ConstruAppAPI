namespace ConstruAppAPI.DTOs
{
    public partial class PurchaseOrderDTO
    {
        public PurchaseOrderDTO()
        { }

        public int PurchaseOrderId { get; set; }
        public string UserClientId { get; set; } = null!;
        public string UserSellerId { get; set; } = null!;
        public decimal TotalPrice { get; set; }
        public int? Status { get; set; }
    }
}
