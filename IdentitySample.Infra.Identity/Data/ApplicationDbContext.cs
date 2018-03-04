using IdentitySample.CrossCutting.Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace IdentitySample.Infra.Identity.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory())
                 .AddJsonFile("appsettings.json")
                 .Build();

            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            //builder.Properties<string>()
            //    .Configure(p => p.HasColumnType("varchar"));

            //builder.Properties<string>()
            //    .Configure(p => p.HasMaxLength(150));

            //foreach (var pb in builder.Model
            //                    .GetEntityTypes()
            //                    .SelectMany(t => t.GetProperties())
            //                    .Where(p => p.ClrType == typeof(string))
            //                    .Select(p => builder.Entity(p.DeclaringEntityType.ClrType).Property(p.Name)))
            //{
            //    pb.HasColumnType("varchar(150)");
            //}
            base.OnModelCreating(builder);
        }


    }
}
