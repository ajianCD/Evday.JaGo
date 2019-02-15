using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evday.JaGo.EJDb.Entities
{
    public class Teacher
    {
        public int tId { get; set; }
        public string Name { get; set; }
    }
    public class TeacherMap : EntityTypeConfiguration<Teacher>
    {
        public TeacherMap()
        {
            // Primary Key
            this.HasKey(t => t.tId);

            // Properties
            this.ToTable("teacher");
            this.Property(t => t.tId)
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .HasColumnName("tid");
            this.Property(t => t.Name).HasColumnName("name");
        }
    }

}
