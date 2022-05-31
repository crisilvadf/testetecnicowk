using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models.Request
{
    public class EditarProdutoRequest
    {
        [Display(Name = "Id Produto")]
        public Guid IdProduto { get; set; }

        [Display(Name = "Nome Produto")]
        public string NomeProduto { get; set; }

        [Display(Name = "Data criação")]
        public DateTime? DataCriacao { get; set; }
    }
}
