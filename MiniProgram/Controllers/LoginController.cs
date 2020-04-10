using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MniProgram.Web.ViewModel;
using Newtonsoft.Json;

namespace MniProgram.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IHttpClientFactory _factory;

        [HttpGet("Login")]
        public async Task<bool> Login(string code)
        {
            var result = await GetUserInfo(code);
            return result;
        }

        private static string _appid = "wxce47f8975be60439";
        private static string _secret = "f1a6978ae2239cb7060a862d21c091e0";

        //private static string _requestFormat =
        //    "https://api.weixin.qq.com/sns/jscode2session?appid={0}&secret={1}&js_code={2}&grant_type=authorization_code";
        private static string _requestFormat =
            "sns/jscode2session?appid={0}&secret={1}&js_code={2}&grant_type=authorization_code";

        public LoginController(IHttpClientFactory factory)
        {
            _factory = factory;
        }

        private async Task<bool> GetUserInfo(string code)
        {
            var url = string.Format(_requestFormat, _appid, _secret, code);
            var request = new HttpRequestMessage(HttpMethod.Get,
                url);
            var client = _factory.CreateClient("wx");
            var response = await client.SendAsync(request);
            var resultString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<WxLoginResponseViewModel>(resultString);
            Console.WriteLine("Session key:" + result.SessionKey + ", OpenId:" + result.OpenId);
            if (result.ErrCode == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //private bool CheckAuthorization()
        //{

        //}

        //private string GenerateAccessToken()
        //{

        //}
        
    }

}