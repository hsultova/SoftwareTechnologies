using EntityFrameworkExercises;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelectAuthorOfSpecificPost
{
	class Program
	{
		static void Main(string[] args)
		{
			BlogDbContext blogDbContext = new BlogDbContext();

			//var author = blogDbContext.Users.SelectMany(user => user.Posts, (user, post) => new { user.UserName, user.FullName });

			Console.WriteLine(blogDbContext.Posts.Find(4).User.FullName);
		}
	}
}
