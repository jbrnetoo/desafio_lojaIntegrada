using Microsoft.AspNetCore.Mvc;

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
        public ActionResult HealthCheck() => Ok("A aplicação está saudável!");
    }
}
