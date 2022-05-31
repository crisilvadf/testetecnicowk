using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models.Request
{
    public class CriarCategoriaRequest
    {
        [Display(Name = "Nome Categoria")]
        public string NomeCategoria { get; set; }
    }
}
