using EntityFrameworkExercises;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateAndUpdateData
{
	class Program
	{
		static void Main(string[] args)
		{
			BlogDbContext blogDbContext = new BlogDbContext();

			Post post = new Post()
			{
				AuthorId = 2,
				Title = "Random Title",
				Body = "Random Content",
				Date = DateTime.Now
			};

			User userInfo = blogDbContext.Users.Single(user => user.UserName == "GBotev");

			blogDbContext.Posts.Add(post);

			string oldName = userInfo.FullName;
			userInfo.FullName = "Georgi Botev";
			
			blogDbContext.SaveChanges();

			Console.WriteLine("Post #{0} Created!", post.Id);
			Console.WriteLine("User {0} has been renamed to {1}", oldName, userInfo.FullName);
		}
	}
}
