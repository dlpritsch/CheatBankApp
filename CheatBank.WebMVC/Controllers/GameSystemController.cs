using CheatBank.Models.GameModels;
using CheatBank.Models.SystemModels;
using CheatBank.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CheatBank.WebMVC.Controllers
{
    public class GameSystemController : Controller
    {
        private readonly GameSystemService _service = new GameSystemService();

        public ActionResult Index()
        {
 
            var model = _service.GetGameSystems();

            return View(model);
        }

        //GET
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GameSystemCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            if (_service.CreateGameSystem(model))
            {
                TempData["SaveResult"] = "Your system was created.";
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "System Could not be created.");
            }

            return View(model);

        }

        public ActionResult Details(int id)
        {
            var model = _service.GetGameSystemById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var detail = _service.GetGameSystemById(id);
            var model =
                new GameSystemEdit
                {
                    SystemName = detail.SystemName,
                    SystemId = detail.SystemId
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, GameSystemEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.SystemId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }


            if (_service.UpdateGameSystem(model))
            {
                TempData["SaveResult"] = "Your system was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your system could not be updated.");
            return View();
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {

            var model = _service.GetGameSystemById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {

            _service.DeleteGameSystem(id);

            TempData["SaveResult"] = "Your system was deleted.";

            return RedirectToAction("Index");
        }
    }
}