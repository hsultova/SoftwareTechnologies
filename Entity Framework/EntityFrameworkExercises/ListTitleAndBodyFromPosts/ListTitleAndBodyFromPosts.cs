﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkExercises
{
	class ListTitleAndBodyFromPosts
	{
		static void Main(string[] args)
		{
			BlogDbContext blogDbContext = new BlogDbContext();

			var posts = blogDbContext.Posts.Select(post => new { post.Title, post.Body }).ToList();

			foreach(var post in posts)
			{
				Console.WriteLine("Title: {0}", post.Title);
				Console.WriteLine("Content: {0}", post.Body);
				Console.WriteLine();
			}
		}
	}
}
