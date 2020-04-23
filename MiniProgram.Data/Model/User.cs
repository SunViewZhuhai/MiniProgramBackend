using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MiniProgram.Data.Model
{
    public class User
    {        
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Order> PrepayOrders { get; set; }
        public virtual ICollection<OrderItem> ConsumeOrderItems { get; set; }
    }
}
