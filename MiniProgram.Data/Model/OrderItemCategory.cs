using System;
using System.Collections.Generic;
using System.Text;

namespace MiniProgram.Data.Model
{
    public class OrderItemCategory
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
