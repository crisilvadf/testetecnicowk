using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models.Request
{
    public class CriarProdutoRequest
    {
        [Display(Name = "Nome Produto")]
        public string NomeProduto { get; set; }
    }
}
