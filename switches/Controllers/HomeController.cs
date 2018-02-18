using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Switches.Models;

namespace switches.Controllers
{
    public class HomeController : Controller
    {
        SwitchContext db = new SwitchContext();

        public ActionResult Index()
        {
            IEnumerable<Switch> Switches = db.Switches;
            ViewBag.Switches = Switches;
            return View();
        }

        [HttpGet]
        public ActionResult EditSwitch(int? Id) {
            if (Id == null) {
                return HttpNotFound();
            }
            Switch Switch = db.Switches.Find(Id);

            if (Switch != null) {
                return View(Switch);
            }
            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult EditSwitch(Switch Switch) {
            db.Entry(Switch).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult AddSwitch() {
            return View();
        }

        [HttpPost]
        public ActionResult AddSwitch(Switch Switch)
        {
            db.Entry(Switch).State = EntityState.Added;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int? Id) {
            if (Id == null)
            {
                return HttpNotFound();
            }

            Switch Switch = db.Switches.Find(Id);

            if (Switch != null)
            {
                return View(Switch);
            }
            return HttpNotFound();
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int Id)
        {
            Switch Switch = db.Switches.Find(Id);
            db.Switches.Remove(Switch);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [Route("home/getListSwitches")]
        public JsonResult GetListSwitches()
        {
            var Switches = db.Switches.ToList();

            return Json(Switches, JsonRequestBehavior.AllowGet);
        }


        [Route("home/getModels")]
        public JsonResult GetModels()
        {
            var Models = db.Switches.Select(x => x.Model).Distinct().ToList();
            return Json(Models, JsonRequestBehavior.AllowGet);
        }

        [Route("home//home/getFloors")]
        public JsonResult GetFloors()
        {
            var Floors = db.Switches.Select(x => x.Floor).Distinct().ToList();
            return Json(Floors, JsonRequestBehavior.AllowGet);
        }

        [Route("home/getFilterSwitches")]
        public JsonResult GetFilterSwitches(string[] models, string[] floors)
        {
            var filterResult = db.Switches.Where(x => models.Contains(x.Model) && floors.Contains(x.Floor)).ToList();
            return Json(filterResult, JsonRequestBehavior.AllowGet);
        }
    }
}