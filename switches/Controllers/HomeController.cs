using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
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
        public ActionResult DeleteConfirmed(int Id) {
            Switch Switch = db.Switches.Find(Id);
            db.Switches.Remove(Switch);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [Route("home/getListSwitches")]
        public JsonResult getListSwitches()
        {
            var Switches = db.Switches.ToList();

            return Json(Switches, JsonRequestBehavior.AllowGet);
        }


    }
}