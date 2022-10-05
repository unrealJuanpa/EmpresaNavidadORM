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
    public class SucursalRecibesController : Controller
    {
        private DB_Context db = new DB_Context();

        // GET: SucursalRecibes
        public ActionResult Index()
        {
            var sucursalRecibes = db.SucursalRecibes.Include(s => s.sucursal);
            return View(sucursalRecibes.ToList());
        }

        // GET: SucursalRecibes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SucursalRecibe sucursalRecibe = db.SucursalRecibes.Find(id);
            if (sucursalRecibe == null)
            {
                return HttpNotFound();
            }
            return View(sucursalRecibe);
        }

        // GET: SucursalRecibes/Create
        public ActionResult Create()
        {
            ViewBag.SucursalId = new SelectList(db.Sucursales, "Id", "NombreTienda");
            return View();
        }

        // POST: SucursalRecibes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,NombreAdicional,SucursalId")] SucursalRecibe sucursalRecibe)
        {
            if (ModelState.IsValid)
            {
                db.SucursalRecibes.Add(sucursalRecibe);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SucursalId = new SelectList(db.Sucursales, "Id", "NombreTienda", sucursalRecibe.SucursalId);
            return View(sucursalRecibe);
        }

        // GET: SucursalRecibes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SucursalRecibe sucursalRecibe = db.SucursalRecibes.Find(id);
            if (sucursalRecibe == null)
            {
                return HttpNotFound();
            }
            ViewBag.SucursalId = new SelectList(db.Sucursales, "Id", "NombreTienda", sucursalRecibe.SucursalId);
            return View(sucursalRecibe);
        }

        // POST: SucursalRecibes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,NombreAdicional,SucursalId")] SucursalRecibe sucursalRecibe)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sucursalRecibe).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SucursalId = new SelectList(db.Sucursales, "Id", "NombreTienda", sucursalRecibe.SucursalId);
            return View(sucursalRecibe);
        }

        // GET: SucursalRecibes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SucursalRecibe sucursalRecibe = db.SucursalRecibes.Find(id);
            if (sucursalRecibe == null)
            {
                return HttpNotFound();
            }
            return View(sucursalRecibe);
        }

        // POST: SucursalRecibes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SucursalRecibe sucursalRecibe = db.SucursalRecibes.Find(id);
            db.SucursalRecibes.Remove(sucursalRecibe);
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
