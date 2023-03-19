﻿using DIplomaProject.Frontend.Helpers;
using DIplomaProject.Frontend.Models.Dto;
using DIplomaProject.Frontend.Models.Dto.Client;
using Microsoft.AspNetCore.Mvc;

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

        public async Task<IActionResult> GetClientsByName(string query)
        {
            var sender = new Sender();

            if (!String.IsNullOrEmpty(query))
            {
                var clients = await sender.GetAsync<ClientSearchGetDto>($"GetClientsByName?name={query}");
                ViewBag.Clients = clients;
            }

            ViewBag.Query = query;

            return View();
        }

        public async Task<IActionResult> FindById(string id)
        {
            var sender = new Sender();

            if (Guid.TryParse(id, out var guid))
            {
                var dto = new IdDto { Id = guid };            
                var clients = await sender.GetAsync<ClientGetDto>($"FindClient?id={id}");
                ViewBag.FindById = clients;
                return View();
            }


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


        public ActionResult Update(Guid id)
        {
            ViewBag.TempId = id;
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Update(ClientPutDto dto)
        {
            var sender = new Sender();

            await sender.UpdateAsync("UpdateClient", dto);

            return RedirectToAction("GetClients");
        }

    }
}
