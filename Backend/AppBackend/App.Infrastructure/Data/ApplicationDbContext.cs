using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using App.Application.Common.Interfaces.Services;
using App.Domain.Entities;
using App.Infrastructure.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace App.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
    {
        //private readonly IDateTimeProvider _dateTimeProvider;
        //private readonly ConnectionStrings _connectionStrings;


        //public ApplicationDbContext(IOptions<ConnectionStrings> connectionStrings)
        //{
        //    _connectionStrings = connectionStrings;
        //}

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    base.OnConfiguring(optionsBuilder);
        //    var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        //    var connectionString = config.GetSection(ConnectionStrings.connMSSQL).Value;
        //    optionsBuilder.UseSqlServer(connectionString);
        //}
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Geo> Geos { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<User>()
       .HasOne(u => u.Address)
       .WithOne()
       .HasForeignKey<User>(u => u.AddressId);

            builder.Entity<User>()
              .HasOne(u => u.Company)
              .WithMany()
              .HasForeignKey(u => u.CompanyId);

            // Define IdentityUserLogin as a keyless entity type
            //builder.Entity<IdentityUserLogin<string>>().HasNoKey();
        }




    }
}
