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
    public class CategoriaController : Controller
    {
        readonly APIConnection _api = new APIConnection();

        public async Task<ActionResult> Index()
        {
            List<Categoria> categorias = new List<Categoria>();

            var response = await _api.ResponseGet(_api, "api/Categoria");

            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                categorias = JsonConvert.DeserializeObject<List<Categoria>>(result);
            }

            return View(categorias);
        }

        public async Task<ActionResult> Details(Guid guidId)
        {
            Categoria categoria = new Categoria();

            string route = $"consultar/{guidId}";
            var response = await _api.ResponseGet(_api, route);

            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                categoria = JsonConvert.DeserializeObject<Categoria>(result);
            }

            return View(categoria);
        }

        public async Task<ActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(string nomeCategoria)
        {
            try
            {
                string route = $"criar/{nomeCategoria}";

                HttpResponseMessage response = await _api.ResponsePost(_api, route, nomeCategoria);

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
            EditarCategoriaRequest categoria = new EditarCategoriaRequest();

            string route = $"consultar/{guidId}";
            HttpClient client = _api.Initial();
            HttpResponseMessage response = await client.GetAsync(route);

            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                categoria = JsonConvert.DeserializeObject<EditarCategoriaRequest>(result);
            }

            return View(categoria);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(EditarCategoriaRequest editarCategoriaRequest)
        {
            try
            {
                string route = $"atualizar";
                HttpResponseMessage response = await _api.ResponsePost(_api, route, editarCategoriaRequest);

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
            DeletarCategoriaResponse categoria = new DeletarCategoriaResponse();

            string route = $"consultar/{guidId}";
            var response = await _api.ResponseGet(_api, route);

            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                categoria = JsonConvert.DeserializeObject<DeletarCategoriaResponse>(result);
            }

            return View(categoria);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(DeletarCategoriaResponse deletarCategoriaResponse)
        {
            try
            {
                string route = $"deletar";
                HttpResponseMessage response = await _api.ResponsePost(_api, route, deletarCategoriaResponse);

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
