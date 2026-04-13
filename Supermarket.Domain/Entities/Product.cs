using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
        public string? Description { get; set; }

        public bool IsActive { get; set; } = true;

        // Category (1:N)
        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;

        // Tags (M:N)
        public ICollection<Tag> Tags { get; set; } = new List<Tag>();

        // Batches (1:N)
        public ICollection<ProductBatch> Batches { get; set; } = new List<ProductBatch>();
    }
}
