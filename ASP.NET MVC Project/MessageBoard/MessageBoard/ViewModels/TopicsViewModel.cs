using MessageBoard.Helpers;
using MessageBoard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MessageBoard.ViewModels
{
	public class TopicsViewModel
	{
		public IEnumerable<Topic> Topics { get; set; }
		public Pager Pager { get; set; }
	}
}