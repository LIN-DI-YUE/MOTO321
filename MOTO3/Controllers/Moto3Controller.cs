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
    public class Moto3Controller : Controller
    {
        private Moto3DBContext db = new Moto3DBContext();

        // GET: Moto3
        public ActionResult Index()
        {
            return View(db.Moto3s.ToList());
        }

        // GET: Moto3/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Moto3 moto3 = db.Moto3s.Find(id);
            if (moto3 == null)
            {
                return HttpNotFound();
            }
            return View(moto3);
        }

        // GET: Moto3/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Moto3/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Motoname,CC,price")] Moto3 moto3)
        {
            if (ModelState.IsValid)
            {
                db.Moto3s.Add(moto3);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(moto3);
        }

        // GET: Moto3/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Moto3 moto3 = db.Moto3s.Find(id);
            if (moto3 == null)
            {
                return HttpNotFound();
            }
            return View(moto3);
        }

        // POST: Moto3/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Motoname,CC,price")] Moto3 moto3)
        {
            if (ModelState.IsValid)
            {
                db.Entry(moto3).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(moto3);
        }

        // GET: Moto3/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Moto3 moto3 = db.Moto3s.Find(id);
            if (moto3 == null)
            {
                return HttpNotFound();
            }
            return View(moto3);
        }

        // POST: Moto3/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Moto3 moto3 = db.Moto3s.Find(id);
            db.Moto3s.Remove(moto3);
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
