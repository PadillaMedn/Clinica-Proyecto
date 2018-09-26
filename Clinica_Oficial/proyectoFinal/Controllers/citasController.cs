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
    public class citasController : Controller
    {
        private Modelo db = new Modelo();

        // GET: citas
        public ActionResult Index()
        {
            var cita = db.cita.Include(c => c.estado).Include(c => c.mascota).Include(c => c.usuario).Include(c => c.veterinario);
            return View(cita.ToList());
        }

        // GET: citas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cita cita = db.cita.Find(id);
            if (cita == null)
            {
                return HttpNotFound();
            }
            return View(cita);
        }

        // GET: citas/Create
        public ActionResult Create()
        {
            ViewBag.codestado = new SelectList(db.estado, "codestado", "estado1");
            ViewBag.codmascota = new SelectList(db.mascota, "codmascota", "nombre");
            ViewBag.codusuario = new SelectList(db.usuario, "id", "usuario1");
            ViewBag.codveterinario = new SelectList(db.veterinario, "codVeterinario", "nombre");
            return View();
        }

        // POST: citas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "codcita,codusuario,codmascota,codveterinario,fecha,hora,codestado")] cita cita)
        {
            if (ModelState.IsValid)
            {
                db.cita.Add(cita);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.codestado = new SelectList(db.estado, "codestado", "estado1", cita.codestado);
            ViewBag.codmascota = new SelectList(db.mascota, "codmascota", "nombre", cita.codmascota);
            ViewBag.codusuario = new SelectList(db.usuario, "id", "usuario1", cita.codusuario);
            ViewBag.codveterinario = new SelectList(db.veterinario, "codVeterinario", "nombre", cita.codveterinario);
            return View(cita);
        }

        // GET: citas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cita cita = db.cita.Find(id);
            if (cita == null)
            {
                return HttpNotFound();
            }
            ViewBag.codestado = new SelectList(db.estado, "codestado", "estado1", cita.codestado);
            ViewBag.codmascota = new SelectList(db.mascota, "codmascota", "nombre", cita.codmascota);
            ViewBag.codusuario = new SelectList(db.usuario, "id", "usuario1", cita.codusuario);
            ViewBag.codveterinario = new SelectList(db.veterinario, "codVeterinario", "nombre", cita.codveterinario);
            return View(cita);
        }

        // POST: citas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "codcita,codusuario,codmascota,codveterinario,fecha,hora,codestado")] cita cita)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cita).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.codestado = new SelectList(db.estado, "codestado", "estado1", cita.codestado);
            ViewBag.codmascota = new SelectList(db.mascota, "codmascota", "nombre", cita.codmascota);
            ViewBag.codusuario = new SelectList(db.usuario, "id", "usuario1", cita.codusuario);
            ViewBag.codveterinario = new SelectList(db.veterinario, "codVeterinario", "nombre", cita.codveterinario);
            return View(cita);
        }

        // GET: citas/Delete/5
        public ActionResult Delete(int? id, string error)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cita cita = db.cita.Find(id);
            if (cita == null)
            {
                return HttpNotFound();
            }
            ViewBag.errorMsj = error;
            return View(cita);
        }

        // POST: citas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                cita cita = db.cita.Find(id);
                db.cita.Remove(cita);
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
