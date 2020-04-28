using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
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
        private static string _requestFormat =
            "sns/jscode2session?appid={0}&secret={1}&js_code={2}&grant_type=authorization_code";

        public LoginController(IHttpClientFactory factory)
        {
            _factory = factory;
        }

        private async Task<bool> GetUserInfo(string code)
        {
            var url = string.Format(_requestFormat, Constants.AppId, Constants.AppSecret, code);
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            var client = _factory.CreateClient("wx");
            var response = await client.SendAsync(request);
            var resultString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<WxLoginResponseViewModel>(resultString);
            return result.ErrCode == 0;
        }

        //private bool CheckAuthorization()
        //{

        //}

        //private string GenerateAccessToken()
        //{

        //}
        
    }

}