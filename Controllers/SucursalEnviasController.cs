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
    public class SucursalEnviasController : Controller
    {
        private DB_Context db = new DB_Context();

        // GET: SucursalEnvias
        public ActionResult Index()
        {
            var sucursalEnvias = db.SucursalEnvias.Include(s => s.sucursal);
            return View(sucursalEnvias.ToList());
        }

        // GET: SucursalEnvias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SucursalEnvia sucursalEnvia = db.SucursalEnvias.Find(id);
            if (sucursalEnvia == null)
            {
                return HttpNotFound();
            }
            return View(sucursalEnvia);
        }

        // GET: SucursalEnvias/Create
        public ActionResult Create()
        {
            ViewBag.SucursalId = new SelectList(db.Sucursales, "Id", "NombreTienda");
            return View();
        }

        // POST: SucursalEnvias/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,NombreAdicional,SucursalId")] SucursalEnvia sucursalEnvia)
        {
            if (ModelState.IsValid)
            {
                db.SucursalEnvias.Add(sucursalEnvia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SucursalId = new SelectList(db.Sucursales, "Id", "NombreTienda", sucursalEnvia.SucursalId);
            return View(sucursalEnvia);
        }

        // GET: SucursalEnvias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SucursalEnvia sucursalEnvia = db.SucursalEnvias.Find(id);
            if (sucursalEnvia == null)
            {
                return HttpNotFound();
            }
            ViewBag.SucursalId = new SelectList(db.Sucursales, "Id", "NombreTienda", sucursalEnvia.SucursalId);
            return View(sucursalEnvia);
        }

        // POST: SucursalEnvias/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,NombreAdicional,SucursalId")] SucursalEnvia sucursalEnvia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sucursalEnvia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SucursalId = new SelectList(db.Sucursales, "Id", "NombreTienda", sucursalEnvia.SucursalId);
            return View(sucursalEnvia);
        }

        // GET: SucursalEnvias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SucursalEnvia sucursalEnvia = db.SucursalEnvias.Find(id);
            if (sucursalEnvia == null)
            {
                return HttpNotFound();
            }
            return View(sucursalEnvia);
        }

        // POST: SucursalEnvias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SucursalEnvia sucursalEnvia = db.SucursalEnvias.Find(id);
            db.SucursalEnvias.Remove(sucursalEnvia);
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
