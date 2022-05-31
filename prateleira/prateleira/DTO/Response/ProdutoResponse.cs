using System;

namespace Prateleira.DTO.Response
{
    public class ProdutoResponse
    {
        public int Id { get; set; }
        public Guid IdProduto { get; set; }
        public string NomeProduto { get; set; }
        public int Situacao { get; set; }
    }
}
