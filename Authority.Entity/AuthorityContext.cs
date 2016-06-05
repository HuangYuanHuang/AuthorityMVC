namespace Authority.Entity
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Data.Entity.ModelConfiguration.Conventions;
    public class AuthorityContext : DbContext
    {
        //您的上下文已配置为从您的应用程序的配置文件(App.config 或 Web.config)
        //使用“AuthorityContext”连接字符串。默认情况下，此连接字符串针对您的 LocalDb 实例上的
        //“Authority.Entity.AuthorityContext”数据库。
        // 
        //如果您想要针对其他数据库和/或数据库提供程序，请在应用程序配置文件中修改“AuthorityContext”
        //连接字符串。
        public AuthorityContext()
            : base("name=AuthorityContext")
        {
        }

        //为您要在模型中包含的每种实体类型都添加 DbSet。有关配置和使用 Code First  模型
        //的详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=390109。

        public virtual DbSet<Purv_User> PurvUsers { get; set; }
        public virtual DbSet<Purv_Role> PurvRoles { set; get; }

        public virtual DbSet<Purv_Module> PurvModules { set; get; }

        public virtual DbSet<Purv_Department> PurvDepartments { set; get; }

        public virtual DbSet<Purv_Authority> PurvAuthoritys { set; get; }

        public virtual DbSet<Purv_RoleDepartment> PurvRoleDepartments { set; get; }

        public virtual DbSet<Purv_RoleModule> PurvRoleModules { set; get; }

        public virtual DbSet<Purv_UserDepartment> PurvUserDepartments { set; get; }

        public virtual DbSet<Purv_UserModule> PurvUserModeules { set; get; }

        public virtual DbSet<Purv_AppConfig> PurvAppConfigs { set; get; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Purv_User>().HasMany(b => b.Roles).WithMany(r => r.Users).Map(m =>
            {
                m.ToTable("T_Purv_UserRole");
                m.MapLeftKey("UserId");
                m.MapRightKey("RoleID");

            });

            modelBuilder.Entity<Purv_UserModule>().HasKey(k => new { k.UserId, k.ModuleId });
            modelBuilder.Entity<Purv_UserModule>().HasRequired(p => p.PurvUser).WithMany(q => q.UserModules).HasForeignKey(p => p.UserId).WillCascadeOnDelete(false);
            modelBuilder.Entity<Purv_UserModule>().HasRequired(p => p.PurvModule).WithMany(q => q.UserModules).HasForeignKey(p => p.ModuleId).WillCascadeOnDelete(false);

            modelBuilder.Entity<Purv_RoleModule>().HasKey(k => new { k.RoleId, k.ModuleId });
            modelBuilder.Entity<Purv_RoleModule>().HasRequired(p => p.PurvModule).WithMany(q => q.RoleModules).HasForeignKey(p => p.ModuleId).WillCascadeOnDelete(false);
            modelBuilder.Entity<Purv_RoleModule>().HasRequired(p => p.PurvRole).WithMany(q => q.RoleModules).HasForeignKey(p => p.RoleId).WillCascadeOnDelete(false);

            modelBuilder.Entity<Purv_UserDepartment>().HasKey(k => new { k.UserId, k.DepartmentId });
            modelBuilder.Entity<Purv_UserDepartment>().HasRequired(p => p.PurvUser).WithMany(q => q.UserDepartments).HasForeignKey(p => p.UserId).WillCascadeOnDelete(false);
            modelBuilder.Entity<Purv_UserDepartment>().HasRequired(p => p.PurvDepartment).WithMany(q => q.UserDepartments).HasForeignKey(p => p.DepartmentId).WillCascadeOnDelete(false);

            modelBuilder.Entity<Purv_RoleDepartment>().HasKey(k => new { k.RoleId, k.DepartmentId });
            modelBuilder.Entity<Purv_RoleDepartment>().HasRequired(p => p.PurvRole).WithMany(q => q.RoleDepartments).HasForeignKey(p => p.RoleId).WillCascadeOnDelete(false);
            modelBuilder.Entity<Purv_RoleDepartment>().HasRequired(p => p.PurvDepartment).WithMany(q => q.RoleDepartments).HasForeignKey(p => p.DepartmentId).WillCascadeOnDelete(false);
        }
    }


}