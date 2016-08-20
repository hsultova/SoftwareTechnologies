using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MessageBoard.Models
{
	public class Category
	{
		public int Id { get; set; }

		[StringLength(200)]
		public string Name { get; set; }

		public string Description { get; set; }

		public virtual ICollection<Topic> Topics { get; set; }
	}
}