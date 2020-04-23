using System;
using System.Collections.Generic;
using System.Text;

namespace MiniProgram.Data.Model
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public double Amount { get; set; }
        public int PrepayerId { get; set; }
        public User Prepayer { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
