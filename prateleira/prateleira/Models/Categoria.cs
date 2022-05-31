using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Prateleira.Models
{
    public class Categoria
    {
        [NotMapped]
        public int Id { get; set; }

        [Display(Name = "Id")]
        public Guid IdCategoria { get; set; }

        [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório")]
        [Display(Name = "Categoria")]
        public string NomeCategoria { get; set; }
        
        [Display(Name = "Situacao")]
        public int Situacao { get; set; }

        [Display(Name = "Data criação")]
        public DateTime? DataCriacao { get; set; }

    }
}
