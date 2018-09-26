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
    public class recetasController : Controller
    {
        private Modelo db = new Modelo();

        // GET: recetas
        public ActionResult Index()
        {
            var receta = db.receta.Include(r => r.consulta);
            return View(receta.ToList());
        }
        public ActionResult info()
        {
            var consulta = db.consulta.Include(r => r.cita);
            return View(consulta.ToList());
        }


        // GET: recetas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            receta receta = db.receta.Find(id);
            if (receta == null)
            {
                return HttpNotFound();
            }
            return View(receta);
        }

        // GET: recetas/Create
        public ActionResult Create()
        {
            ViewBag.codconsulta = new SelectList(db.consulta, "codconsulta", "codconsulta");
            var consulta= db.consulta.Include(c => c.cita);
            ViewBag.consulta = consulta.ToList();
            return View();
        }

        // POST: recetas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "codreceta,codconsulta,descripcion,dosis")] receta receta)
        {
            if (ModelState.IsValid)
            {
                db.receta.Add(receta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.codconsulta = new SelectList(db.consulta, "codconsulta", "diagnostico", receta.codconsulta);
            return View(receta);
        }

        // GET: recetas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            receta receta = db.receta.Find(id);
            if (receta == null)
            {
                return HttpNotFound();
            }
            ViewBag.codconsulta = new SelectList(db.consulta, "codconsulta", "diagnostico", receta.codconsulta);
            return View(receta);
        }

        // POST: recetas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "codreceta,codconsulta,descripcion,dosis")] receta receta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(receta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.codconsulta = new SelectList(db.consulta, "codconsulta", "diagnostico", receta.codconsulta);
            return View(receta);
        }

        // GET: recetas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            receta receta = db.receta.Find(id);
            if (receta == null)
            {
                return HttpNotFound();
            }
            return View(receta);
        }

        // POST: recetas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            receta receta = db.receta.Find(id);
            db.receta.Remove(receta);
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
