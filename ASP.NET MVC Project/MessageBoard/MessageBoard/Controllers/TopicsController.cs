﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MessageBoard.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MessageBoard.Controllers
{
	public class TopicsController : Controller
	{
		private ApplicationDbContext db = new ApplicationDbContext();

		// GET: Topics
		public ActionResult Index()
		{
			var topics = db.Topics.Include(t => t.Category).Include(t => t.User);
			return View(topics.ToList());
		}

		// GET: Topics/Details/5
		public ActionResult Details(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Topic topic = db.Topics.Include(t => t.User).Single(t => t.Id == id);
			if (topic == null)
			{
				return HttpNotFound();
			}
			return View(topic);
		}

		// GET: Topics/Create
		public ActionResult Create()
		{
			ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name");
			ViewBag.UserId = new SelectList(db.Users, "Id", "FullName");
			return View();
		}

		// POST: Topics/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create([Bind(Include = "Id,Title,Content,UserId,CategoryId")] Topic topic)
		{
			if (ModelState.IsValid)
			{
				topic.DateCreated = DateTime.Now;
				UserManager<ApplicationUser> UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
				ApplicationUser user = UserManager.FindById(User.Identity.GetUserId());
				topic.User = user;

				db.Topics.Add(topic);
				db.SaveChanges();
				return RedirectToAction("Index");
			}

			ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", topic.CategoryId);
			ViewBag.UserId = new SelectList(db.Users, "Id", "FullName", topic.UserId);
			return View(topic);
		}

		// GET: Topics/Edit/5
		public ActionResult Edit(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Topic topic = db.Topics.Find(id);
			if (topic == null)
			{
				return HttpNotFound();
			}

			ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", topic.CategoryId);
			ViewBag.UserId = new SelectList(db.Users, "Id", "FullName", topic.UserId);

			return View(topic);
		}

		// POST: Topics/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit([Bind(Include = "Id,Title,Content,DateCreated,UserId,CategoryId")] Topic topic)
		{
			if (ModelState.IsValid)
			{
				db.Entry(topic).State = EntityState.Modified;
				db.SaveChanges();
				return RedirectToAction("Index");
			}
			ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", topic.CategoryId);
			ViewBag.UserId = new SelectList(db.Users, "Id", "FullName", topic.UserId);
			return View(topic);
		}

		// GET: Topics/Delete/5
		public ActionResult Delete(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Topic topic = db.Topics.Find(id);
			if (topic == null)
			{
				return HttpNotFound();
			}
			return View(topic);
		}

		// POST: Topics/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(int id)
		{
			Topic topic = db.Topics.Find(id);
			db.Topics.Remove(topic);
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
