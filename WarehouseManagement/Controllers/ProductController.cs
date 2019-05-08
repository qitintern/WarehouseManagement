using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WarehouseManagement.DAL;
using WarehouseManagement.Models;
using System.Diagnostics;
using Newtonsoft.Json;

namespace WarehouseManagement.Controllers
{
    public class ProductController : Controller
    {
        private WarehouseManagementContext db = new WarehouseManagementContext();

        // GET: Product
        public ActionResult Index()
        {
            var products = db.Products.Include(p => p.Group);
            return View(products.ToList());
        }

        // GET: Product/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            ViewBag.ProductCategoryID = new SelectList(db.productCategories, "ID", "Name");
            ViewBag.GroupID = new SelectList(db.ProductGroups, "ID", "Name");
            return View();
        }

        // POST: Product/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Description,Price,GroupID")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GroupID = new SelectList(db.ProductGroups, "ID", "Name", product.GroupID);
            return View(product);
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.GroupID = new SelectList(db.ProductGroups, "ID", "Name", product.GroupID);
            return View(product);
        }

        // POST: Product/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Description,Price,ProductCategoryID,GroupID")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GroupID = new SelectList(db.ProductGroups, "ID", "Name", product.GroupID);
            return View(product);
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
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

        [HttpGet]
        public JsonResult GetProdGroupList(string id)
        {
            Debug.WriteLine("-------------------------------------------------------Send to debug output.");
           var catId = Int32.Parse(id);
            Debug.WriteLine("Cat id is -----------"+ catId);
            var groupList = db.ProductGroups.Where(s => s.ProductCategoryID == catId).ToArray();     
            //Debug.WriteLine("The count is"+groupList.Count);
            Debug.WriteLine("--------------------------"+Json(groupList));

            var groupMap = new Dictionary<string, string>();
            foreach (ProductGroup value in groupList)
            {
                var idgroup = value.ID.ToString();
                groupMap.Add(idgroup, value.Name);

            }
            //JsonConvert.SerializeObject(groupList);
            return Json(groupMap, JsonRequestBehavior.AllowGet);
            
        }
    }
}
