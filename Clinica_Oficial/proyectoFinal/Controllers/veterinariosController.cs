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
    public class veterinariosController : Controller
    {
        private Modelo db = new Modelo();

        // GET: veterinarios
        public ActionResult Index()
        {
            return View(db.veterinario.ToList());
        }

        // GET: veterinarios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            veterinario veterinario = db.veterinario.Find(id);
            if (veterinario == null)
            {
                return HttpNotFound();
            }
            return View(veterinario);
        }

        // GET: veterinarios/Create
        public ActionResult Create(string error)
        {
            ViewBag.errorMsj = error;
            return View();
        }

        // POST: veterinarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "codVeterinario,nombre,apellido,dui,telefono,sexo,direccion")] veterinario veterinario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.veterinario.Add(veterinario);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(veterinario);
            }
            catch (Exception)
            {

                return RedirectToAction("Create", new { error = "no se puede crear" });
            }
           
        }

        // GET: veterinarios/Edit/5
        public ActionResult Edit(int? id,string error)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            veterinario veterinario = db.veterinario.Find(id);
            if (veterinario == null)
            {
                return HttpNotFound();
            }
            ViewBag.errorMsj = error;
            return View(veterinario);
        }

        // POST: veterinarios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "codVeterinario,nombre,apellido,dui,telefono,sexo,direccion")] veterinario veterinario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(veterinario).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(veterinario);
            }
            catch (Exception)
            {

                return RedirectToAction("Edit", new { error = "No se Puede Editar algunos atributos ya se estan utilizando en otro registro" });
            }
            
        }

        // GET: veterinarios/Delete/5
        public ActionResult Delete(int? id,string error)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            veterinario veterinario = db.veterinario.Find(id);
            if (veterinario == null)
            {
                return HttpNotFound();
            }
            ViewBag.errorMsj = error;
            return View(veterinario);
        }

        // POST: veterinarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                veterinario veterinario = db.veterinario.Find(id);
                db.veterinario.Remove(veterinario);
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
