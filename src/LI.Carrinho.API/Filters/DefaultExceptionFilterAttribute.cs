using LI.Carrinho.Application.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Serilog;
using System.Net;

namespace LI.Carrinho.API.Filters
{
    public class DefaultExceptionFilterAttribute : ExceptionFilterAttribute
    {
        private const string DEFAULT_EXCEPTION = "Ocorreu um erro inesperado.";

        public override void OnException(ExceptionContext context)
        {
            Log.Error(context.Exception, context.Exception.Message);

            context.Result = new ObjectResult(new ErrorModel(DEFAULT_EXCEPTION))
            {
                StatusCode = HttpStatusCode.InternalServerError.GetHashCode()
            };
        }
    }
}
