using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models.Response
{
    public class DeletarProdutoResponse
    {
        [Display(Name = "Id Produto")]
        public Guid IdProduto { get; set; }

        [Display(Name = "Nome Produto")]
        public string NomeProduto { get; set; }
    }
}
