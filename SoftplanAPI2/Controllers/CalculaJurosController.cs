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
    public class CalculaJurosController : ControllerBase
    {
        static HttpClient client = new HttpClient();

        [HttpGet]
        public async Task<string> Get(float valorinicial, int meses)
        {
            var taxaJuros = await getTaxaJurosFromAPI1();

            var parcial = valorinicial * Math.Pow((1 + float.Parse(taxaJuros) ), meses);
            return string.Format("{0:0.00}", parcial);
        }

        public static async Task<string> getTaxaJurosFromAPI1()
        {
            HttpResponseMessage response = new HttpResponseMessage();
            var taxaJuros = "0.01";

            try {
                if (client.BaseAddress == null)
                {              
                    client.BaseAddress = new Uri("http://localhost:8080/");
                }
                response = await client.GetAsync("taxajuros");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
                else {              
                    Console.WriteLine("Erro no StatusCode do Get Taxa de Juros!");
                }
            }
            catch (Exception exep)
            {
                Console.WriteLine("ErrorHttp: "+exep);
            }         

            return taxaJuros;
        }

        /*[HttpGet]
        public async Task<string> Get(float valorinicial, int meses)
        {
            

            HttpResponseMessage response = new HttpResponseMessage();

            try {
                if (client.BaseAddress == null)
                {              
                    client.BaseAddress = new Uri("http://localhost:8080/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                }               
            }
            catch (Exception exep)
            {
                Console.WriteLine("ErrorHttp: "+exep);
                return "ErrorHttpClient.BaseAddress | " + exep;
            }

            try {
                response = await client.GetAsync("taxajuros");
            }
            catch (Exception exep2) {

                Console.WriteLine("ErrorGetAsync: "+ exep2);
                return "ErrorGetAsync 777 77 | " + exep2 + " | " + response;
            }
            
            var taxaJuros = "";
            try {                
                if (response.IsSuccessStatusCode)
                {
                    taxaJuros = await response.Content.ReadAsStringAsync();
                }
                else {
                    Console.WriteLine("ErroStatusCode: "+ response.IsSuccessStatusCode);
                    return "ErrorReadAsStringAsync 777 | " + response.IsSuccessStatusCode + "|" + response;
                }
            }
            catch (Exception exep3) {

                Console.WriteLine("ErrorReadAsStringAsync: "+ exep3);
                return "ErrorReadAsStringAsync | " + exep3;
            }

            if (taxaJuros == "") {
                taxaJuros = "500000000000000";
            }

            Console.WriteLine(taxaJuros);

            var parcial = valorinicial * Math.Pow((1 + float.Parse(taxaJuros) ), meses);
            return string.Format("{0:0.00}", parcial);
        }*/

        /*public async Task<string> Get(float valorinicial, int meses)
        {
            string taxaJuros = await getTaxaJurosFromAPI1();

            if (taxaJuros == "") {
                taxaJuros = "500000000000000";
            }

            Console.WriteLine(taxaJuros);

            var parcial = valorinicial * Math.Pow((1 + float.Parse(taxaJuros) ), meses);
            return string.Format("{0:0.00}", parcial);
        }

        public static async Task<string> getTaxaJurosFromAPI1()
        {
            string taxaJuros = "";
            HttpResponseMessage response = new HttpResponseMessage();

            try {
                if (client.BaseAddress == null)
                {              
                    client.BaseAddress = new Uri("http://localhost:8080/");
                }
                response = await client.GetAsync("taxajuros");
            }
            catch (Exception exep)
            {
                Console.WriteLine("ErrorHttp: "+exep);
            }

            if (response.IsSuccessStatusCode)
            {
                return taxaJuros = await response.Content.ReadAsStringAsync();
            }

            switch (response.StatusCode)
            {
                case HttpStatusCode.BadRequest:
                    throw new ArgumentException(taxaJuros);

                default:
                    throw new Exception(taxaJuros);
            }
        }*/

        /*
        public async Task<string> Get(float valorinicial, int meses)
        {
            Task<string> taxaJurosReturn = getTaxaJurosFromAPI1();

            string taxaJuros = await taxaJurosReturn;

            if (taxaJuros == "") {
                taxaJuros = "500000000000000";
            }

            Console.WriteLine(taxaJuros);

            var parcial = valorinicial * Math.Pow((1 + float.Parse(taxaJuros) ), meses);
            return string.Format("{0:0.00}", parcial);
        }

        public static async Task<string> getTaxaJurosFromAPI1()
        {
            string taxaJuros = "";
            HttpResponseMessage response = new HttpResponseMessage();

            try {
                if (client.BaseAddress == null)
                {              
                    client.BaseAddress = new Uri("http://localhost:8080/");
                }
                response = await client.GetAsync("taxajuros");
            }
            catch (Exception exep)
            {
                Console.WriteLine("ErrorHttp: "+exep);
            }

            if (response.IsSuccessStatusCode)
            {
                return taxaJuros = response.Content.ReadAsStringAsync().Result;
            }

            switch (response.StatusCode)
                {
                    case HttpStatusCode.BadRequest:
                        throw new ArgumentException(taxaJuros);

                    default:
                        throw new Exception(taxaJuros);
                }
        }
        */

    }
}