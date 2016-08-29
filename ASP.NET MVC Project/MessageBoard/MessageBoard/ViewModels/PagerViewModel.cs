using MessageBoard.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MessageBoard.ViewModels
{
	public class PagerViewModel
	{
		public Pager Pager { get; set; }

		public int? TopicId { get; set; }
	}
}