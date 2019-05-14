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
    public class ProductGroupController : Controller
    {

        // GET: ProductGroup
        public ActionResult Index()
        {
            using (var db = new warehouse_managementEntities())
            {
                var productGroups = db.ProductGroups.Include(p => p.ProductCategory);
                return View(productGroups.ToList());
            }
        }

        // GET: ProductGroup/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            using (var db = new warehouse_managementEntities())
            {
                DAL.ProductGroup productGroup = db.ProductGroups.Find(id);
                if (productGroup == null)
                {
                    return HttpNotFound();
                }
                return View(productGroup);
            }
        }

        // GET: ProductGroup/Create
        public ActionResult Create()
        {
            using (var db = new warehouse_managementEntities())
            {
                ViewBag.ProductCategoryID = (new SelectList(db.ProductCategories, "ID", "Name")).ToList();
                return View();
            }
        }

        // POST: ProductGroup/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Description,ProductCategoryID")] DAL.ProductGroup productGroup)
        {
            if (ModelState.IsValid)
            {
                using (var db = new warehouse_managementEntities())
                {
                    db.ProductGroups.Add(productGroup);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            using (var db = new warehouse_managementEntities())
            {

                ViewBag.ProductCategoryID = new SelectList(db.ProductCategories, "ID", "Name", productGroup.ProductCategoryID);
                return View(productGroup);
            }
        }

        // GET: ProductGroup/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            using (var db = new warehouse_managementEntities())
            {
                DAL.ProductGroup productGroup = db.ProductGroups.Find(id);
                if (productGroup == null)
                {
                    return HttpNotFound();
                }
                ViewBag.ProductCategoryID = new SelectList(db.ProductCategories, "ID", "Name", productGroup.ProductCategoryID);
                return View(productGroup);
            }
        }

        // POST: ProductGroup/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Description,ProductCategoryID")] DAL.ProductGroup productGroup)
        {
            if (ModelState.IsValid)
            {
                using (var db = new warehouse_managementEntities())
                {
                    db.Entry(productGroup).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            using (var db = new warehouse_managementEntities())
            {
                ViewBag.ProductCategoryID = new SelectList(db.ProductCategories, "ID", "Name", productGroup.ProductCategoryID);
                return View(productGroup);
            }
        }
            
        

        // GET: ProductGroup/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            using (var db = new warehouse_managementEntities())
            {
                DAL.ProductGroup productGroup = db.ProductGroups.Find(id);
                if (productGroup == null)
                {
                    return HttpNotFound();
                }
                return View(productGroup);
            }
        }

        // POST: ProductGroup/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            using (var db = new warehouse_managementEntities())
            {
                DAL.ProductGroup productGroup = db.ProductGroups.Find(id);
                db.ProductGroups.Remove(productGroup);
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
