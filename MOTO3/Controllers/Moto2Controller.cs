using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MOTO3.Models;

namespace MOTO3.Controllers
{
    public class Moto2Controller : Controller
    {
        private Moto2DBContext db = new Moto2DBContext();

        // GET: Moto2
        public ActionResult Index()
        {
            return View(db.Moto2s.ToList());
        }

        // GET: Moto2/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Moto2 moto2 = db.Moto2s.Find(id);
            if (moto2 == null)
            {
                return HttpNotFound();
            }
            return View(moto2);
        }

        // GET: Moto2/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Moto2/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Motoname,CC,price")] Moto2 moto2)
        {
            if (ModelState.IsValid)
            {
                db.Moto2s.Add(moto2);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(moto2);
        }

        // GET: Moto2/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Moto2 moto2 = db.Moto2s.Find(id);
            if (moto2 == null)
            {
                return HttpNotFound();
            }
            return View(moto2);
        }

        // POST: Moto2/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Motoname,CC,price")] Moto2 moto2)
        {
            if (ModelState.IsValid)
            {
                db.Entry(moto2).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(moto2);
        }

        // GET: Moto2/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Moto2 moto2 = db.Moto2s.Find(id);
            if (moto2 == null)
            {
                return HttpNotFound();
            }
            return View(moto2);
        }

        // POST: Moto2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Moto2 moto2 = db.Moto2s.Find(id);
            db.Moto2s.Remove(moto2);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
