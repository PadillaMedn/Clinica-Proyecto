using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using proyectoFinal.Models;

namespace proyectoFinal.Controllers
{
    public class tipo_mascotaController : Controller
    {
        private Modelo db = new Modelo();

        // GET: tipo_mascota
        public ActionResult Index()
        {
            return View(db.tipo_mascota.ToList());
        }

        // GET: tipo_mascota/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipo_mascota tipo_mascota = db.tipo_mascota.Find(id);
            if (tipo_mascota == null)
            {
                return HttpNotFound();
            }
            return View(tipo_mascota);
        }

        // GET: tipo_mascota/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tipo_mascota/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "codtipo,especie")] tipo_mascota tipo_mascota)
        {
            if (ModelState.IsValid)
            {
                db.tipo_mascota.Add(tipo_mascota);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipo_mascota);
        }

        // GET: tipo_mascota/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipo_mascota tipo_mascota = db.tipo_mascota.Find(id);
            if (tipo_mascota == null)
            {
                return HttpNotFound();
            }
            return View(tipo_mascota);
        }

        // POST: tipo_mascota/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "codtipo,especie")] tipo_mascota tipo_mascota)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipo_mascota).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipo_mascota);
        }

        // GET: tipo_mascota/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipo_mascota tipo_mascota = db.tipo_mascota.Find(id);
            if (tipo_mascota == null)
            {
                return HttpNotFound();
            }
            return View(tipo_mascota);
        }

        // POST: tipo_mascota/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tipo_mascota tipo_mascota = db.tipo_mascota.Find(id);
            db.tipo_mascota.Remove(tipo_mascota);
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
