using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ServiceSystem2.Models;
using ServiceSystem2.Models.Enum;
using System.Net.Http.Json;

namespace ServiceSystem2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpClientFactory _httpClientFactory;

        public HomeController(ILogger<HomeController> logger, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Produtos()
        {
            return View();
        }

        public IActionResult Pedidos()
        {
            return View();
        }

        public async Task<ActionResult> GetProducts(string type)
        {
            try
            {
                var httpClient = _httpClientFactory.CreateClient();
                var response = await httpClient.GetAsync("https://localhost:5001/v1/MenuItems/getMenuItems");

                if (response.IsSuccessStatusCode)
                {
                    var menuItems = await response.Content.ReadFromJsonAsync<List<MenuItem>>();
                    List<MenuItemViewModel> produtos = null;

                    if (type == "food")
                    {
                        produtos = menuItems
                            .Where(item => item.OrderItemType == OrderItemType.Food)
                            .Select(item => new MenuItemViewModel
                            {
                                Name = item.Name,
                                Price = item.Price
                            })
                            .ToList();
                    }
                    else if (type == "drink")
                    {
                        produtos = menuItems
                            .Where(item => item.OrderItemType == OrderItemType.Drink)
                            .Select(item => new MenuItemViewModel
                            {
                                Name = item.Name,
                                Price = item.Price
                            })
                            .ToList();
                    }

                    return Json(produtos);
                }
                else
                {
                    return RedirectToAction("Error", "Home");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Erro ao buscar itens de {type}");
                return RedirectToAction("Error", "Home");
            }
        }

        public async Task<IActionResult> InsertMenuItem(MenuItemViewModel menuItemViewModel)
        {
            try
            {
                var httpClient = _httpClientFactory.CreateClient();
                var response = await httpClient.PostAsJsonAsync("https://localhost:5001/v1/MenuItems/insertMenuItem", menuItemViewModel);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return RedirectToAction("Error", "Home");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao inserir item de menu");
                return RedirectToAction("Error", "Home");
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
