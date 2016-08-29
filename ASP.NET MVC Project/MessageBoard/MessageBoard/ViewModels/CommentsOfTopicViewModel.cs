using MessageBoard.Helpers;
using MessageBoard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MessageBoard.ViewModels
{
	public class CommentsOfTopicViewModel
	{
		public Topic Topic { get; set; }

		public IEnumerable<Comment> Comments { get; set; }
		public Pager Pager { get; set; }
	}
}