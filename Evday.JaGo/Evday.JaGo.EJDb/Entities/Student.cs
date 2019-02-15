using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evday.JaGo.EJDb.Entities
{
    public class Student
    {
        public int sId { get; set; }
        public string Name { get; set; }
        public int tId { get; set; }
    }

    public class StudentMap : EntityTypeConfiguration<Student>
    {
        public StudentMap()
        {
            // Primary Key
            this.HasKey(t => t.sId);

            // Properties
            this.ToTable("student");
            this.Property(t => t.sId)
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .HasColumnName("sid");
            this.Property(t => t.Name).HasColumnName("name");
            this.Property(t => t.tId).HasColumnName("tid").IsRequired();

        }
    }
}
