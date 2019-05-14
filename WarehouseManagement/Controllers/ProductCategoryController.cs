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
    public class ProductCategoryController : Controller
    {
                // GET: ProductCategory
        public ActionResult Index()
        {
            using (var db = new warehouse_managementEntities())
            {
                return View(db.ProductCategories.ToList());
            }
        }

        // GET: ProductCategory/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            using (var db = new warehouse_managementEntities())
            {
                DAL.ProductCategory productCategory = db.ProductCategories.Find(id);
                if (productCategory == null)
                {
                    return HttpNotFound();
                }
                return View(productCategory);
            }
        }

        // GET: ProductCategory/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductCategory/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Description")] DAL.ProductCategory productCategory)
        {
            if (ModelState.IsValid)
            {
                using (var db = new warehouse_managementEntities())
                {
                    db.ProductCategories.Add(productCategory);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            return View(productCategory);
        }

        // GET: ProductCategory/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            using (var db = new warehouse_managementEntities())
            {
                DAL.ProductCategory productCategory = db.ProductCategories.Find(id);
                if (productCategory == null)
                {
                    return HttpNotFound();
                }

                return View(productCategory);
            }
        }

        // POST: ProductCategory/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Description")] DAL.ProductCategory productCategory)
        {
            if (ModelState.IsValid)
            {
                using (var db = new warehouse_managementEntities())
                {
                    db.Entry(productCategory).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
                return View(productCategory);
            
        }

        // GET: ProductCategory/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            using (var db = new warehouse_managementEntities())
            {
                DAL.ProductCategory productCategory = db.ProductCategories.Find(id);
                if (productCategory == null)
                {
                    return HttpNotFound();
                }
                return View(productCategory);
            }
           
        }

        // POST: ProductCategory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            using (var db = new warehouse_managementEntities())
            {
                DAL.ProductCategory productCategory = db.ProductCategories.Find(id);
                db.ProductCategories.Remove(productCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                using (var db = new warehouse_managementEntities())
                {
                    db.Dispose();
                }
            }
            base.Dispose(disposing);
        }
    }
}
