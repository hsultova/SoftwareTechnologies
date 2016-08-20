using System;
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
using MessageBoard.Extensions;

namespace MessageBoard.Controllers
{
	public class CommentsController : Controller
	{
		private ApplicationDbContext db = new ApplicationDbContext();

		// GET: Comments/Edit/5
		public ActionResult Edit(int? id)
		{

			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Comment comment = db.Comments.Find(id);
			if (comment == null)
			{
				return HttpNotFound();
			}
			ViewBag.TopicId = new SelectList(db.Topics, "Id", "Title", comment.TopicId);
			ViewBag.UserId = new SelectList(db.Users, "Id", "FullName", comment.UserId);
			if (User.Identity.GetUserId() == comment.UserId)
			{
				return View(comment);
			}
			else
			{
				this.AddNotification("You don't have rights to change this comment.", NotificationType.INFO);
				return RedirectToAction("Details", "Topics", new { id = comment.TopicId });
			}
		}

		// POST: Comments/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit([Bind(Include = "Id,Text,DateCreated,UserId,TopicId")] Comment comment)
		{
			if (ModelState.IsValid)
			{
				db.Entry(comment).State = EntityState.Modified;
				db.SaveChanges();
				this.AddNotification("Comment edited.", NotificationType.SUCCESS);
				return RedirectToAction("Details", "Topics", new { id = comment.TopicId });
			}
			ViewBag.TopicId = new SelectList(db.Topics, "Id", "Title", comment.TopicId);
			ViewBag.UserId = new SelectList(db.Users, "Id", "FullName", comment.UserId);
			return View(comment);
		}

		// GET: Comments/Delete/5
		public ActionResult Delete(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Comment comment = db.Comments.Find(id);
			if (comment == null)
			{
				return HttpNotFound();
			}
			return View(comment);
		}

		// POST: Comments/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(int id)
		{
			Comment comment = db.Comments.Find(id);
			db.Comments.Remove(comment);
			db.SaveChanges();
			this.AddNotification("Comment deleted.", NotificationType.SUCCESS);
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
