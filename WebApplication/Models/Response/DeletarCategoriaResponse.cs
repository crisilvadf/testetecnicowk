using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models.Response
{
    public class DeletarCategoriaResponse
    {
        [Display(Name = "Id Categoria")]
        public Guid IdCategoria { get; set; }

        [Display(Name = "Nome Categoria")]
        public string NomeCategoria { get; set; }
    }
}
