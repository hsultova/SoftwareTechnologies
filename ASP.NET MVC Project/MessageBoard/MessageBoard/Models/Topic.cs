using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MessageBoard.Models
{
	public class Topic
	{
		public int Id { get; set; }

		[Required]
		[StringLength(200)]
		public string Title { get; set; }

		public string Content { get; set; }

		[Display(Name ="Date Created")]
		public DateTime DateCreated { get; set; }

		public string UserId { get; set; }

		public int CategoryId { get; set; }

		public ApplicationUser User { get; set; }

		public Category Category { get; set; }

		public virtual ICollection<Comment> Comments { get; set; }
	}
}