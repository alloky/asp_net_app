using System;
using System.Collections.Generic;
using System.Text;
using ASP_net_web_app.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ASP_net_web_app.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<NewsViewModel> News { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
