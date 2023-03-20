using DIplomaProject.Frontend.Helpers;
using DIplomaProject.Frontend.Models.Dto;
using DIplomaProject.Frontend.Models.Dto.ShopUser;
using Microsoft.AspNetCore.Mvc;

namespace DIplomaProject.Frontend.Controllers
{
    public class ShopUserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetShopUsers()
        {
            var sender = new Sender();

            var shopUsers = await sender.GetAsync<ShopUserGetDto>("GetAllShopUsers");

            ViewBag.ShopUsers = shopUsers;

            return View();
        }

        
        public async Task<IActionResult> FindById(string id)
        {
            var sender = new Sender();

            if (Guid.TryParse(id, out var guid))
            {
                var dto = new IdDto { Id = guid };
                var shopUsers = await sender.GetAsync<ShopUserGetDto>($"FindShopUser?id={id}");
                ViewBag.FindById = shopUsers;
                return View();
            }


            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(ShopUserPostDto shopUser)
        {
            var sender = new Sender();

            await sender.PostAsync("CreateShopUser", shopUser);

            return RedirectToAction("GetShopUsers");
        }

        [HttpPost]
        public async Task<ActionResult> Delete(Guid id)
        {
            var dto = new IdDto { Id = id };
            var sender = new Sender();

            await sender.DeleteAsync("DeleteShopUser", dto);

            return RedirectToAction("GetShopUsers");
        }
    }
}
