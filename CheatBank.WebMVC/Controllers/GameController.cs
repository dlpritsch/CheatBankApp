using CheatBank.Models.GameModels;
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
    public class GameController : Controller
    {
        // GET: Game
        public ActionResult Index()
        {
            var service = new GameService();
            var model = service.GetGames();

            return View(model);
        }

        //GET
        public ActionResult Create()
        {
            var systemService = CreateGameSystemService();
            var getGameSystem = systemService.GetGameSystems();
            ViewBag.GameSystems = getGameSystem.ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GameCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateGameService();

            if (service.CreateGame(model))
            {
                TempData["SaveResult"] = "Your game was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Game Could not be created.");

            return View(model);

        }

        public ActionResult Details(int id)
        {
            var svc = CreateGameService();
            var model = svc.GetGameById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateGameService();
            var detail = service.GetGameById(id);
            var model =
                new GameEdit
                {
                    GameId = detail.GameId,
                    TitleOfGame = detail.TitleOfGame,
                    GameSystem = detail.GameSystem,
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, GameEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if(model.GameId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateGameService();

            if (service.UpdateGame(model))
            {
                TempData["SaveResult"] = "Your game was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your game could not be updated.");
            return View();
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateGameService();
            var model = svc.GetGameById(id);

            return View(model);
        }

        private GameService CreateGameService()
        {
            var service = new GameService();
            return service;
        }

        private GameSystemService CreateGameSystemService()
        {
            var service = new GameSystemService();
            return service;
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateGameService();

            service.DeleteGame(id);

            TempData["SaveResult"] = "Your game was deleted.";
                
            return RedirectToAction("Index");
        }
    }
}