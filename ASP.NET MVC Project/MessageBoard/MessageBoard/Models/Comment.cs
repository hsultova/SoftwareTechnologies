using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
		public DateTime DateCreated { get; set; }

		public string UserId { get; set; }

		public int TopicId { get; set; }
	}
}