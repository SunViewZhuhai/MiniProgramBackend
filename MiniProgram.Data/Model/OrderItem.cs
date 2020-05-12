using System;
using System.Collections.Generic;
using System.Text;

namespace MiniProgram.Data.Model
{
    public class OrderItem
    {
        public int Id { get; set; }
        public string OrderItemName { get; set; }
        public double Price { get; set; }
        public int ConsumerId { get; set; }
        public virtual Member Consumer { get; set; }
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }
        public int CategoryId { get; set; }
        public virtual OrderItemCategory OrderItemCategory { get; set; }
        public bool IsPay { get; set; }
    }
}
