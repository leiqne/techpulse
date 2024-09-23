using API.Entities.Orders;
using API.Entities.Products;
using API.Entities.Providers;
using API.Entities.Reviews.Interfaces;
using API.Entities.Users;
using API.Entities.Reviews;
using Microsoft.EntityFrameworkCore;

namespace API.Configuration;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        base.OnConfiguring(builder);
        builder.AddInterceptors();
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<User>().HasKey(u => u.Id);
        builder.Entity<User>().Property(u => u.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<User>().OwnsOne(u => u.Name, n =>
        {
            n.Property(u => u.Name).IsRequired().HasColumnName("user_name");
        });
        builder.Entity<User>().OwnsOne(u => u.Email, e =>
        {
            e.Property(a => a.Email).IsRequired().HasColumnName("email_address");
        });
        builder.Entity<User>().OwnsOne(u => u.Number, n =>
        {
            n.Property(p => p.Number).IsRequired().HasColumnName("phone_number");
        });
        builder.Entity<User>().Property(u => u.PHash).HasColumnName("password_hash");

        
        builder.Entity<Provider>().HasKey(p => p.Id);
        builder.Entity<Provider>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Provider>().OwnsOne(p => p.Name, n =>
        {
            n.Property(pn => pn.Name).IsRequired().HasColumnName("provider_name");
        });
        builder.Entity<Provider>().OwnsOne(p => p.Address, a =>
        {
            a.Property(pa => pa.Address).IsRequired().HasColumnName("provider_address");
        });
        builder.Entity<Provider>().OwnsOne(p => p.Link, l =>
        {
            l.Property(pl => pl.Link).IsRequired().HasColumnName("provider_link");
        });


        builder.Entity<Product>().HasKey(p => p.Id);
        builder.Entity<Product>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Product>().OwnsOne(p => p.Name, n =>
        {
            n.Property(pn => pn.Name).IsRequired().HasColumnName("product_name");
        });
        builder.Entity<Product>().HasOne(p => p.Provider).WithMany(p => p.Products).HasForeignKey(p => p.PId)
            .HasPrincipalKey(p => p.Id);


        builder.Entity<Review>().HasKey(r => r.Id);
        builder.Entity<Review>().Property(r => r.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Review>().OwnsOne(r => r.Stars, n =>
        {
            n.Property(s => s.Stars).IsRequired().HasColumnName("star_number");
        });
        builder.Entity<Review>().OwnsOne(r => r.Content, c =>
        {
            c.Property(rc => rc.Content).IsRequired().HasColumnName("review_content");
        });
        builder.Entity<Review>().HasOne(r => r.User).WithMany(u => u.Reviews).HasForeignKey(r => r.UId)
            .HasPrincipalKey(u => u.Id);
        builder.Entity<Review>().HasOne(r => r.Product).WithMany(p => p.Reviews).HasForeignKey(r => r.ProdId)
            .HasPrincipalKey(p => p.Id);


        builder.Entity<Order>().HasKey(o => o.Id);
        builder.Entity<Order>().Property(o => o.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Order>().OwnsOne(o => o.Amount, p =>
        {
            p.Property(a => a.Amount).IsRequired().HasColumnName("pay_amount");
        });
        builder.Entity<Order>().OwnsOne(o => o.Date, od =>
        {
            od.Property(d => d.Date).IsRequired().HasColumnName("order_date");
        });
        builder.Entity<Order>().OwnsOne(o => o.State, os =>
        {
            os.Property(s => s.State).IsRequired().HasColumnName("order_state");
        });
        builder.Entity<Order>().OwnsOne(o => o.Method, sm =>
        {
            sm.Property(m => m.Shipping).IsRequired().HasColumnName("shipping_method");
        });
        builder.Entity<Order>().HasOne(o => o.User).WithMany(u => u.Orders).HasForeignKey(o => o.UId)
            .HasPrincipalKey(u => u.Id);
        builder.Entity<Order>().HasOne(o => o.Product).WithMany(p => p.Orders).HasForeignKey(o => o.ProdId)
            .HasPrincipalKey(p => p.Id);
    }
}