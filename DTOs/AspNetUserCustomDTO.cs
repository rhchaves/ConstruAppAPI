﻿namespace ConstruAppAPI.DTOs
{
    public class AspNetUserCustomDTO
    {
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string Password { get; set; } = null!;
        public string? PhoneNumber { get; set; }
        public int? Status { get; set; }

    }
}