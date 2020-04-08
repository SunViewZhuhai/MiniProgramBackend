using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniProgram.ViewModel
{
    public class CostViewModel
    {
        public int Id { get; set; }
        public double Amount { get; set; }
        public DateTime StatementDate { get; set; }
        public int UserId { get; set; }
        public int CategoryId { get; set; }
    }
}
