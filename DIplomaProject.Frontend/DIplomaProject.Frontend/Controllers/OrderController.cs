using DIplomaProject.Frontend.Helpers;
using DIplomaProject.Frontend.Models.Dto;
using DIplomaProject.Frontend.Models.Dto.Order;
using Microsoft.AspNetCore.Mvc;

namespace DIplomaProject.Frontend.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetOrders()
        {
            var sender = new Sender();

            var orders = await sender.GetAsync<OrderGetDto>("GetAllOrders");

            ViewBag.Orders = orders;

            return View();
        }

        public async Task<IActionResult> FindByClientId(string id)
        {
            var sender = new Sender();

            if (Guid.TryParse(id, out var guid))
            {
                var dto = new IdDto { Id = guid };
                var orders = await sender.GetAsync<OrderSearchGetDto>($"FindOrderByClientId?id={id}");
                ViewBag.FindByClientId = orders;
                return View("GetOrdersByClientId");
            }

            return View();
        }

        public async Task<IActionResult> FindById(string id)
        {
            var sender = new Sender();

            if (Guid.TryParse(id, out var guid))
            {
                var dto = new IdDto { Id = guid };
                var orders = await sender.GetAsync<OrderGetDto>($"FindOrder?id={id}");
                ViewBag.FindById = orders;
                return View();
            }


            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(OrderPostDto order)
        {
            var sender = new Sender();

            await sender.PostAsync("CreateOrder", order);

            return RedirectToAction("GetOrders");
        }

        [HttpPost]
        public async Task<ActionResult> Delete(Guid id)
        {
            var dto = new IdDto { Id = id };
            var sender = new Sender();

            await sender.DeleteAsync("DeleteOrder", dto);

            return RedirectToAction("GetOrders");
        }


        public ActionResult Update(Guid id)
        {
            ViewBag.TempId = id;
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Update(OrderPutDto dto)
        {
            var sender = new Sender();

            await sender.UpdateAsync("UpdateOrder", dto);

            return RedirectToAction("GetOrders");
        }
    }
}
