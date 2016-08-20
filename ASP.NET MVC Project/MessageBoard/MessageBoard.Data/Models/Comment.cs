using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MessageBoard.Models
{
	public class Comment
	{
		public int Id { get; set; }

		[Required]
		public string Text { get; set; }

		[Display(Name = "Date Created")]
		[Column(TypeName = "datetime2")]
		public DateTime DateCreated { get; set; }

		public string UserId { get; set; }

		public int TopicId { get; set; }

		public ApplicationUser User { get; set; }

		public Topic Topic { get; set; }
	}
}