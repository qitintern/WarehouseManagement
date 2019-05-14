using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WarehouseManagement.DAL;

namespace WarehouseManagement.Controllers
{
    public class BinStockController : Controller
    {
        private warehouse_managementEntities db = new warehouse_managementEntities();

        // GET: BinStock
        public ActionResult Index()
        {
            var bin_Stock = db.Bin_Stock.Include(b => b.Bin).Include(b => b.Stock);
            return View(bin_Stock.ToList());
        }

        // GET: BinStock/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bin_Stock bin_Stock = db.Bin_Stock.Find(id);
            if (bin_Stock == null)
            {
                return HttpNotFound();
            }
            return View(bin_Stock);
        }

        // GET: BinStock/Create
        public ActionResult Create()
        {
            ViewBag.bin_id = new SelectList(db.Bins, "id", "name");
            ViewBag.stock_id = new SelectList(db.Stocks, "id", "name");
            return View();
        }

        // POST: BinStock/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,bin_id,stock_id,quantity,stock_in_date,stock_out_date")] Bin_Stock bin_Stock)
        {
            if (ModelState.IsValid)
            {
                db.Bin_Stock.Add(bin_Stock);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.bin_id = new SelectList(db.Bins, "id", "name", bin_Stock.bin_id);
            ViewBag.stock_id = new SelectList(db.Stocks, "id", "name", bin_Stock.stock_id);
            return View(bin_Stock);
        }

        // GET: BinStock/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bin_Stock bin_Stock = db.Bin_Stock.Find(id);
            if (bin_Stock == null)
            {
                return HttpNotFound();
            }
            ViewBag.bin_id = new SelectList(db.Bins, "id", "name", bin_Stock.bin_id);
            ViewBag.stock_id = new SelectList(db.Stocks, "id", "name", bin_Stock.stock_id);
            return View(bin_Stock);
        }

        // POST: BinStock/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,bin_id,stock_id,quantity,stock_in_date,stock_out_date")] Bin_Stock bin_Stock)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bin_Stock).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.bin_id = new SelectList(db.Bins, "id", "name", bin_Stock.bin_id);
            ViewBag.stock_id = new SelectList(db.Stocks, "id", "name", bin_Stock.stock_id);
            return View(bin_Stock);
        }

        // GET: BinStock/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bin_Stock bin_Stock = db.Bin_Stock.Find(id);
            if (bin_Stock == null)
            {
                return HttpNotFound();
            }
            return View(bin_Stock);
        }

        // POST: BinStock/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bin_Stock bin_Stock = db.Bin_Stock.Find(id);
            db.Bin_Stock.Remove(bin_Stock);
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
