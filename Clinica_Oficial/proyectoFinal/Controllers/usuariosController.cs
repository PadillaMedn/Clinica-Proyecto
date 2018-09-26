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
    public class usuariosController : Controller
    {
        private Modelo db = new Modelo();

        // GET: usuarios
        public ActionResult Index()
        {
            var usuario = db.usuario.Include(u => u.rol);
            return View(usuario.ToList());
        }

        // GET: usuarios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            usuario usuario = db.usuario.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // GET: usuarios/Create
        public ActionResult Create( string error)
        {
            ViewBag.id_rol = new SelectList(db.rol, "id", "rol1");
            ViewBag.errorMsj = error;
            return View();
        }

        // POST: usuarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,usuario1,pass,id_rol")] usuario usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.usuario.Add(usuario);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                ViewBag.id_rol = new SelectList(db.rol, "id", "rol1", usuario.id_rol);
                return View(usuario);
            }
            catch (Exception)
            {

                return RedirectToAction("Create", new { error = "Ya Existe este Usuario" });
            }
           
        }

        // GET: usuarios/Edit/5
        public ActionResult Edit(int? id,string error)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            usuario usuario = db.usuario.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_rol = new SelectList(db.rol, "id", "rol1", usuario.id_rol);
            ViewBag.errorMsj = error;
            return View(usuario);
        }

        // POST: usuarios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,usuario1,pass,id_rol")] usuario usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(usuario).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                ViewBag.id_rol = new SelectList(db.rol, "id", "rol1", usuario.id_rol);
                return View(usuario);
            }
            catch (Exception)
            {

                return RedirectToAction("Edit", new { error = "No se Puede Editar algunos atributos ya se estan utilizando en otro registro" });
            }
            
        }

        // GET: usuarios/Delete/5
        public ActionResult Delete(int? id,string error)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            usuario usuario = db.usuario.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            ViewBag.errorMsj = error;
            return View(usuario);
        }

        // POST: usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                usuario usuario = db.usuario.Find(id);
                db.usuario.Remove(usuario);
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
