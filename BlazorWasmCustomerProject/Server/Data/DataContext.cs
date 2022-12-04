using BlazorWasmCustomerProject.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace BlazorWasmCustomerProject.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext() 
        {
        
        }
        public DataContext(DbContextOptions<DataContext> Options)
            : base(Options)
        {

        }

        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasData(
            new Customer
            {
                Id = 1,
                CompanyName = "Deloitte",
                ContactName = "Michalis",
                Address = "Gianni Chalkidi",
                City = "Thessaloniki",
                Region = "Charilaou",
                PostalCode = "54249",
                Country = "Greece",
                Phone = "6845210369"
            },
            new Customer
            {
                Id = 2,
                CompanyName = "Eastern Young",
                ContactName = "Pavlos",
                Address = "Konstantinoupoleos",
                City = "Thessaloniki",
                Region = "Toumpa",
                PostalCode = "55231",
                Country = "Greece",
                Phone = "6981234567"
            },
            new Customer
            {
                Id = 3,
                CompanyName = "Epsilon net",
                ContactName = "Eleni",
                Address = "Pavlou Mela",
                City = "Athens",
                Region = "Ampelokipoi",
                PostalCode = "55242",
                Country = "Greece",
                Phone = "6984561238"
            },
            new Customer
            {
                Id = 4,
                CompanyName = "Alpha net",
                ContactName = "Aleksandra",
                Address = "Papanastasiou",
                City = "Larisa",
                Region = "Kentro",
                PostalCode = "57470",
                Country = "Greece",
                Phone = "6978945612"
            });
        }
    }
}
