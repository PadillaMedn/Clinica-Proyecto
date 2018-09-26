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
    public class propietario_MascotaController : Controller
    {
        private Modelo db = new Modelo();

        // GET: propietario_Mascota
        public ActionResult Index()
        {
            return View(db.propietario_Mascota.ToList());
        }

        // GET: propietario_Mascota/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            propietario_Mascota propietario_Mascota = db.propietario_Mascota.Find(id);
            if (propietario_Mascota == null)
            {
                return HttpNotFound();
            }
            return View(propietario_Mascota);
        }

        // GET: propietario_Mascota/Create
        public ActionResult Create(string error)
        {
            ViewBag.errorMsj = error;
            return View();
        }

        // POST: propietario_Mascota/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "codpropietario,nombre,apellido,dui,sexo,telefono,direccion")] propietario_Mascota propietario_Mascota)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.propietario_Mascota.Add(propietario_Mascota);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(propietario_Mascota);
            }
            catch (Exception)
            {

                return RedirectToAction("Create", new { error = " Este Registro No se puede Crear" });
            }
          
        }

        // GET: propietario_Mascota/Edit/5
        public ActionResult Edit(int? id,string error)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            propietario_Mascota propietario_Mascota = db.propietario_Mascota.Find(id);
            if (propietario_Mascota == null)
            {
                return HttpNotFound();
            }
            ViewBag.errorMsj = error;
            return View(propietario_Mascota);
        }

        // POST: propietario_Mascota/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "codpropietario,nombre,apellido,dui,sexo,telefono,direccion")] propietario_Mascota propietario_Mascota)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(propietario_Mascota).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(propietario_Mascota);
            }
            catch (Exception)
            {

                return RedirectToAction("Edit", new {error = "No se Puede Editar algunos atributos ya se estan utilizando en otro registro" });
            }
            
        }

        // GET: propietario_Mascota/Delete/5
        public ActionResult Delete(int? id,string error)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            propietario_Mascota propietario_Mascota = db.propietario_Mascota.Find(id);
            if (propietario_Mascota == null)
            {
                return HttpNotFound();
            }
            ViewBag.errorMsj = error;
            return View(propietario_Mascota);
        }

        // POST: propietario_Mascota/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                propietario_Mascota propietario_Mascota = db.propietario_Mascota.Find(id);
                db.propietario_Mascota.Remove(propietario_Mascota);
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
