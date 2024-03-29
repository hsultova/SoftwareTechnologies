﻿using EntityFrameworkExercises;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderByTwoColumns
{
	class Program
	{
		static void Main(string[] args)
		{
			BlogDbContext blogDbContext = new BlogDbContext();

			var users = blogDbContext.Users.Select(user => new
			{ user.UserName, user.FullName })
			.OrderByDescending(user => user.UserName)
			.ThenByDescending(user => user.FullName)
			.ToList();

			foreach (var user in users)
			{
				Console.WriteLine("Username: {0}", user.UserName);
				Console.WriteLine("Full Name: {0}", user.FullName);
				Console.WriteLine();
			}
		}
	}
}
