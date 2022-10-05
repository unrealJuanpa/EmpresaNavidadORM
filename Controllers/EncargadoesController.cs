using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EmpresaNavidadORM.Models;

namespace EmpresaNavidadORM.Controllers
{
    public class EncargadoesController : Controller
    {
        private DB_Context db = new DB_Context();

        // GET: Encargadoes
        public ActionResult Index()
        {
            return View(db.Encargados.ToList());
        }

        // GET: Encargadoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Encargado encargado = db.Encargados.Find(id);
            if (encargado == null)
            {
                return HttpNotFound();
            }
            return View(encargado);
        }

        // GET: Encargadoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Encargadoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre,Telefono,Direccion,Email")] Encargado encargado)
        {
            if (ModelState.IsValid)
            {
                db.Encargados.Add(encargado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(encargado);
        }

        // GET: Encargadoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Encargado encargado = db.Encargados.Find(id);
            if (encargado == null)
            {
                return HttpNotFound();
            }
            return View(encargado);
        }

        // POST: Encargadoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,Telefono,Direccion,Email")] Encargado encargado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(encargado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(encargado);
        }

        // GET: Encargadoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Encargado encargado = db.Encargados.Find(id);
            if (encargado == null)
            {
                return HttpNotFound();
            }
            return View(encargado);
        }

        // POST: Encargadoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Encargado encargado = db.Encargados.Find(id);
            db.Encargados.Remove(encargado);
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
