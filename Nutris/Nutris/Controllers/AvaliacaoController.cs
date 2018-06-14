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
    public class AvaliacaoController : Controller
    {
        private NutrisEntities db = new NutrisEntities();

        // GET: Avaliação
        [Authorize]
        public ActionResult Index()
        {
            return View(db.Avaliacao.Where(a => a.loginPaciente == User.Identity.Name).ToList());
        }

        // GET: Avaliação/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Avaliacao Avaliacao = db.Avaliacao.Find(id);
            if (Avaliacao == null)
            {
                return HttpNotFound();
            }
          
            AvaliacaoViewModel AvaliacaoView = new AvaliacaoViewModel
            {
                Avaliacao = Avaliacao
            };

            return View(AvaliacaoView);
        }

        // GET: Avaliacao/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Avaliacao/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Data,loginNutricionista,loginPaciente, Detalhe")] Avaliacao Avaliacao)
        {
            if (ModelState.IsValid)
            {
                Avaliacao.loginPaciente = User.Identity.Name;
                db.Avaliacao.Add(Avaliacao);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(Avaliacao);
        }


        // GET: Avaliacao/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Avaliacao Avaliacao = db.Avaliacao.Find(id);
            if (Avaliacao == null)
            {
                return HttpNotFound();
            }
            return View(Avaliacao);
        }


        // GET: Avaliacao/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Avaliacao Avaliacao= db.Avaliacao.Find(id);
            if (Avaliacao == null)
            {
                return HttpNotFound();
            }
            return View(Avaliacao);
        }

       

        [Authorize]
        public ActionResult DeleteAvaliacao(int? IdAvaliacao)
        {
            if (IdAvaliacao == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Avaliacao Avaliacao= db.Avaliacao.Where(a => a.Id == IdAvaliacao).FirstOrDefault();
            if (Avaliacao == null)
            {
                return HttpNotFound();
            }
            return View(Avaliacao);
        }

        // POST: Avaliacao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult DeleteConfirmed(int id)
        {
            Avaliacao Avaliacao = db.Avaliacao.Find(id);
            db.Avaliacao.Remove(Avaliacao);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpPost, ActionName("DeleteAvaliacao")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult DeleteAvaliacaoConfirmed(int? idAvaliacao)
        {
            Avaliacao Avaliacao = db.Avaliacao.Where(a => a.Id == idAvaliacao ).FirstOrDefault();
            db.Avaliacao.Remove(Avaliacao);
            db.SaveChanges();
            return RedirectToAction("AvaliacaoIndex", new { id = Avaliacao.Id});
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
