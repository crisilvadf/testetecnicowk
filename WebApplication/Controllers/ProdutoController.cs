using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Prateleira.DTO;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using WebApplication.Configuration;
using WebApplication.Models;
using WebApplication.Models.Request;
using WebApplication.Models.Response;

namespace WebApplication.Controllers
{
    public class ProdutoController : Controller
    {
        readonly APIConnection _api = new APIConnection();

        public async Task<ActionResult> Index()
        {
            List<Produto> produtos = new List<Produto>();

            var response = await _api.ResponseGet(_api, "api/Produto");

            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                produtos = JsonConvert.DeserializeObject<List<Produto>>(result);
            }

            return View(produtos);
        }

        public async Task<ActionResult> Details(Guid guidId)
        {
            Produto produto = new Produto();

            string route = $"consultar-prod/{guidId}";
            var response = await _api.ResponseGet(_api, route);

            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                produto = JsonConvert.DeserializeObject<Produto>(result);
            }
            else
            {
                BadRequest(response.RequestMessage);
            }

            return View(produto);
        }

        public async Task<ActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(string nomeProduto)
        {
            try
            {
                string route = $"criar-prod/{nomeProduto}";

                HttpResponseMessage response = await _api.ResponsePost(_api, route, nomeProduto);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new ErrorResponse(ex.Message));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro de serviço: {ex.Message}");
            }
        }

        public async Task<ActionResult> Edit(Guid guidId)
        {
            EditarProdutoRequest produto = new EditarProdutoRequest();

            string route = $"consultar-prod/{guidId}";
            HttpClient client = _api.Initial();
            HttpResponseMessage response = await client.GetAsync(route);

            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                produto = JsonConvert.DeserializeObject<EditarProdutoRequest>(result);
            }

            return View(produto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(EditarProdutoRequest editarProdutoRequest)
        {
            try
            {
                string route = $"atualizar-prod";
                HttpResponseMessage response = await _api.ResponsePost(_api, route, editarProdutoRequest);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new ErrorResponse(ex.Message));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro de serviço: {ex.Message}");
            }
        }

        public async Task<ActionResult> Delete(Guid guidId)
        {
            DeletarProdutoResponse produto = new DeletarProdutoResponse();

            string route = $"consultar-prod/{guidId}";
            var response = await _api.ResponseGet(_api, route);

            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                produto = JsonConvert.DeserializeObject<DeletarProdutoResponse>(result);
            }

            return View(produto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(DeletarProdutoResponse deletarProdutoResponse)
        {
            try
            {
                string route = $"deletar-prod";
                HttpResponseMessage response = await _api.ResponsePost(_api, route, deletarProdutoResponse);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new ErrorResponse(ex.Message));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro de serviço: {ex.Message}");
            }
        }
    }
}
