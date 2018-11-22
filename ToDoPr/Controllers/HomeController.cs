using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToDoPr.Models;

namespace ToDoPr.Controllers
{
    public class HomeController : Controller
    {
        TaskContext db = new TaskContext();

        public ActionResult Index()
        {
            return View(db.Tasks);
        }

        // Добавление задачи
        public ActionResult Create()
        {
            return PartialView("Create");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Task tsk)
        {
            db.Tasks.Add(tsk);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // Редактирование задачи
        public ActionResult Edit(int id)
        {
            Task tsk = db.Tasks.Find(id);
            if (tsk != null)
            {
                return PartialView("Edit", tsk);
            }
            return View("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Task tsk)
        {
            db.Entry(tsk).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // Удаление задачи
        public ActionResult Delete(int id)
        {
            Task tsk = db.Tasks.Find(id);
            if (tsk != null)
            {
                return PartialView("Delete", tsk);
            }
            return View("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteRecord(int id)
        {
            Task tsk = db.Tasks.Find(id);
            if (tsk != null)
            {
                db.Tasks.Remove(tsk);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}