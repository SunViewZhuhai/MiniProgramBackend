using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MniProgram.Web.ViewModel
{
    public class OrderListViewModel
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public double Amount { get; set; }
        public int PrepayerId { get; set; }
        public string PrepayerName { get; set; }
        public List<OrderDetailViewModel> orderDetailViewModels { get; set; }
    }
}
