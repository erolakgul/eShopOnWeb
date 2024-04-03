using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.eShopWeb.ApplicationCore.Entities.OrderAggregate;

namespace Microsoft.eShopWeb.Infrastructure.Data.Config;
public class OrderStatusConfiguration : IEntityTypeConfiguration<OrderStatus>
{
    public void Configure(EntityTypeBuilder<OrderStatus> builder)
    {
        builder.HasKey(ci => ci.Id);

        builder.Property(ci => ci.Id)
               .UseHiLo("orderstatus_hilo")
            .IsRequired();

        builder.Property(cb => cb.Name)
           .IsRequired()
           .HasMaxLength(100);
          
        builder.ToTable("OrderStatus");
    }
}
