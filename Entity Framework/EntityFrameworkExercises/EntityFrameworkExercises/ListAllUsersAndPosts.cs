using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkExercises
{
	class ListAllUsersAndPosts
	{
		static void Main(string[] args)
		{
			BlogDbContext blogDbContext = new BlogDbContext();

			List<Post> posts = blogDbContext.Posts.Select(post => post).ToList();
			List<User> users = blogDbContext.Users.Select(user => user).ToList();

			foreach(Post post in posts)
			{
				Console.WriteLine("Title: {0}", post.Title);
				Console.WriteLine("AuthorId: {0}", post.AuthorId);
				Console.WriteLine("Comments Count: {0}", post.Comments.Count);
				Console.WriteLine("Tags Count: {0}", post.Tags.Count);
				Console.WriteLine();
			}

			foreach (User user in users)
			{
				Console.WriteLine("Id: {0}", user.Id);
				Console.WriteLine("Name: {0}", user.FullName);
				Console.WriteLine("Comments Count: {0}", user.Comments.Count);
				Console.WriteLine("Posts Count: {0}", user.Posts.Count);
				Console.WriteLine();
			}
		}
	}
}
