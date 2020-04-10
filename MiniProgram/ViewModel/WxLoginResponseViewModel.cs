using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MniProgram.Web.ViewModel
{
    public class WxLoginResponseViewModel
    {
        public string SessionKey { get; set; }
        public string OpenId { get; set; }
        public string UnionId { get; set; }
        public int ErrCode { get; set; }
        public string ErrMsg { get; set; }
    }
}
