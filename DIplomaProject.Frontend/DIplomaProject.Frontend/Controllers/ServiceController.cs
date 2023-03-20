using DIplomaProject.Frontend.Helpers;
using DIplomaProject.Frontend.Models.Dto;
using DIplomaProject.Frontend.Models.Dto.Service;
using DIplomaProject.Frontend.Models.Dto.Service;
using Microsoft.AspNetCore.Mvc;

namespace DIplomaProject.Frontend.Controllers
{
    public class ServiceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetServices()
        {
            var sender = new Sender();

            var services = await sender.GetAsync<ServiceGetDto>("GetAllServices");

            ViewBag.Services = services;

            return View();
        }

        public async Task<IActionResult> GetServicesByName(string query)
        {
            var sender = new Sender();

            if (!String.IsNullOrEmpty(query))
            {
                var services = await sender.GetAsync<ServiceSearchGetDto>($"GetServicesByName?name={query}");
                ViewBag.Services = services;
            }

            ViewBag.Query = query;

            return View();
        }

        public async Task<IActionResult> FindByShopId(string id)
        {
            var sender = new Sender();

            if (Guid.TryParse(id, out var guid))
            {
                var dto = new IdDto { Id = guid };

                var services = await sender.GetAsync<ServiceSearchGetDto>($"GetServicesByShop?id={id}");

                ViewBag.FindByShopId = services;

                return View("GetServicesByShopId");
            }

            return View();
        }

        public async Task<IActionResult> FindById(string id)
        {
            var sender = new Sender();

            if (Guid.TryParse(id, out var guid))
            {
                var dto = new IdDto { Id = guid };

                var services = await sender.GetAsync<ServiceGetDto>($"FindService?id={id}");

                ViewBag.FindById = services;

                return View();
            }


            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(ServicePostDto service)
        {
            var sender = new Sender();

            await sender.PostAsync("CreateService", service);

            return RedirectToAction("GetServices");
        }

        [HttpPost]
        public async Task<ActionResult> Delete(Guid id)
        {
            var dto = new IdDto { Id = id };
            var sender = new Sender();

            await sender.DeleteAsync("DeleteService", dto);

            return RedirectToAction("GetServices");
        }


        public ActionResult Update(Guid id)
        {
            ViewBag.TempId = id;
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Update(ServicePutDto dto)
        {
            var sender = new Sender();

            await sender.UpdateAsync("UpdateService", dto);

            return RedirectToAction("GetServices");
        }
    }
}
