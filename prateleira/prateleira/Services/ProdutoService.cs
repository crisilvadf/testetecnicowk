using Microsoft.EntityFrameworkCore;
using Prateleira;
using Prateleira.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace prateleira.Services
{
    public class ProdutoService
    {
        private readonly Context _context;

        public ProdutoService(
            Context context)
        {
            _context = context;
        }

        public async Task<List<Produto>> GetAll()
        {
            var dados = await _context.TbProdutos
                .Where(x => x.Situacao == 1)
                .OrderByDescending(x => x.DataCriacao)
                .ToListAsync();

            return dados;
        }

        public async Task<Produto> CapturarPorId(Guid guidId)
        {
            var prod = new Produto();

            var produto = await _context.TbProdutos
                .Where(x => x.IdProduto == guidId)
                .FirstOrDefaultAsync();

            if (produto is not null)
            {
                prod.Id = produto.Id;
                prod.IdProduto = produto.IdProduto;
                prod.NomeProduto = produto.NomeProduto;
                prod.Situacao = produto.Situacao;
                prod.DataCriacao = produto.DataCriacao;

                return prod;
            }

            return prod;
        }

        public async Task Inserir(string nomeProduto)
        {
            var prod = new Produto();

            var retorno = await _context.TbProdutos
                .AnyAsync(x => x.NomeProduto.ToUpper() == nomeProduto.ToUpper());

            if (!retorno)
            {
                Guid newId = Guid.NewGuid();

                prod.IdProduto = newId;
                prod.NomeProduto = nomeProduto;
                prod.Situacao = (short)Enums.situacao.ativo;
                prod.DataCriacao = DateTime.Now;

                await _context.TbProdutos.AddAsync(prod);
                await _context.SaveChangesAsync();
            }
        }

        public async Task Atualizar(Produto produto)
        {
            var prod = await _context.TbProdutos
                    .FirstOrDefaultAsync(x => x.IdProduto == produto.IdProduto);

            if (prod is not null)
            {
                prod.NomeProduto = produto.NomeProduto;

                _context.TbProdutos.Update(prod);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Produto> Deletar(Produto produto)
        {
            var prod = await _context.TbProdutos
                    .FirstOrDefaultAsync(x => x.IdProduto == produto.IdProduto);

            if (prod is not null && prod.Situacao == 1)
            {
                prod.Situacao = (short)Enums.situacao.inativo;

                _context.TbProdutos.Update(prod);
                await _context.SaveChangesAsync();
            }

            return prod;
        }
    }
}
