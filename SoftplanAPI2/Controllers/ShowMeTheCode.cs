using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace SoftplanAPI2.Controllers 
{
    [ApiController]
    [Route("[controller]")]
    public class ShowMeTheCode : ControllerBase
    {
        static HttpClient client = new HttpClient();

        [HttpGet]
        public string Get()
        {
            return "https://github.com/almirtavares/softplanapi/";
        }
    }
}