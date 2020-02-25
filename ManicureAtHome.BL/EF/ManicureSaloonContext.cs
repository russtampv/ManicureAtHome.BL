using ManicureAtHome.BL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ManicureAtHome.BL.EF
{
    public class ManicureSaloonContext : DbContext
    {
        private readonly ILoggerFactory WorkLoggerFactory = LoggerFactory.Create(builder =>
        {
            builder.AddProvider(new WorkLogger());
        });

        public DbSet<Client> Clients {  get;set;}
        public DbSet<Material> Materials { get; set; }
        public DbSet<RecordToSpecialist> Records { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<WareHouse> WareHouse { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<SoldService> SoldServices { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //var builder = new ConfigurationBuilder();
            //builder.SetBasePath(Directory.GetCurrentDirectory());
            //builder.AddJsonFile("appsettings.json");
            //var connectionString = builder.Build().GetConnectionString("DefaultConnection");
            optionsBuilder.UseLoggerFactory(WorkLoggerFactory);
            optionsBuilder.UseSqlServer("Server=ALESYA\\SQLEXPRESS;Database=ManicureSaloon;integrated security=True;");

        }
       // public ManicureSaloonContext(DbContextOptions<ManicureSaloonContext> options) : base(options) { }
       //public ManicureSaloonContext()
       // {
       //     Database.EnsureCreated();
       // }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Использование Fluent API
            modelBuilder.Entity<Contact>().HasIndex(item => new { item.FirstName, item.LastName });
            modelBuilder.Entity<Material>().HasIndex(material => material.materialName);
            modelBuilder.Entity<Service>().Property(p => p.Price).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<Contact>().HasIndex(p => new {p.Mail});
            modelBuilder.Entity<RecordToSpecialist>().HasIndex(record => new { record.AppointmentDate, record.AppointmentTime });
            base.OnModelCreating(modelBuilder);
        }
    }
}
