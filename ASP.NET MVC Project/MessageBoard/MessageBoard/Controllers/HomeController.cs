using MessageBoard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace MessageBoard.Controllers
{
	public class HomeController : Controller
	{
		private ApplicationDbContext db = new ApplicationDbContext();
		public ActionResult Index(string search)
		{
			var topics = db.Topics.Select(t => t).Include(t => t.Category);

			if (!String.IsNullOrEmpty(search))
			{

				topics = topics.Where(s => s.Title.Contains(search));
			}

			return View(topics);
		}

		public ActionResult Sidebar()
		{
			var categories = db.Categories.ToList();
			return PartialView(categories);
		}
	}
}