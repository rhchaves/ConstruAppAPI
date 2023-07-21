using System;
using System.Collections.Generic;

namespace ConstruAppAPI.DTOs
{
    public partial class CategoryDTO
    {
        public CategoryDTO()
        { }

        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Label { get; set; }
        public string? ImageUri { get; set; }
        public bool? Status { get; set; }
    }
}
