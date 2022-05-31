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
    public class ProdutoController : ControllerBase
    {
        private readonly ILogger<ProdutoController> _logger;
        private readonly ProdutoService _produtoService;

        public ProdutoController(
            ILogger<ProdutoController> logger,
            ProdutoService produtoService)
        {
            _logger = logger;
            _produtoService = produtoService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Produto>>> GetAll()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ErrorResponse(ModelState));
            }

            try
            {
                _logger.LogError("Início da caputura de todos os produtos");
                var retorno = await _produtoService.GetAll();
                _logger.LogError("Fim da caputura de todas os produtos");
                return retorno;
            }
            catch (ArgumentException ex)
            {
                _logger.LogError(ex, ($"Falha ao capturar os produtos. Error: {ex.Message}"));
                return BadRequest(new ErrorResponse(ex.Message));
            }
            catch (Exception ex)
            {
                _logger.LogError("500", ex.Message.ToString());
                return StatusCode(500, "Erro de serviço");
            }
        }

        [HttpGet]
        [Route("/consultar-prod/{guidId}")]
        public async Task<ActionResult<Produto>> GetProdutoPorId(Guid guidId)
        {
            try
            {
                _logger.LogError("Início caputura do produto por id");
                var retorno = await _produtoService.CapturarPorId(guidId);
                return retorno;
            }
            catch (ArgumentException ex)
            {
                _logger.LogError(ex, ($"Falha ao capturar o produto por id. Error: {ex.Message}"));
                return BadRequest(new ErrorResponse(ex.Message));
            }
            catch (Exception ex)
            {
                _logger.LogError("500", ex.Message.ToString());
                return StatusCode(500, "Erro de serviço");
            }
        }

        [HttpPost]
        [Route("/criar-prod/{nomeProduto}")]
        public async Task<object> CriarProduto(string nomeProduto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ErrorResponse(ModelState));
            }

            try
            {
                _logger.LogError("Início da criação do produto");

                if (!string.IsNullOrEmpty(nomeProduto))
                {
                    await _produtoService.Inserir(nomeProduto);
                    _logger.LogError("Fim da criação do produto");
                    return Ok();
                }
                else
                {
                    return NoContent();
                }
            }
            catch (ArgumentException ex)
            {
                _logger.LogError(ex, ($"Falha no processo de criação do produto. Error: {ex.Message}"));
                return BadRequest(new ErrorResponse(ex.Message));
            }
            catch (Exception ex)
            {
                _logger.LogError("500", ex.Message.ToString());
                return StatusCode(500, "Erro de serviço");
            }
        }

        [HttpPost]
        [Route("/atualizar-prod")]
        public async Task<object> AtualizaProduto(Produto produto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ErrorResponse(ModelState));
            }

            try
            {
                _logger.LogError("Início da atualização do produto");

                if (produto.IdProduto != Guid.Empty)
                {
                    await _produtoService.Atualizar(produto);
                    _logger.LogError("Fim da atualização do produto");
                    return Ok();
                }
                else
                {
                    return NoContent();
                }
            }
            catch (ArgumentException ex)
            {
                _logger.LogError(ex, ($"Falha no processo de atualização do produto. Error: {ex.Message}"));
                return BadRequest(new ErrorResponse(ex.Message));
            }
            catch (Exception ex)
            {
                _logger.LogError("500", ex.Message.ToString());
                return StatusCode(500, "Erro de serviço");
            }
        }

        [HttpPost]
        [Route("/deletar-prod")]
        public async Task<object> DeletarProduto(Produto produto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ErrorResponse(ModelState));
            }

            try
            {
                _logger.LogError("Início da exclusão da produto");

                if (produto.IdProduto != Guid.Empty)
                {
                    var retorno = await _produtoService.Deletar(produto);
                    _logger.LogError($"Fim da exclusão do produto");
                    return Ok(retorno);
                }
                else
                {
                    return NoContent();
                }
            }
            catch (ArgumentException ex)
            {
                _logger.LogError(ex, ($"Falha no processo de exclusão do produto. Error: {ex.Message}"));
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
