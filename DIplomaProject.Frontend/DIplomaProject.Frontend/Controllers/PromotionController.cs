using DIplomaProject.Frontend.Helpers;
using DIplomaProject.Frontend.Models.Dto;
using DIplomaProject.Frontend.Models.Dto.Promotion;
using Microsoft.AspNetCore.Mvc;

namespace DIplomaProject.Frontend.Controllers
{
    public class PromotionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetPromotions()
        {
            var sender = new Sender();

            var promotions = await sender.GetAsync<PromotionGetDto>("GetAllPromotions");

            ViewBag.Promotions = promotions;

            return View();
        }

        public async Task<IActionResult> GetPromotionsByName(string query)
        {
            var sender = new Sender();

            if (!String.IsNullOrEmpty(query))
            {
                var promotions = await sender.GetAsync<PromotionSearchGetDto>($"GetPromotionsByName?name={query}");
                ViewBag.Promotions = promotions;
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
                var promotions = await sender.GetAsync<PromotionGetDto>($"FindPromotion?id={id}");
                ViewBag.FindById = promotions;
                return View();
            }


            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(PromotionPostDto promotion)
        {
            var sender = new Sender();

            await sender.PostAsync("CreatePromotion", promotion);

            return RedirectToAction("GetPromotions");
        }

        [HttpPost]
        public async Task<ActionResult> Delete(Guid id)
        {
            var dto = new IdDto { Id = id };
            var sender = new Sender();

            await sender.DeleteAsync("DeletePromotion", dto);

            return RedirectToAction("GetPromotions");
        }


        public ActionResult Update(Guid id)
        {
            ViewBag.TempId = id;
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Update(PromotionPutDto dto)
        {
            var sender = new Sender();

            await sender.UpdateAsync("UpdatePromotion", dto);

            return RedirectToAction("GetPromotions");
        }

    }
}
