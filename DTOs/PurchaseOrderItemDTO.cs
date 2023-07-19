namespace ConstruAppAPI.DTOs
{
    public partial class PurchaseOrderItemDTO
    {
        public int PurchaseOrderItemId { get; set; }
        public int? PurchaseOrderId { get; set; }
        public int? ProductId { get; set; }
        public decimal ProductPrice { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
        public bool? Status { get; set; }
    }
}
