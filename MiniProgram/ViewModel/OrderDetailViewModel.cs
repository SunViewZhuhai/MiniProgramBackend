using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MniProgram.Web.ViewModel
{
    public class OrderDetailViewModel
    {
        public int Id { get; set; }
        public string OrderItemName { get; set; }
        public double Price { get; set; }
        public int ConsumerId { get; set; }
        public int OrderId { get; set; }
        public int CategoryId { get; set; }
        public bool IsPay { get; set; }
    }
}
