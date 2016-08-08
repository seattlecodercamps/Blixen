using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Domain.Models;


/*  FROM current project CMD
 *  dotnet ef --startup-project ../Blixen/ migrations add first
 *  dotnet ef --startup-project ../Blixen/ database update 
 */

namespace Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Camp> Camps { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<CampUnit> CampUnits { get; set; }
        public DbSet<Content> Content { get; set; }
        public DbSet<ContentLesson> Lessons { get; set; }
        public DbSet<Troop> Troops { get; set; }
        public DbSet<Student> Students { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<CampUnit>().HasKey(x => new { x.CampId, x.UnitId });
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
