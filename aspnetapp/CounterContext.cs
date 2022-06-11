using System;
using System.Collections.Generic;
using aspnetapp.models;
using System.Linq; 
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace aspnetapp
{
    public partial class CounterContext : DbContext
    {
        public CounterContext()
        {
        }
        public DbSet<Customer> Customers { get; set; } = null!;
        public DbSet<Merchant> Merchants { get; set; } = null!;
        public DbSet<Movie> Movies { get; set; } = null!;
        public DbSet<Brand> Brands { get; set; } = null!;
        public DbSet<PushRecord> PushRecords { get; set; } = null!;
        public DbSet<Relationship> Relationships { get; set; } = null!;
        public DbSet<Vehicle> Vehicle { get; set; } = null!;
        public CounterContext(DbContextOptions<CounterContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var username = Environment.GetEnvironmentVariable("MYSQL_USERNAME");
                var password = Environment.GetEnvironmentVariable("MYSQL_PASSWORD");
                var addressParts = Environment.GetEnvironmentVariable("MYSQL_ADDRESS")?.Split(':');
                var host = addressParts?[0];
                var port = addressParts?[1];
                var connstr = $"server={host};port={port};user={username};password={password};database=aspnet_demo";
                optionsBuilder.UseMySql(connstr, Microsoft.EntityFrameworkCore.ServerVersion.Parse("5.7.18-mysql"));
                optionsBuilder.EnableSensitiveDataLogging();
                optionsBuilder.LogTo(Console.WriteLine);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            modelBuilder.Entity<Vehicle>()
            .HasOne(p => p.Customer)
            .WithMany(b => b.Vehicle);
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
