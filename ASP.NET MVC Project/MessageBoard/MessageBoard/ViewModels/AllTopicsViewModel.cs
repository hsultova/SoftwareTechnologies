using MessageBoard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MessageBoard.ViewModels
{
	public class AllTopicsViewModel
	{
		public IEnumerable<Topic> Topics { get; set; }

		public Category Category { get; set; }

		public ApplicationUser Author { get; set; }
	}
}