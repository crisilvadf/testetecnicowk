using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prateleira.DTO.Response
{
    public class CategoriaResponse
    {
        public int Id { get; set; }
        public Guid IdCategoria { get; set; }
        public string NomeCategoria { get; set; }
        public int Situacao { get; set; }
    }
}
