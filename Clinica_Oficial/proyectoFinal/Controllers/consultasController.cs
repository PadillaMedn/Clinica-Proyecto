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
    public class consultasController : Controller
    {
        private Modelo db = new Modelo();

        // GET: consultas
        public ActionResult Index()
        {
            var consulta = db.consulta.Include(c => c.cita);
            return View(consulta.ToList());
        }
        public ActionResult info()
        {
            var cita = db.cita.Include(c => c.estado).Include(c => c.mascota).Include(c => c.veterinario);
            return View(cita.ToList());
        }

        // GET: consultas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            consulta consulta = db.consulta.Find(id);
            if (consulta == null)
            {
                return HttpNotFound();
            }
            return View(consulta);
        }

        // GET: consultas/Create
        public ActionResult Create()
        {
            ViewBag.codcita = new SelectList(db.cita, "codcita","codcita");
            var cita = db.cita.Include(c => c.estado).Include(c => c.mascota).Include(c => c.veterinario);
            ViewBag.cita = cita.ToList();
            return View();
        }

        // POST: consultas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "codconsulta,diagnostico,observaciones,codcita")] consulta consulta)
        {
            if (ModelState.IsValid)
            {
                db.consulta.Add(consulta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.codcita = new SelectList(db.cita, "codcita", "fecha", consulta.codcita);
            return View(consulta);
        }

        // GET: consultas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            consulta consulta = db.consulta.Find(id);
            if (consulta == null)
            {
                return HttpNotFound();
            }
            ViewBag.codcita = new SelectList(db.cita, "codcita", "fecha", consulta.codcita);
            return View(consulta);
        }

        // POST: consultas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "codconsulta,diagnostico,observaciones,codcita")] consulta consulta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(consulta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.codcita = new SelectList(db.cita, "codcita", "fecha", consulta.codcita);
            return View(consulta);
        }

        // GET: consultas/Delete/5
        public ActionResult Delete(int? id,string error)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            consulta consulta = db.consulta.Find(id);
            if (consulta == null)
            {
                return HttpNotFound();
            }
            ViewBag.errorMsj = error;
            return View(consulta);
        }

        // POST: consultas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                consulta consulta = db.consulta.Find(id);
                db.consulta.Remove(consulta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                return RedirectToAction("Delete", new { id = id, error = "No se Puede Eliminar porque se esta utilizando" });
            }
           
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
