using EntityFrameworkExercises;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelectAuthors
{
	class Program
	{
		static void Main(string[] args)
		{
			BlogDbContext blogDbContext = new BlogDbContext();

			List<User> users = blogDbContext.Users.Select(user => user).Where(user => user.Posts.Count > 0).ToList();

			foreach (var user in users)
			{
				Console.WriteLine("Username: {0}", user.UserName);
				Console.WriteLine("Full Name: {0}", user.FullName);
				Console.WriteLine("Posts Count: {0}", user.Posts.Count);
				Console.WriteLine();
			}
		}
	}
}
