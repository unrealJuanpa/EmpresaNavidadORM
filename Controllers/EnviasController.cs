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
    public class EnviasController : Controller
    {
        private DB_Context db = new DB_Context();

        // GET: Envias
        public ActionResult Index()
        {
            var envias = db.Envias.Include(e => e.producto).Include(e => e.sucursalEnvia).Include(e => e.sucursalRecibe);
            return View(envias.ToList());
        }

        // GET: Envias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Envia envia = db.Envias.Find(id);
            if (envia == null)
            {
                return HttpNotFound();
            }
            return View(envia);
        }

        // GET: Envias/Create
        public ActionResult Create()
        {
            ViewBag.ProductoId = new SelectList(db.Productos, "Id", "Nombre");
            ViewBag.SucursalEnviaId = new SelectList(db.SucursalEnvias, "Id", "NombreAdicional");
            ViewBag.SucursalRecibeId = new SelectList(db.SucursalRecibes, "Id", "NombreAdicional");
            return View();
        }

        // POST: Envias/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,NombreEnvio,CantidadEnvia,Fecha,ProductoId,SucursalEnviaId,SucursalRecibeId")] Envia envia)
        {
            if (ModelState.IsValid)
            {
                db.Envias.Add(envia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProductoId = new SelectList(db.Productos, "Id", "Nombre", envia.ProductoId);
            ViewBag.SucursalEnviaId = new SelectList(db.SucursalEnvias, "Id", "NombreAdicional", envia.SucursalEnviaId);
            ViewBag.SucursalRecibeId = new SelectList(db.SucursalRecibes, "Id", "NombreAdicional", envia.SucursalRecibeId);
            return View(envia);
        }

        // GET: Envias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Envia envia = db.Envias.Find(id);
            if (envia == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductoId = new SelectList(db.Productos, "Id", "Nombre", envia.ProductoId);
            ViewBag.SucursalEnviaId = new SelectList(db.SucursalEnvias, "Id", "NombreAdicional", envia.SucursalEnviaId);
            ViewBag.SucursalRecibeId = new SelectList(db.SucursalRecibes, "Id", "NombreAdicional", envia.SucursalRecibeId);
            return View(envia);
        }

        // POST: Envias/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,NombreEnvio,CantidadEnvia,Fecha,ProductoId,SucursalEnviaId,SucursalRecibeId")] Envia envia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(envia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductoId = new SelectList(db.Productos, "Id", "Nombre", envia.ProductoId);
            ViewBag.SucursalEnviaId = new SelectList(db.SucursalEnvias, "Id", "NombreAdicional", envia.SucursalEnviaId);
            ViewBag.SucursalRecibeId = new SelectList(db.SucursalRecibes, "Id", "NombreAdicional", envia.SucursalRecibeId);
            return View(envia);
        }

        // GET: Envias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Envia envia = db.Envias.Find(id);
            if (envia == null)
            {
                return HttpNotFound();
            }
            return View(envia);
        }

        // POST: Envias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Envia envia = db.Envias.Find(id);
            db.Envias.Remove(envia);
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
