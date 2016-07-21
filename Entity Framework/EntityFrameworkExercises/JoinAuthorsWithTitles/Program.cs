using EntityFrameworkExercises;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoinAuthorsWithTitles
{
	class Program
	{
		static void Main(string[] args)
		{
			BlogDbContext blogDbContext = new BlogDbContext();

			var users = blogDbContext.Users.SelectMany(user => user.Posts, (user, post) => new { user.UserName, post.Title });

			foreach (var user in users)
			{
				Console.WriteLine("Username: {0}", user.UserName);
				Console.WriteLine("Post Title: {0}", user.Title);
				Console.WriteLine();
			}
		}
	}
}
