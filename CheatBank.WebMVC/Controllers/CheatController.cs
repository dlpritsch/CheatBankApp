
using CheatBank.Models.CheatModels;
using CheatBank.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CheatBank.WebMVC.Controllers
{
    [Authorize]
    public class CheatController : Controller
    {
        // GET: Cheat
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CheatService(userId);
            var model = service.GetCheats();

            return View(model);
        }

        public ActionResult Create()
        {
            var gameService = CreateGameService();
            var getGame = gameService.GetGames();
            ViewBag.Games = getGame.ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CheatCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateCheatService();

            if (service.CreateCheat(model))
            {
                TempData["SaveResult"] = "Your cheat was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Cheat could not be created.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateCheatService();
            var model = svc.GetCheatById(id);

            return View(model);
        }


        public ActionResult Edit(int id)
        {
            var service = CreateCheatService();
            var detail = service.GetCheatById(id);
            var model =
                new CheatEdit
                {
                    CheatId = detail.CheatId,
                    NameOfCheat = detail.NameOfCheat,
                    CheatDetails = detail.CheatDetails
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CheatEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if(model.CheatId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateCheatService();

            if (service.UpdateCheat(model))
            {
                TempData["SaveResult"] = "Your cheat was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your cheat could not be updated.");
            return View();
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateCheatService();
            var model = svc.GetCheatById(id);

            return View(model);
        }
        private CheatService CreateCheatService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CheatService(userId);
            return service;
        }

        private GameService CreateGameService()
        {
            var service = new GameService();
            return service;
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateCheatService();

            service.DeleteCheat(id);

            TempData["SaveResult"] = "Your cheat was deleted";

            return RedirectToAction("Index");
        }

    }
}