namespace ConstruAppAPI.DTOs
{
    public partial class PurchaseOrderDTO
    {
        public PurchaseOrderDTO()
        { }

        public int PurchaseOrderId { get; set; }
        public string UserClientId { get; set; }
        public string UserSellerId { get; set; }
        public decimal TotalPrice { get; set; }
        public bool? Status { get; set; }
    }
}
