using System;
using System.Collections.Generic;

namespace ConstruAppAPI.DTOs
{
    public partial class CategoryDTO
    {
        public CategoryDTO()
        { }

        public int CategoryId { get; set; }
        public string Name { get; set; } = null!;
        public string Label { get; set; } = null!;
        public string? ImageUri { get; set; }
        public int? Status { get; set; }
    }
}
