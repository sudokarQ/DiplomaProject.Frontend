using DIplomaProject.Frontend.Helpers;
using DIplomaProject.Frontend.Models;
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
            var sender = new Sender();

            await sender.PostAsync("CreateClient", client);

            return RedirectToAction("GetClients");
        }

        [HttpPost]
        public async Task<ActionResult> Delete(Guid id)
        {
            var dto = new IdDto { Id = id };
            var sender = new Sender();

            await sender.DeleteAsync("DeleteClient", dto);

            return RedirectToAction("GetClients");
        }
    }
}
