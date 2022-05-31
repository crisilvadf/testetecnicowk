using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Prateleira.Models
{
    public class Produto
    {

        [NotMapped]
        public Guid IdProduto { get; set; }

        [Display(Name = "Id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório")]
        [Display(Name = "Produto")]
        public string NomeProduto { get; set; }

        [Display(Name = "Situação")]
        public int Situacao { get; set; }

        [Display(Name = "Data criação")]
        public DateTime? DataCriacao { get; set; }

    }
}
