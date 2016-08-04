namespace MessageBoard.Migrations
{
	using Microsoft.AspNet.Identity;
	using Microsoft.AspNet.Identity.EntityFramework;
	using Models;
	using System;
	using System.Collections.Generic;
	using System.Data.Entity.Migrations;
	using System.Linq;

	internal sealed class Configuration : DbMigrationsConfiguration<MessageBoard.Models.ApplicationDbContext>
	{
		//private List<ApplicationUser> _users;
		//private List<Category> _categories;
		//private List<Topic> _topics;
		public Configuration()
		{
			AutomaticMigrationsEnabled = true;
			AutomaticMigrationDataLossAllowed = true;
			ContextKey = "MessageBoard.Models.ApplicationDbContext";
		}

		protected override void Seed(ApplicationDbContext context)
		{
			if (!context.Users.Any())
			{
				//_users = new List<ApplicationUser>();
				//_categories = new List<Category>();
				//_topics = new List<Topic>();

				CreateUser(context, "admin@gmail.com", "123123", "System Administrator");
				CreateUser(context, "ivan@gmail.com", "123456", "Ivan Ivanov");
				CreateUser(context, "maria@gmail.com", "123456", "Maria Georgieva");
				CreateUser(context, "gpetrov@gmail.com", "123456", "Georgi Petrov");

				CreateRole(context, "Administrators");
				AddUserToRole(context, "admin@gmail.com", "Administrators");

				CreateCategory(context,
					name: "Board Games",
					description: "A board game is a tabletop game that involves counters or pieces moved or placed on a pre-marked surface or board, according to a set of rules. Some games are based on pure strategy, but many contain an element of chance; and some are purely chance, with no element of skill.Games usually have a goal that a player aims to achieve. Early board games represented a battle between two armies, and most modern board games are still based on defeating opposing players in terms of counters, winning position, or accrual of points."
				);

				CreateCategory(context,
						name: "PS4",
						description: "Talks about PS4"
					);

				CreateCategory(context,
					name: "PC Games",
					description: ""
					);

				context.SaveChanges();

				CreateTopic(context, "Dixit",
					@"Has there ever been a recorded case of Dixit cards mating and spawning new cards on their own? I've been playing for years and 
					I swear there are cards in the box I've never seen before....Love this game!",
					new DateTime(2016, 7, 30),
					"ivan@gmail.com",
					"Board Games");

				CreateTopic(context, "Cards worth disenchanting for sure",
					@"Hi, I'm fairly new to heartstone and I was wandering if someone could 
					make a list of the cards that are so terrible that they are almost always worth disenchanting because they don't fint any competitve constructed deck and never will. I appreciate the help of anyone who is willing to help making this a guide to noob player like me :)",
					new DateTime(2016, 6, 5),
					"gpetrov@gmail.com",
					"PC Games");

				context.SaveChanges();

				CreateComment(context, "I keep all cards unless I get gold ones, then I disenchant one of the non-gold ones (slowly working towards a full golden set of cards).",
					new DateTime(2016, 6, 5),
					"maria@gmail.com",
					"Cards worth disenchanting for sure");

				CreateComment(context, "That's what I've been doing as well... tbh though, I've got a feeling that's never gonna happen.",
				new DateTime(2016, 6, 6),
				"ivan@gmail.com",
				"Cards worth disenchanting for sure");

				context.SaveChanges();
			}
		}

		private ApplicationUser CreateUser(ApplicationDbContext context,
			string email, string password, string fullName)
		{
			var userManager = new UserManager<ApplicationUser>(
				new UserStore<ApplicationUser>(context));
			userManager.PasswordValidator = new PasswordValidator
			{
				RequiredLength = 6,
				RequireNonLetterOrDigit = false,
				RequireDigit = false,
				RequireLowercase = false,
				RequireUppercase = false,
			};

			var user = new ApplicationUser
			{
				UserName = email,
				Email = email,
				FullName = fullName
			};

			var userCreateResult = userManager.Create(user, password);
			if (!userCreateResult.Succeeded)
			{
				throw new Exception(string.Join("; ", userCreateResult.Errors));
			}

			return user;
		}

		private void CreateRole(ApplicationDbContext context, string roleName)
		{
			var roleManager = new RoleManager<IdentityRole>(
				new RoleStore<IdentityRole>(context));
			var roleCreateResult = roleManager.Create(new IdentityRole(roleName));
			if (!roleCreateResult.Succeeded)
			{
				throw new Exception(string.Join("; ", roleCreateResult.Errors));
			}
		}

		private void AddUserToRole(ApplicationDbContext context, string userName, string roleName)
		{
			var user = context.Users.First(u => u.UserName == userName);
			var userManager = new UserManager<ApplicationUser>(
				new UserStore<ApplicationUser>(context));
			var addAdminRoleResult = userManager.AddToRole(user.Id, roleName);
			if (!addAdminRoleResult.Succeeded)
			{
				throw new Exception(string.Join("; ", addAdminRoleResult.Errors));
			}
		}

		private Category CreateCategory(ApplicationDbContext context, string name, string description)
		{
			var category = new Category();
			category.Name = name;
			category.Description = description;
			context.Categories.Add(category);

			return category;
		}

		private Topic CreateTopic(ApplicationDbContext context, string title,
			string content, DateTime date, string username, string categoryName)
		{
			var topic = new Topic();
			topic.Title = title;
			topic.Content = content;
			topic.DateCreated = date;
			topic.User = context.Users.Where(u => u.UserName == username).FirstOrDefault(); ;
			topic.Category = context.Categories.Where(c => c.Name == categoryName).FirstOrDefault();
			context.Topics.Add(topic);

			return topic;
		}

		private void CreateComment(ApplicationDbContext context, string text, DateTime date, string username, string topicTitle)
		{
			var comment = new Comment();
			comment.Text = text;
			comment.DateCreated = date;
			comment.User = context.Users.Where(u => u.UserName == username).FirstOrDefault();
			comment.Topic = context.Topics.Where(t => t.Title == topicTitle).FirstOrDefault();
			context.Comments.Add(comment);
		}
	}
}
