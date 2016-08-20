using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace MessageBoard.Models
{
	public class ApplicationUser : IdentityUser
	{
		[StringLength(100)]
		[Display(Name ="Full Name")]
		public string FullName { get; set; }

		public virtual ICollection<Topic> Topics { get; set; }

		public virtual ICollection<Comment> Comments { get; set; }
		public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
		{
			var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
			
			return userIdentity;
		}
	}
}