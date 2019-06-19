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
    public class Moto4Controller : Controller
    {
        private Moto4DBContext db = new Moto4DBContext();

        // GET: Moto4
        public ActionResult Index()
        {
            return View(db.Moto4s.ToList());
        }

        // GET: Moto4/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Moto4 moto4 = db.Moto4s.Find(id);
            if (moto4 == null)
            {
                return HttpNotFound();
            }
            return View(moto4);
        }

        // GET: Moto4/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Moto4/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Motoname,CC,price")] Moto4 moto4)
        {
            if (ModelState.IsValid)
            {
                db.Moto4s.Add(moto4);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(moto4);
        }

        // GET: Moto4/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Moto4 moto4 = db.Moto4s.Find(id);
            if (moto4 == null)
            {
                return HttpNotFound();
            }
            return View(moto4);
        }

        // POST: Moto4/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Motoname,CC,price")] Moto4 moto4)
        {
            if (ModelState.IsValid)
            {
                db.Entry(moto4).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(moto4);
        }

        // GET: Moto4/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Moto4 moto4 = db.Moto4s.Find(id);
            if (moto4 == null)
            {
                return HttpNotFound();
            }
            return View(moto4);
        }

        // POST: Moto4/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Moto4 moto4 = db.Moto4s.Find(id);
            db.Moto4s.Remove(moto4);
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
