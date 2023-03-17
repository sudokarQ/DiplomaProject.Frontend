using DIplomaProject.Frontend.Helpers;
using DIplomaProject.Frontend.Models.Client;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;  
using System.Text;

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
            var sender = new Sender();

            var clients = await sender.GetAsync<ClientGetDto>("GetAllClients");

            ViewBag.Clients = clients;

            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(ClientPostDto client)
        {
            var apiUrl = "https://localhost:7161/CreateClient";

            using var httpClient = new HttpClient();

            var data = JsonConvert.SerializeObject(client);

            var content = new StringContent(data, Encoding.UTF8, "application/json");
            //var response = httpClient.PostAsJsonAsync(apiUrl, content).Result.Content.ReadAsStringAsync();

            var response = await httpClient.PostAsync(apiUrl, content);


            //var response = await httpClient.PostAsJsonAsync(apiUrl, data);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("GetClients");
            }
            return View("Error");
        }
    }
}
