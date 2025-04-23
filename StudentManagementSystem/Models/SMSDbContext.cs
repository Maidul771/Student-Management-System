using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Compilation;

namespace StudentManagementSystem.Models
{
    public class SMSDbContext:DbContext
    {
        public SMSDbContext() : base("DefaultConnection") { }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Batch> Batchs { get; set; }
        public DbSet<Registration> Registrations { get; set; }
        public DbSet<User> Users { get; set; }

    }
}