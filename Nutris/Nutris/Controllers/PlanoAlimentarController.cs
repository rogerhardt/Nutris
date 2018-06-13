using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Nutris.Models;

namespace Nutris.Controllers
{
    public class PlanoAlimentarController : Controller
    {
        private NutrisEntities db = new NutrisEntities();

        // GET: PlanoAlimentar
        [Authorize]
        public ActionResult Index()
        {            
            return View(db.PlanoAlimentar.Where(a => a.Usuario == User.Identity.Name).ToList());
        }

        // GET: PlanoAlimentar/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlanoAlimentar PlanoAlimentar = db.PlanoAlimentar.Find(id);
            if (PlanoAlimentar == null)
            {
                return HttpNotFound();
            }

            List<ItemPlanoAlimentar> itensPlanoAlimentar = db.ItemPlanoAlimentar.Where(a => a.IdPlanoAlimentar == PlanoAlimentar.Id).ToList();
            PlanoAlimentarViewModel PlanoAlimentarView = new PlanoAlimentarViewModel
            {
                PlanoAlimentar = PlanoAlimentar,
                items = itensPlanoAlimentar
            };

            return View(PlanoAlimentarView);
        }

        // GET: PlanoAlimentar/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: PlanoAlimentar/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Descricao")] PlanoAlimentar PlanoAlimentar)
        {
            if (ModelState.IsValid)
            {
                PlanoAlimentar.Usuario = User.Identity.Name;
                db.PlanoAlimentar.Add(PlanoAlimentar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(PlanoAlimentar);
        }

        // GET: PlanoAlimentar/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlanoAlimentar PlanoAlimentar = db.PlanoAlimentar.Find(id);
            if (PlanoAlimentar == null)
            {
                return HttpNotFound();
            }
            return View(PlanoAlimentar);
        }

        // POST: PlanoAlimentar/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit([Bind(Include = "Id,Descricao")] PlanoAlimentar PlanoAlimentar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(PlanoAlimentar).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(PlanoAlimentar);
        }

        // GET: PlanoAlimentar/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlanoAlimentar PlanoAlimentar = db.PlanoAlimentar.Find(id);
            if (PlanoAlimentar == null)
            {
                return HttpNotFound();
            }
            return View(PlanoAlimentar);
        }

        // POST: PlanoAlimentar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult DeleteConfirmed(int id)
        {
            PlanoAlimentar PlanoAlimentar = db.PlanoAlimentar.Find(id);
            db.PlanoAlimentar.Remove(PlanoAlimentar);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [Authorize]
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
