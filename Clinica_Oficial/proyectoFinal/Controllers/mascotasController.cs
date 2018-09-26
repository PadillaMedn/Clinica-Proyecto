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
    public class mascotasController : Controller
    {
        private Modelo db = new Modelo();

        // GET: mascotas
        public ActionResult Index()
        {
            var mascota = db.mascota.Include(m => m.propietario_Mascota).Include(m => m.tipo_mascota);
            return View(mascota.ToList());
        }

        // GET: mascotas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mascota mascota = db.mascota.Find(id);
            if (mascota == null)
            {
                return HttpNotFound();
            }
            return View(mascota);
        }

        // GET: mascotas/Create
        public ActionResult Create()
        {
            ViewBag.codpropietario = new SelectList(db.propietario_Mascota, "codpropietario", "nombre");
            ViewBag.codtipo = new SelectList(db.tipo_mascota, "codtipo", "especie");
            return View();
        }

        // POST: mascotas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "codmascota,codpropietario,codtipo,nombre,peso,sexo,fechanacimiento")] mascota mascota)
        {
            if (ModelState.IsValid)
            {
                db.mascota.Add(mascota);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.codpropietario = new SelectList(db.propietario_Mascota, "codpropietario", "nombre", mascota.codpropietario);
            ViewBag.codtipo = new SelectList(db.tipo_mascota, "codtipo", "especie", mascota.codtipo);
            return View(mascota);
        }

        // GET: mascotas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mascota mascota = db.mascota.Find(id);
            if (mascota == null)
            {
                return HttpNotFound();
            }
            ViewBag.codpropietario = new SelectList(db.propietario_Mascota, "codpropietario", "nombre", mascota.codpropietario);
            ViewBag.codtipo = new SelectList(db.tipo_mascota, "codtipo", "especie", mascota.codtipo);
            return View(mascota);
        }

        // POST: mascotas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "codmascota,codpropietario,codtipo,nombre,peso,sexo,fechanacimiento")] mascota mascota)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mascota).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.codpropietario = new SelectList(db.propietario_Mascota, "codpropietario", "nombre", mascota.codpropietario);
            ViewBag.codtipo = new SelectList(db.tipo_mascota, "codtipo", "especie", mascota.codtipo);
            return View(mascota);
        }

        // GET: mascotas/Delete/5
        public ActionResult Delete(int? id ,string error)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mascota mascota = db.mascota.Find(id);
            if (mascota == null)
            {
                return HttpNotFound();
            }
            ViewBag.errorMsj = error;
            return View(mascota);
        }

        // POST: mascotas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                mascota mascota = db.mascota.Find(id);
                db.mascota.Remove(mascota);
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
