using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;

namespace LI.Carrinho.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CarrinhoController : ControllerBase
    {
        /// <summary>
        /// Saúde da aplicação
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult HealthCheck()
        {
            Log.Information("O log funcionou!");

            return Ok("A aplicação está saudável!");
        } 
    }
}
