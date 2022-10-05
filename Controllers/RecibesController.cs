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
    public class RecibesController : Controller
    {
        private DB_Context db = new DB_Context();

        // GET: Recibes
        public ActionResult Index()
        {
            var recibes = db.Recibes.Include(r => r.envia);
            return View(recibes.ToList());
        }

        // GET: Recibes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recibe recibe = db.Recibes.Find(id);
            if (recibe == null)
            {
                return HttpNotFound();
            }
            return View(recibe);
        }

        // GET: Recibes/Create
        public ActionResult Create()
        {
            ViewBag.EnviaId = new SelectList(db.Envias, "Id", "NombreEnvio");
            return View();
        }

        // POST: Recibes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Fecha,EnviaId")] Recibe recibe)
        {
            if (ModelState.IsValid)
            {
                db.Recibes.Add(recibe);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EnviaId = new SelectList(db.Envias, "Id", "NombreEnvio", recibe.EnviaId);
            return View(recibe);
        }

        // GET: Recibes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recibe recibe = db.Recibes.Find(id);
            if (recibe == null)
            {
                return HttpNotFound();
            }
            ViewBag.EnviaId = new SelectList(db.Envias, "Id", "NombreEnvio", recibe.EnviaId);
            return View(recibe);
        }

        // POST: Recibes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Fecha,EnviaId")] Recibe recibe)
        {
            if (ModelState.IsValid)
            {
                db.Entry(recibe).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EnviaId = new SelectList(db.Envias, "Id", "NombreEnvio", recibe.EnviaId);
            return View(recibe);
        }

        // GET: Recibes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recibe recibe = db.Recibes.Find(id);
            if (recibe == null)
            {
                return HttpNotFound();
            }
            return View(recibe);
        }

        // POST: Recibes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Recibe recibe = db.Recibes.Find(id);
            db.Recibes.Remove(recibe);
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
