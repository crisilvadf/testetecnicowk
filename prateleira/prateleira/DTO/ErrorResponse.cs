using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prateleira.DTO
{
    public class ErrorResponse
    {
        public ErrorResponse(string mensagemErro)
        {
            Erros = new HashSet<string>
            {
                mensagemErro
            };
        }

        public ErrorResponse(ModelStateDictionary modelState)
        {
            Erros = new HashSet<string>();

            var erros = modelState.Values.SelectMany(e => e.Errors);
            foreach (var erro in erros)
            {
                var errorMsg = erro.Exception == null ? erro.ErrorMessage : erro.Exception.Message;
                Erros.Add(errorMsg);
            }
        }

        public ICollection<string> Erros { get; set; }
    }
}
