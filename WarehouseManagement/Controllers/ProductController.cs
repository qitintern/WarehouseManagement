using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Diagnostics;
using Newtonsoft.Json;
using WarehouseManagement.DAL;

namespace WarehouseManagement.Controllers
{
    public class ProductController : Controller
    {

        // GET: Product
        public ActionResult Index()
        {
            using (var db = new warehouse_managementEntities()) { 
            var products = db.Products;
            return View(products.ToList());
        }
        }

         // GET: Product/Details/5
         public ActionResult Details(int? id)
         {
             if (id == null)
             {
                 return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
             }
            using (var db = new warehouse_managementEntities())
            {
                DAL.Product product = db.Products.Find(id);
                if (product == null)
                {
                    return HttpNotFound();
                }
                return View(product);
            }
         }

         // GET: Product/Create
         public ActionResult Create()
         {
            using (var db = new warehouse_managementEntities())
            {
                ViewBag.ProductCategoryID = new SelectList(db.ProductCategories, "ID", "Name").ToList();
                ViewBag.GroupID = new SelectList(db.ProductGroups, "ID", "Name").ToList();
                return View();
            }
         }

         // POST: Product/Create
         // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
         // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
         [HttpPost]
         [ValidateAntiForgeryToken]
         public ActionResult Create(DAL.Product model)
         {
            using (var db = new warehouse_managementEntities())
            {
                if (ModelState.IsValid)
                {
                    db.Products.Add(model);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                ViewBag.GroupID = new SelectList(db.ProductGroups, "ID", "Name", model.ProductGroupID).ToList();
                return View(model);
            }
         }

         // GET: Product/Edit/5
         public ActionResult Edit(int? id)
         {
             if (id == null)
             {
                 return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
             }
            DAL.Product product;
            using (var db = new warehouse_managementEntities())
            {
                 product= db.Products.Find(id);
                if (product == null)
                {
                    return HttpNotFound();
                }
               
            }
            using (var db = new warehouse_managementEntities())
            {
                ViewBag.GroupID = new SelectList(db.ProductGroups, "ID", "Name", product.ProductGroupID).ToList();
                return View(product);
            }
        }

        // POST: Product/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Description,Price,ProductCategoryID,GroupID")] DAL.Product product)
        {
            using (var db = new warehouse_managementEntities())
            {
                if (ModelState.IsValid)
                {
                    db.Entry(product).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                ViewBag.GroupID = new SelectList(db.ProductGroups, "ID", "Name", product.ProductGroupID).ToList();
                return View(product);
            }
        }

         // GET: Product/Delete/5
         public ActionResult Delete(int? id)
         {
             if (id == null)
             {
                 return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
             }
            using (var db = new warehouse_managementEntities())
            {
                DAL.Product product = db.Products.Find(id);
                if (product == null)
                {
                    return HttpNotFound();
                }

                return View(product);
            }
         }

         // POST: Product/Delete/5
         [HttpPost, ActionName("Delete")]
         [ValidateAntiForgeryToken]
         public ActionResult DeleteConfirmed(int id)
         {
            using (var db = new warehouse_managementEntities())
            {
                DAL.Product product = db.Products.Find(id);
                db.Products.Remove(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
         }

         /*protected override void Dispose(bool disposing)
         {
            using (var db = new warehouse_managementEntities1())
            {
                if (disposing)
                {
                    db.Dispose();
                }
                base.Dispose(disposing);
            }
         }  */

         [HttpGet]
         public JsonResult GetProdGroupList(string id)
         {
            using (var db = new warehouse_managementEntities())
            {
                Debug.WriteLine("-------------------------------------------------------Send to debug output.");
                var catId = Int32.Parse(id);
                Debug.WriteLine("Cat id is -----------" + catId);
                var groupList = db.ProductGroups.Where(s => s.ProductCategoryID == catId).ToArray();
                //Debug.WriteLine("The count is"+groupList.Count);
                Debug.WriteLine("--------------------------" + Json(groupList));

                var groupMap = new Dictionary<string, string>();
                foreach (DAL.ProductGroup value in groupList)
                {
                    var idgroup = value.ID.ToString();
                    groupMap.Add(idgroup, value.Name);

                }
                //JsonConvert.SerializeObject(groupList);
                return Json(groupMap, JsonRequestBehavior.AllowGet);
            }

         }
     } 
    
}