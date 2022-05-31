using Microsoft.EntityFrameworkCore;
using Prateleira;
using Prateleira.DTO.Response;
using Prateleira.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace prateleira.Services
{
    public class CategoriaService
    {
        private readonly Context _context;

        public CategoriaService(
            Context context)
        {
            _context = context;
        }

        public async Task<List<Categoria>> GetAll()
        {
            var dados = await _context.TbCategorias
                .Where(x => x.Situacao == 1)
                .OrderByDescending(x => x.DataCriacao)
                .ToListAsync();

            return dados;
        }

        public async Task<Categoria> CapturarPorId(Guid guidId)
        {
            var cat = new Categoria();

            var categoria = await _context.TbCategorias
                .Where(x => x.IdCategoria == guidId)
                .FirstOrDefaultAsync();

            if (categoria is not null)
            {
                cat.Id = categoria.Id;
                cat.IdCategoria = categoria.IdCategoria;
                cat.NomeCategoria = categoria.NomeCategoria;
                cat.Situacao = categoria.Situacao;
                cat.DataCriacao = categoria.DataCriacao;
             
                return cat;
            }

            return cat;
        }

        public async Task Inserir(string nomeCategoria)
        {
            var cat = new Categoria();

            var retorno = await _context.TbCategorias
                .AnyAsync(x => x.NomeCategoria.ToUpper() == nomeCategoria.ToUpper());

            if (!retorno)
            {
                Guid newId = Guid.NewGuid();

                cat.IdCategoria = newId;
                cat.NomeCategoria = nomeCategoria;
                cat.Situacao = (short)Enums.situacao.ativo;
                cat.DataCriacao = DateTime.Now;

                await _context.TbCategorias.AddAsync(cat);
                await _context.SaveChangesAsync();
            }
        }

        public async Task Atualizar(Categoria categoria)
        {
            var cat = await _context.TbCategorias
                    .FirstOrDefaultAsync(x => x.IdCategoria == categoria.IdCategoria);

            if (cat is not null)
            {
                cat.NomeCategoria = categoria.NomeCategoria;

                _context.TbCategorias.Update(cat);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Categoria> Deletar(Categoria categoria)
        {
            var cat = await _context.TbCategorias
                    .FirstOrDefaultAsync(x => x.IdCategoria == categoria.IdCategoria);

            if (cat is not null && cat.Situacao == 1)
            {
                cat.Situacao = (short)Enums.situacao.inativo;

                _context.TbCategorias.Update(cat);
                await _context.SaveChangesAsync();
            }

            return categoria;
        }
    }
}
