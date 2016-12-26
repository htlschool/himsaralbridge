using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Svm;

namespace Svm.Controllers
{
    public class LedgerController : Controller
    {
        private shimlaEntities db = new shimlaEntities();

        // GET: Ledger
        public ActionResult Index()
        {
            return View(db.LedgerMasters.ToList());
        }

        // GET: Ledger/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LedgerMaster ledgerMaster = db.LedgerMasters.Find(id);
            if (ledgerMaster == null)
            {
                return HttpNotFound();
            }
            return View(ledgerMaster);
        }

        // GET: Ledger/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ledger/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LedgerId,LedgerName")] LedgerMaster ledgerMaster)
        {
            if (ModelState.IsValid)
            {
                db.LedgerMasters.Add(ledgerMaster);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ledgerMaster);
        }

        // GET: Ledger/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LedgerMaster ledgerMaster = db.LedgerMasters.Find(id);
            if (ledgerMaster == null)
            {
                return HttpNotFound();
            }
            return View(ledgerMaster);
        }

        // POST: Ledger/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LedgerId,LedgerName")] LedgerMaster ledgerMaster)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ledgerMaster).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ledgerMaster);
        }

        // GET: Ledger/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LedgerMaster ledgerMaster = db.LedgerMasters.Find(id);
            if (ledgerMaster == null)
            {
                return HttpNotFound();
            }
            return View(ledgerMaster);
        }

        // POST: Ledger/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LedgerMaster ledgerMaster = db.LedgerMasters.Find(id);
            db.LedgerMasters.Remove(ledgerMaster);
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
