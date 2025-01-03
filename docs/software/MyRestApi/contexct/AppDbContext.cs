using Microsoft.EntityFrameworkCore;
using MyRestApi.models;

namespace MyRestApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Media> Media { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<CommentModeration> CommentModerations { get; set; }
        public DbSet<DeleteAccount> DeleteAccounts { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Налаштування для таблиці Media
            modelBuilder.Entity<Media>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Title).HasMaxLength(45);
                entity.Property(e => e.Keywords).HasMaxLength(45);
                entity.HasOne(e => e.User).WithMany(u => u.Media).HasForeignKey(e => e.UserId);
            });

            // Налаштування для таблиці CommentModeration
            modelBuilder.Entity<CommentModeration>(entity =>
            {
                entity.HasKey(e => e.CommentId);
                entity.HasOne(e => e.User).WithMany(u => u.CommentModerations).HasForeignKey(e => e.UserId);
                entity.HasOne(e => e.Moderator).WithMany(a => a.CommentModerations).HasForeignKey(e => e.ModeratorId);
            });

            // Налаштування для таблиці DeleteAccount
            modelBuilder.Entity<DeleteAccount>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasOne(e => e.Admin).WithMany(a => a.DeleteAccounts).HasForeignKey(e => e.AdminId);
            });

            // Налаштування для таблиці UserRole
            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.HasKey(e => e.UserId);
                entity.HasOne(e => e.User).WithMany(u => u.UserRoles).HasForeignKey(e => e.UserId1);
                entity.HasOne(e => e.Role).WithMany(r => r.UserRoles).HasForeignKey(e => e.RoleId);
            });
        }
    }
}

