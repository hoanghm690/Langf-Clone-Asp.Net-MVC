﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using langfvn.Models;

namespace langfvn.Areas.admin.Controllers
{
    public class CategoryNewsController : Controller
    {
        private LangfvnContext db = new LangfvnContext();

        // GET: admin/categorynews
        public ActionResult Index()
        {
            return View(db.CategoryNews.ToList());
        }

        // GET: admin/categorynews/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoryNew categoryNew = db.CategoryNews.Find(id);
            if (categoryNew == null)
            {
                return HttpNotFound();
            }
            return View(categoryNew);
        }

        // GET: admin/categorynews/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: admin/categorynews/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CNewsID,CNewsName,CreatedDate")] CategoryNew categoryNew)
        {
            if (ModelState.IsValid)
            {
                categoryNew.CreatedDate = DateTime.Now;
                db.CategoryNews.Add(categoryNew);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(categoryNew);
        }

        // GET: admin/categorynews/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoryNew categoryNew = db.CategoryNews.Find(id);
            if (categoryNew == null)
            {
                return HttpNotFound();
            }
            return View(categoryNew);
        }

        // POST: admin/categorynews/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CNewsID,CNewsName,CreatedDate")] CategoryNew categoryNew)
        {
            if (ModelState.IsValid)
            {
                categoryNew.CreatedDate = DateTime.Now;
                db.Entry(categoryNew).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(categoryNew);
        }

        // GET: admin/categorynews/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoryNew categoryNew = db.CategoryNews.Find(id);
            if (categoryNew == null)
            {
                return HttpNotFound();
            }
            return View(categoryNew);
        }

        // POST: admin/categorynews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CategoryNew categoryNew = db.CategoryNews.Find(id);
            db.CategoryNews.Remove(categoryNew);
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
