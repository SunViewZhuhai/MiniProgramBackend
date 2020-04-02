using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace miniprogram.ViewModel
{
    public class CostQueryViewModel
    {
        public int[] UserIds { get; set; }
        public int[] CategoryIds { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
