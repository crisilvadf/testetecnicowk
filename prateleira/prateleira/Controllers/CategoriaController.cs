using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using prateleira.Services;
using Prateleira.DTO;
using Prateleira.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace prateleira.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ILogger<CategoriaController> _logger;
        private readonly CategoriaService _categoriaService;

        public CategoriaController(
            ILogger<CategoriaController> logger,
            CategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<List<Categoria>>> GetAll()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ErrorResponse(ModelState));
            }

            try
            {
                _logger.LogError("Início da caputura de todas as categorias");
                var retorno = await _categoriaService.GetAll();
                _logger.LogError("Fim da caputura de todas as categorias");
                return retorno;
            }
            catch (ArgumentException ex)
            {
                _logger.LogError(ex, ($"Falha ao capturar as categorias. Error: {ex.Message}"));
                return BadRequest(new ErrorResponse(ex.Message));
            }
            catch (Exception ex)
            {
                _logger.LogError("500", ex.Message.ToString());
                return StatusCode(500, "Erro de serviço");
            }
        }

        [HttpGet]
        [Route("/consultar/{guidId}")]
        public async Task<ActionResult<Categoria>> GetCategoriaPorId(Guid guidId)
        {
            try
            {
                _logger.LogError("Início caputura da categoria por id");
                var retorno = await _categoriaService.CapturarPorId(guidId);
                return retorno;
            }
            catch (ArgumentException ex)
            {
                _logger.LogError(ex, ($"Falha ao capturar a categoria por id. Error: {ex.Message}"));
                return BadRequest(new ErrorResponse(ex.Message));
            }
            catch (Exception ex)
            {
                _logger.LogError("500", ex.Message.ToString());
                return StatusCode(500, "Erro de serviço");
            }
        }

        [HttpPost]
        [Route("/criar/{nomeCategoria}")]
        public async Task<object> CriarCategoria(string nomeCategoria)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ErrorResponse(ModelState));
            }

            try
            {
                _logger.LogError("Início da criação da Categoria");

                if (!string.IsNullOrEmpty(nomeCategoria))
                {
                    await _categoriaService.Inserir(nomeCategoria);
                    _logger.LogError("Fim da criação da Categoria");
                    return Ok();
                }
                else
                {
                    return NoContent();
                }
            }
            catch (ArgumentException ex)
            {
                _logger.LogError(ex, ($"Falha no processo de criação da categoria. Error: {ex.Message}"));
                return BadRequest(new ErrorResponse(ex.Message));
            }
            catch (Exception ex)
            {
                _logger.LogError("500", ex.Message.ToString());
                return StatusCode(500, "Erro de serviço");
            }
        }

        [HttpPost]
        [Route("/atualizar")]
        public async Task<object> AtualizaCategoria(Categoria categoria)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ErrorResponse(ModelState));
            }

            try
            {
                _logger.LogError("Início da atualização da categoria");

                if (categoria.IdCategoria != Guid.Empty)
                {
                    await _categoriaService.Atualizar(categoria);
                    _logger.LogError("Fim da atualização da Categoria");
                    return Ok();
                }
                else
                {
                    return NoContent();
                }
            }
            catch (ArgumentException ex)
            {
                _logger.LogError(ex, ($"Falha no processo de atualização da categoria. Error: {ex.Message}"));
                return BadRequest(new ErrorResponse(ex.Message));
            }
            catch (Exception ex)
            {
                _logger.LogError("500", ex.Message.ToString());
                return StatusCode(500, "Erro de serviço");
            }
        }

        [HttpPost]
        [Route("/deletar")]
        public async Task<object> DeletarCategoria(Categoria categoria)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ErrorResponse(ModelState));
            }

            try
            {
                _logger.LogError("Início da exclusão da Categoria");

                if (categoria.IdCategoria != Guid.Empty)
                {
                    var retorno = await _categoriaService.Deletar(categoria);
                    _logger.LogError($"Fim da exclusão da categoria");
                    return Ok(retorno);
                }
                else
                {
                    return NoContent();
                }
            }
            catch (ArgumentException ex)
            {
                _logger.LogError(ex, ($"Falha no processo de exclusão da categoria. Error: {ex.Message}"));
                return BadRequest(new ErrorResponse(ex.Message));
            }
            catch (Exception ex)
            {
                _logger.LogError("500", ex.Message.ToString());
                return StatusCode(500, "Erro de serviço");
            }
        }
    }
}
