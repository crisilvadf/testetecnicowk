using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models.Request
{
    public class EditarCategoriaRequest
    {
        [Display(Name = "Id Categoria")]
        public Guid IdCategoria { get; set; }

        [Display(Name = "Nome Categoria")]
        public string NomeCategoria { get; set; }

        [Display(Name = "Data criação")]
        public DateTime? DataCriacao { get; set; }
    }
}
