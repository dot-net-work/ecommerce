using System;
using System.Collections.Generic;
using System.Text;
using EcommerceApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EcommerceApp.DatabaseContext.FluentConfiguration
{
    class ProductFluentConfiguration:IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(c => c.Name).IsRequired();
        }
    }
}
