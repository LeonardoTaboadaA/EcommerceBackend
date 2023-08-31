using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http; //http
using System.Net.Http.Json;
using System.Threading.Tasks;
using TiendaVirtual.Models;

namespace TiendaVirtual.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HttpClient _httpClient;
        
        public HomeController(ILogger<HomeController> logger, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            
            _httpClient = httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri("https://wsecommerce71298136.azurewebsites.net/");
        }

        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetAsync("api/Producto"); // Cambia la ruta según tus endpoints
            if (response.IsSuccessStatusCode)
            {
                var productos = await response.Content.ReadFromJsonAsync<List<Producto>>();
                return View(productos); // Puedes pasar la lista de productos a tu vista
            }
            else
            {
                return View(new List<Producto>());
            }   
        }
        /*
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbCurso = await _context.TbCursos.FindAsync(id);
            if (tbCurso == null)
            {
                return NotFound();
            }
            return View(tbCurso);
        }*/

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
