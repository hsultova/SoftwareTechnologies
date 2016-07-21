using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogDBApp
{
	class Program
	{
		static void Main(string[] args)
		{
			var db = new BlogDbContext();
			var post = new Post()
			{
				Title = "New Title",
				Body = "New Post Body",
				Date = DateTime.Now
			};
			var posts = db.Posts.Select(p => new { p.ID, p.Title, Comments = p.Comments.Count(), Tags = p.Tags.Count() });
			foreach (var user in db.Users)
			{
				Console.WriteLine(user.Username);
			}

			Console.WriteLine("SQL query:\n{0}\n", posts);
			foreach (var p in posts)
			{
				Console.WriteLine($"{p.ID} {p.Title} ({p.Comments} comments, {p.Tags} tags)");

			}

			db.Posts.Add(post);
			db.SaveChanges();
			Console.WriteLine("Post #{0} created.", post.ID);

		}
	}
}
