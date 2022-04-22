﻿using LI.Carrinho.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Collections.Generic;
using System.Linq;

namespace LI.Carrinho.API.Filters
{
    public class ValidateModelAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                List<CodigoMensagemErro> erros = new List<CodigoMensagemErro>();
                int indexError = 0;
                foreach (var source in context.ModelState.Where(e => e.Value.Errors.Count > 0))
                {
                    erros.AddRange(source.Value.Errors.Select((e, index) =>
                    {
                        indexError++;
                        return new CodigoMensagemErro()
                        {
                            CdErro = indexError,
                            DsErro = e.ErrorMessage,
                            Info = source.Key
                        };
                    }));
                }

                var retorno = new RetornoExcecao()
                {
                    Mensagem = "Verifique os dados passados.",
                    Erros = erros
                };

                context.Result = new JsonResult(retorno)
                {
                    StatusCode = 400
                };
            }
        }
    }
}
