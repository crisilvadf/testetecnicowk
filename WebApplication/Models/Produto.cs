using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication.Models
{
    public class Produto
    {
        [NotMapped]
        public int Id { get; set; }

        [Display(Name = "Id Produto")]
        public Guid IdProduto { get; set; }

        [Display(Name = "Produto")]
        public string NomeProduto { get; set; }

        [Display(Name = "Data criação")]
        public DateTime? DataCriacao { get; set; }
    }
}
