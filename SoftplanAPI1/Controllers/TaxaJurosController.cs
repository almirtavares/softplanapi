using Microsoft.AspNetCore.Mvc;

namespace SoftplanAPI1.Controllers 
{
    [ApiController]
    [Route("[controller]")]
    public class TaxaJurosController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "0.01";
        }
    }
}