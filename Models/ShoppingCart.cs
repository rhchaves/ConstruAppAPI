﻿namespace ConstruAppAPI.Models
{
    public partial class ShoppingCart
    {
        public int ShoppingCartId { get; set; }
        public string UserClientId { get; set; } = null!;
        public string Payment { get; set; } = null!;
        public int ProductId { get; set; }
        public int? QtdProduct { get; set; }
        public bool? Status { get; set; }
        public DateTime UpdateStatus { get; set; }
        public DateTime CreateRegister { get; set; }
        public DateTime UpdateRegister { get; set; }
        public DateTime? DeletedRegister { get; set; }

        public virtual Product Product { get; set; } = null!;
        public virtual UserClient UserClient { get; set; } = null!;
    }
}
