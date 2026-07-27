using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRNTechnicalAssessment.Domain.Entities;
namespace CRNTechnicalAssessment.Infrastructure.Data.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");
            builder.HasKey(e => e.Id);
            builder.Property(e=>e.ProductName).HasMaxLength(200).IsRequired();
            builder.Property(e=>e.CreatedBy).HasMaxLength(200).IsRequired();
            builder.Property(e => e.CreatedOn).IsRequired();
            builder.Property(e=>e.ModifiedBy);
            builder.HasMany(e => e.Items).WithOne(e => e.Product).HasForeignKey(e => e.ProductId).OnDelete(DeleteBehavior.Cascade);

        }
    }
}
