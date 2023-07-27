using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using WebApi.Entities;

namespace WebApi.Data
{
    //public class ApplicationDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
    public class ApplicationDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //     base.OnModelCreating(builder);
            //     builder.Entity<User>()
            //.HasOne(u => u.Address)
            //.WithOne()
            //.HasForeignKey<User>(u => u.AddressId);

            //     builder.Entity<User>()
            //       .HasOne(u => u.Company)
            //       .WithMany()
            //       .HasForeignKey(u => u.CompanyId);


        }
    }
}
