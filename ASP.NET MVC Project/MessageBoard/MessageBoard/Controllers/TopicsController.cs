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
using MessageBoard.ViewModels;
using MessageBoard.Helpers;

namespace MessageBoard.Controllers
{
	public class TopicsController : Controller
	{
		private ApplicationDbContext db = new ApplicationDbContext();

		// GET: Topics
		public ActionResult Index()
		{
			var topics = db.Topics.OrderByDescending(t => t.DateCreated).Include(t => t.Category).Include(t => t.User);
			return View(topics.ToList());
		}

		// GET: Topics/Details/5
		public ActionResult Details(int? id, int? page)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Topic topic = db.Topics.Include(t => t.User).SingleOrDefault(t => t.Id == id);

			foreach (var comment in topic.Comments)
			{
				comment.User = db.Users.FirstOrDefault(u => u.Id == comment.UserId);
			}

			if (topic == null)
			{
				return HttpNotFound();
			}

			var pager = new Pager(topic.Comments.Count(), page);

			var model = new CommentsOfTopicViewModel()
			{
				Topic = topic,
				Comments = topic.Comments.Skip((pager.CurrentPage - 1) * pager.PageSize).Take(pager.PageSize),
				Pager = pager
			};

			return View(model);
		}

		[Authorize]
		[HttpPost]
		public ActionResult AddComment(int id, string text)
		{
			var topic = db.Topics.SingleOrDefault(t => t.Id == id);

			if (text != "")
			{
				var comment = new Comment
				{
					Text = text,
					DateCreated = DateTime.Now,
					TopicId = id,
					UserId = User.Identity.GetUserId(),
				};

				comment.Topic = topic;

				topic.Comments.Add(comment);
				db.SaveChanges();
				this.AddNotification("Comment created.", NotificationType.SUCCESS);
				return RedirectToAction("Details", "Topics", new { id = topic.Id });
			}
			this.AddNotification("Comment text is empty.", NotificationType.ERROR);
			return RedirectToAction("Details", "Topics", new { id = topic.Id });
		}

		// GET: Topics/Create
		[Authorize]
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
		[Authorize]
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
				this.AddNotification("Topic created.", NotificationType.SUCCESS);
				return RedirectToAction("Index");
			}

			ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", topic.CategoryId);
			ViewBag.UserId = new SelectList(db.Users, "Id", "FullName", topic.UserId);
			return View(topic);
		}

		// GET: Topics/Edit/5
		[Authorize(Roles = "Administrators")]
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
		[Authorize(Roles = "Administrators")]
		public ActionResult Edit([Bind(Include = "Id,Title,Content,DateCreated,UserId,CategoryId")] Topic topic)
		{
			if (ModelState.IsValid)
			{
				db.Entry(topic).State = EntityState.Modified;
				db.SaveChanges();
				this.AddNotification("Topic edited.", NotificationType.SUCCESS);
				return RedirectToAction("Index");
			}
			ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", topic.CategoryId);
			ViewBag.UserId = new SelectList(db.Users, "Id", "FullName", topic.UserId);
			return View(topic);
		}

		// GET: Topics/Delete/5
		[Authorize(Roles = "Administrators")]
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
		[Authorize(Roles = "Administrators")]
		public ActionResult DeleteConfirmed(int id)
		{
			Topic topic = db.Topics.Find(id);
			db.Topics.Remove(topic);
			db.SaveChanges();
			this.AddNotification("Topic deleted.", NotificationType.SUCCESS);
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
