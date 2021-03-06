﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MessageBoard.Models;
using MessageBoard.Extensions;

namespace MessageBoard.Controllers
{
	public class CategoriesController : Controller
	{
		private ApplicationDbContext db = new ApplicationDbContext();

		// GET: Categories
		[Authorize(Roles = "Administrators")]
		public ActionResult Index()
		{
			var categories = db.Categories.OrderBy(c => c.Name).ThenBy(c => c.Description);
			return View(categories.ToList());
		}

		// GET: Categories/Details/5
		public ActionResult Details(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Category category = db.Categories.Find(id);
			if (category == null)
			{
				return HttpNotFound();
			}
			return View(category);
		}

		// GET: Categories/Create
		[Authorize(Roles = "Administrators")]
		public ActionResult Create()
		{
			return View();
		}

		// POST: Categories/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		[Authorize(Roles = "Administrators")]
		public ActionResult Create([Bind(Include = "Id,Name,Description")] Category category)
		{
			if (ModelState.IsValid)
			{
				db.Categories.Add(category);
				db.SaveChanges();
				this.AddNotification("Category created.", NotificationType.SUCCESS);
				return RedirectToAction("Index");
			}

			return View(category);
		}

		// GET: Categories/Edit/5
		[Authorize(Roles = "Administrators")]
		public ActionResult Edit(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Category category = db.Categories.Find(id);
			if (category == null)
			{
				return HttpNotFound();
			}
			return View(category);
		}

		// POST: Categories/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		[Authorize(Roles = "Administrators")]
		public ActionResult Edit([Bind(Include = "Id,Name,Description")] Category category)
		{
			if (ModelState.IsValid)
			{
				db.Entry(category).State = EntityState.Modified;
				db.SaveChanges();
				this.AddNotification("Category edited.", NotificationType.SUCCESS);
				return RedirectToAction("Index");
			}
			return View(category);
		}

		// GET: Categories/Delete/5
		[Authorize(Roles = "Administrators")]
		public ActionResult Delete(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Category category = db.Categories.Find(id);
			if (category == null)
			{
				return HttpNotFound();
			}
			return View(category);
		}

		// POST: Categories/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		[Authorize(Roles = "Administrators")]
		public ActionResult DeleteConfirmed(int id)
		{
			Category category = db.Categories.Find(id);
			db.Categories.Remove(category);
			db.SaveChanges();
			this.AddNotification("Category deleted.", NotificationType.SUCCESS);
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
