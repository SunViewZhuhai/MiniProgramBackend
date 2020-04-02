using System;
using System.Collections.Generic;
using System.Text;

namespace MiniProgram.Data.Model
{
    public class Cost
    {
        public int Id { get; set; }
        public DateTime StatementDate { get; set; }
        public double Amount { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int CategoryId { get; set; }
        public CostCategory Category { get; set; }
    }
}
