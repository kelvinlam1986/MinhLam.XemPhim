using Microsoft.EntityFrameworkCore;
using MinhLam.XemPhim.Domain.Entities;
using MinhLam.XemPhim.Infrastructure.DbConfiguration;

namespace MinhLam.XemPhim.Infrastructure
{
    public class MovieContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<AccountGroup> AccountGroups { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<GroupRoles> GroupRoles { get; set; }
        public DbSet<UserRoles> UserRoles { get; set; }
        public DbSet<About> Abouts { get; set; }

        public MovieContext(DbContextOptions<MovieContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new AccountConfiguration().Configure(modelBuilder.Entity<Account>());
            new AccountGroupConfiguration().Configure(modelBuilder.Entity<AccountGroup>());
            new RoleConfiguration().Configure(modelBuilder.Entity<Role>());
            new GroupRolesConfiguration().Configure(modelBuilder.Entity<GroupRoles>());
            new AboutConfiguration().Configure(modelBuilder.Entity<About>());
        }
    }
}
