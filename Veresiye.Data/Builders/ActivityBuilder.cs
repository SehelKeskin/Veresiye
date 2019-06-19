using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Veresiye.Model;

namespace Veresiye.Data.Builders
{
    public class ActivityBuilder
    {

        public ActivityBuilder(EntityTypeConfiguration<Activity> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Name).IsRequired().HasMaxLength(100);
            //Olmadıııı  builder.Property(a => a.Amount).HasColumnType("decimal(18,2)");
            builder.Property(a => a.Amount).HasPrecision(18, 2).IsRequired();
            builder.Property(a => a.TransactionDate).IsRequired();
            builder.Property(a => a.ActivityType).IsRequired();
            //burada ne taraf many ne taraf on vs. bunu belirtmen lazım.
            builder.HasRequired(a => a.Company).WithMany(b => b.Activities).HasForeignKey(a => a.CompanyId);

        }
    }
}
