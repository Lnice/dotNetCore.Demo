using Maid.Context.Tables;
using Microsoft.EntityFrameworkCore;

namespace Maid.Context
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Role(modelBuilder);
            User(modelBuilder);
            UserRole(modelBuilder);
            Menu(modelBuilder);
            MenuRole(modelBuilder);
            Oper(modelBuilder);
            OperRole(modelBuilder);
            LogUser(modelBuilder);
            LogOper(modelBuilder);
        }

        private void LogOper(ModelBuilder modelBuilder)
        {
            var operBuilder = modelBuilder.Entity<Log_Oper>().ToTable("Log_Oper");
            // Properties
            operBuilder.Property(t => t.Time).IsRequired();
            operBuilder.Property(t => t.UId).IsRequired();
            operBuilder.Property(t => t.IP).HasMaxLength(15);
            operBuilder.Property(t => t.Request).HasMaxLength(100);
            operBuilder.Property(t => t.Result).HasMaxLength(100);
            // Primary Key
            operBuilder.HasKey(t => t.UId);
            // Index
            operBuilder.HasIndex(t => t.Time);
        }

        private void LogUser(ModelBuilder modelBuilder)
        {
            var userBuilder = modelBuilder.Entity<Log_User>().ToTable("Log_User");
            // Properties
            userBuilder.Property(t => t.Time);
            userBuilder.Property(t => t.UId).IsRequired();
            userBuilder.Property(t => t.Name).HasMaxLength(20);
            userBuilder.Property(t => t.Sex);
            userBuilder.Property(t => t.Birthday).HasMaxLength(10);
            userBuilder.Property(t => t.Address).HasMaxLength(100);
            // Primary Key
            userBuilder.HasKey(t => t.UId);
            // Index
            userBuilder.HasIndex(t => t.Name);
        }

        private void OperRole(ModelBuilder modelBuilder)
        {
            var orBuilder = modelBuilder.Entity<Info_OperRole>().ToTable("Info_OperRole");
            // Properties
            orBuilder.Property(t => t.Id).ValueGeneratedOnAdd();
            orBuilder.Property(t => t.OperId).IsRequired();
            orBuilder.Property(t => t.RoleId).IsRequired();
            // Primary Key
            orBuilder.HasKey(t => t.Id);
            // Relationships
            orBuilder.HasOne(t => t.Oper).WithMany(t => t.Roles).HasForeignKey(t => t.OperId);
            orBuilder.HasOne(t => t.Role).WithMany(t => t.Opers).HasForeignKey(t => t.RoleId);
        }

        private void Oper(ModelBuilder modelBuilder)
        {
            var opBuilder = modelBuilder.Entity<Info_Oper>().ToTable("Info_Oper");
            // Properties
            opBuilder.Property(t => t.Id).ValueGeneratedOnAdd();
            opBuilder.Property(t => t.MenuId).IsRequired();
            opBuilder.Property(t => t.Name).IsRequired().HasMaxLength(30);
            // Primary Key
            opBuilder.HasKey(t => t.Id);
            // Relationships
            opBuilder.HasOne(t => t.Menu).WithMany(t => t.Opers).HasForeignKey(t => t.MenuId);
        }

        private void MenuRole(ModelBuilder modelBuilder)
        {
            var mrBuilder = modelBuilder.Entity<Info_MenuRole>().ToTable("Info_MenuRole");
            // Properties
            mrBuilder.Property(t => t.Id).ValueGeneratedOnAdd();
            mrBuilder.Property(t => t.MenuId).IsRequired();
            mrBuilder.Property(t => t.RoleId).IsRequired();
            // Primary Key
            mrBuilder.HasKey(t => t.Id);
            // Relationships
            mrBuilder.HasOne(t => t.Menu).WithMany(t => t.Roles).HasForeignKey(t => t.MenuId);
            mrBuilder.HasOne(t => t.Role).WithMany(t => t.Menus).HasForeignKey(t => t.RoleId);
        }

        private void Menu(ModelBuilder modelBuilder)
        {
            var menuBuilder = modelBuilder.Entity<Info_Menu>().ToTable("Info_Menu");
            // Properties
            menuBuilder.Property(t => t.Id).ValueGeneratedOnAdd();
            menuBuilder.Property(t => t.Fid).IsRequired();
            menuBuilder.Property(t => t.Name).IsRequired().HasMaxLength(30);
            menuBuilder.Property(t => t.Href).HasMaxLength(100);
            menuBuilder.Property(t => t.Sort);
            // Primary Key
            menuBuilder.HasKey(t => t.Id);
            // Index
            menuBuilder.HasIndex(t => t.Fid);
        }

        private void UserRole(ModelBuilder modelBuilder)
        {
            var urBuilder = modelBuilder.Entity<Info_UserRole>().ToTable("Info_UserRole");
            // Properties
            urBuilder.Property(t => t.Id).ValueGeneratedOnAdd();
            urBuilder.Property(t => t.UserId).IsRequired();
            urBuilder.Property(t => t.RoleId).IsRequired();
            // Primary Key
            urBuilder.HasKey(t => t.Id);
            // Relationships
            urBuilder.HasOne(t => t.User).WithMany(t => t.Roles).HasForeignKey(t => t.UserId);
            urBuilder.HasOne(t => t.Role).WithMany(t => t.Users).HasForeignKey(t => t.RoleId);
        }

        private void User(ModelBuilder modelBuilder)
        {
            var userBuilder = modelBuilder.Entity<Info_User>().ToTable("Info_User");
            // Properties
            userBuilder.Property(t => t.Id).ValueGeneratedOnAdd();
            userBuilder.Property(t => t.LoginId).IsRequired().HasMaxLength(30);
            userBuilder.Property(t => t.Pwd).IsRequired().HasMaxLength(60);
            userBuilder.Property(t => t.Mobile).HasMaxLength(13);
            userBuilder.Property(t => t.Email).HasMaxLength(30);
            userBuilder.Property(t => t.Code).HasMaxLength(18);
            userBuilder.Property(t => t.Photo).HasMaxLength(100);
            userBuilder.Property(t => t.Status).IsRequired().HasDefaultValue(1);
            // Primary Key
            userBuilder.HasKey(t => t.Id);
            // Index
            userBuilder.HasIndex(t => t.LoginId);
            userBuilder.HasIndex(t => t.Mobile);
            userBuilder.HasIndex(t => t.Email);
            userBuilder.HasIndex(t => t.Code);
            userBuilder.HasIndex(t => t.Photo);
        }

        private void Role(ModelBuilder modelBuilder)
        {
            var roleBuilder = modelBuilder.Entity<Info_Role>().ToTable("Info_Role");
            // Properties
            roleBuilder.Property(t => t.Id).ValueGeneratedOnAdd();
            roleBuilder.Property(t => t.Name).IsRequired().HasMaxLength(30);
            roleBuilder.Property(t => t.Sort).IsRequired();
            // Primary Key
            roleBuilder.HasKey(t => t.Id);
        }

        public DbSet<Info_Role> Roles { get; set; }
        public DbSet<Info_User> Users { get; set; }
        public DbSet<Info_UserRole> UserRoles { get; set; }
        public DbSet<Info_Menu> Menus { get; set; }
        public DbSet<Info_MenuRole> MenuRoles { get; set; }
        public DbSet<Info_Oper> Opers { get; set; }
        public DbSet<Info_OperRole> OperRoles { get; set; }
        public DbSet<Log_User> UserLogs { get; set; }
        public DbSet<Log_Oper> OperLogs { get; set; }
    }
}
