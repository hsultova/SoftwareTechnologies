using System;
using Microsoft.Owin;
using Owin;
using MVCBlog.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

[assembly: OwinStartupAttribute(typeof(MVCBlog.Startup))]
namespace MVCBlog
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
		}
	}
}
