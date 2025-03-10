﻿using Microsoft.EntityFrameworkCore;

namespace Aesthetica.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<ContactModel> contactus { get; set; }  // Maps to Contacts table
        public DbSet<RegisterModel> registeruser { get; set; }  // Maps to Users table
    }
}
