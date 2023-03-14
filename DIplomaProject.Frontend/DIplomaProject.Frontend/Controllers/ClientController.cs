using DIplomaProject.Frontend.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DIplomaProject.Frontend.Controllers
{
    public class ClientController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetClients()
        {
            var apiUrl = "https://localhost:7161/GetAllClients";
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(apiUrl);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var clients = JsonConvert.DeserializeObject<List<ClientGetDto>>(content);
                    ViewBag.Clients = clients;
                    return View();
                }
                else
                {
                    return View("Error");
                }
            }
        }
    }
}
