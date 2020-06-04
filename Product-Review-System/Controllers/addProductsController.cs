using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Product_Review_System.Models;
using WebApplication4.Models;
using System.IO;

namespace Product_Review_System.Controllers
{
    public class addProductsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: addProducts
        public ActionResult Index()
        {
            var addProducts = db.AddProducts.Include(a => a.Category);
            return View(addProducts.ToList());
        }

        // GET: addProducts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            addProduct addProduct = db.AddProducts.Find(id);
            if (addProduct == null)
            {
                return HttpNotFound();
            }
            return View(addProduct);
        }

        // GET: addProducts/Create
        public ActionResult Create()
        {
            ViewBag.category_id = new SelectList(db.Categories, "category_id", "name");
            return View();
        }

        // POST: addProducts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(addProduct addProduct, HttpPostedFileBase upload)
        {

            if (ModelState.IsValid)
            {
                string path = "";
                if (upload.FileName.Length > 0)
                {
                    path = "~/Uploads/" + Path.GetFileName(upload.FileName);
                    upload.SaveAs(Server.MapPath(path));
                }
                addProduct.image = path;
                var categoryindb = db.Categories.Single(c => c.category_id == addProduct.category_id);
                categoryindb.no_of_products++;
                db.AddProducts.Add(addProduct);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return Content("Done");
        }



        // GET: addProducts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            addProduct addProduct = db.AddProducts.Find(id);
            if (addProduct == null)
            {
                return HttpNotFound();
            }
            ViewBag.category_id = new SelectList(db.Categories, "category_id", "name", addProduct.category_id);
            return View(addProduct);
        }

        // POST: addProducts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,price,description,category_id,image")] addProduct addProduct)
        {
            if (ModelState.IsValid)
            {
                db.Entry(addProduct).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.category_id = new SelectList(db.Categories, "category_id", "name", addProduct.category_id);
            return View(addProduct);
        }

        // GET: addProducts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            addProduct addProduct = db.AddProducts.Find(id);
            if (addProduct == null)
            {
                return HttpNotFound();
            }
            return View(addProduct);
        }

        // POST: addProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            addProduct addProduct = db.AddProducts.Find(id);
            db.AddProducts.Remove(addProduct);
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
