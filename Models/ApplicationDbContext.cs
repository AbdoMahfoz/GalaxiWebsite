﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Models.DataModels;
using System;

namespace Models
{
    public class ApplicationDbContext : DbContext
    {
        public static string LocalDatabaseName { get; set; } = "galaxi";
        public DbSet<User> Users { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<CheckIn> CheckIns { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public ApplicationDbContext() { }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            Configure(options);
        }
        public static void Configure(DbContextOptionsBuilder options)
        {
            string url = Environment.GetEnvironmentVariable("DATABASE_URL");
            if (string.IsNullOrWhiteSpace(url))
            {
                options.UseNpgsql($"Host=localhost;" +
                                  $"Port=5432;" +
                                  $"Database={LocalDatabaseName};" +
                                  $"Username=user;" +
                                  $"Password=123");
            }
            else
            {
                url = url.Substring(url.IndexOf("//") + 2);
                string userName = url.Substring(0, url.IndexOf(':'));
                url = url.Substring(url.IndexOf(':') + 1);
                string password = url.Substring(0, url.IndexOf('@'));
                url = url.Substring(url.IndexOf('@') + 1);
                string host = url.Substring(0, url.IndexOf(':'));
                url = url.Substring(url.IndexOf(':') + 1);
                string port = url.Substring(0, url.IndexOf('/'));
                string database = url.Substring(url.IndexOf('/') + 1);
                options.UseNpgsql($"Host={host};" +
                                  $"Port={port};" +
                                  $"Database={database};" +
                                  $"Username={userName};" +
                                  $"Password={password};" +
                                  $"SSLMode=Require;TrustServerCertificate=true");
            }
        }
    }
}

