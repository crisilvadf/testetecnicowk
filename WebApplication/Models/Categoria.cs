using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication.Models
{
    public class Categoria
    {
        [NotMapped]
        public int Id { get; set; }

        [Display(Name = "IdCategoria")]
        public Guid IdCategoria { get; set; }

        [Display(Name = "Categoria")]
        public string NomeCategoria { get; set; }

        [Display(Name = "Data criação")]
        public DateTime? DataCriacao { get; set; }
    }
}
