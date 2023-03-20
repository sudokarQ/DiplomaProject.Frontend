using DIplomaProject.Frontend.Helpers;
using DIplomaProject.Frontend.Models.Dto;
using DIplomaProject.Frontend.Models.Dto.Shop;
using Microsoft.AspNetCore.Mvc;

namespace DIplomaProject.Frontend.Controllers
{
    public class ShopController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetShops()
        {
            var sender = new Sender();

            var shops = await sender.GetAsync<ShopGetDto>("GetAllShops");

            ViewBag.Shops = shops;

            return View();
        }

        public async Task<IActionResult> GetShopsByName(string query)
        {
            var sender = new Sender();

            if (!String.IsNullOrEmpty(query))
            {
                var shops = await sender.GetAsync<ShopSearchGetDto>($"GetShopsByName?name={query}");
                ViewBag.Shops = shops;
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
                var shops = await sender.GetAsync<ShopGetDto>($"FindShop?id={id}");
                ViewBag.FindById = shops;
                return View();
            }


            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(ShopPostDto shop)
        {
            var sender = new Sender();

            await sender.PostAsync("CreateShop", shop);

            return RedirectToAction("GetShops");
        }

        [HttpPost]
        public async Task<ActionResult> Delete(Guid id)
        {
            var dto = new IdDto { Id = id };
            var sender = new Sender();

            await sender.DeleteAsync("DeleteShop", dto);

            return RedirectToAction("GetShops");
        }


        public ActionResult Update(Guid id)
        {
            ViewBag.TempId = id;
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Update(ShopPutDto dto)
        {
            var sender = new Sender();

            await sender.UpdateAsync("UpdateShop", dto);

            return RedirectToAction("GetShops");
        }

    }
}
