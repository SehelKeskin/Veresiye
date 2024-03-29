﻿using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Veresiye.Model;

namespace Veresiye.Data.Builders
{
    public class UserBuilder
    {
      /*  HasKey metodu; tablonun Primary Key alanını ifade etmek için kullanılır ve POCO sınıfında bu değer otomatik oluşturuluyorsa girilmez.
        HasRequired metodu; tablo alanlarının boş bırakılamayacağını işaretlemekte kullanılır.
        HasMany metodu; bir kolleksiyona yönlenen lambda ifadesi içerir.
        HasForeignKey metodu; tabloya başka bir tablonun PK alanını vermek için kullanılır.*/
        public UserBuilder(EntityTypeConfiguration<User> builder)
    {
            builder.HasKey(a=>a.Id);
            builder.Property(a => a.UserName).IsRequired().HasMaxLength(100);
            builder.Property(a => a.Password).IsRequired().HasMaxLength(100);
            builder.Property(a => a.CompanyName).HasMaxLength(100);
            builder.Property(a => a.City).HasMaxLength(100);
            builder.Property(a => a.Phone).HasMaxLength(100);
            builder.Property(a => a.Phone).HasMaxLength(100);

        }

    }
}
