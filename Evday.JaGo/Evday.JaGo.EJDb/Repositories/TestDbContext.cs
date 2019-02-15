using Evday.JaGo.EJDb.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evday.JaGo.EJDb.Repositories
{
    public class TestDbContext : DbContext
    {
        /// <summary>
        /// 配置数据库连接
        /// </summary>
        public TestDbContext() : base("test")
        {
            ((IObjectContextAdapter)this).ObjectContext.CommandTimeout = 1800;
        }

        public DbSet<Student> student { get; set; }

        public DbSet<Teacher> teacher { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new StudentMap());
            modelBuilder.Configurations.Add(new TeacherMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
