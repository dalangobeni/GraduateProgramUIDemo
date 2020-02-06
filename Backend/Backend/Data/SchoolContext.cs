using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Backend.Domain;

namespace Backend.Data
{
    public class SchoolContext : DbContext
    {
        public SchoolContext (DbContextOptions<SchoolContext> options)
            : base(options)
        {
        }

        public DbSet<Backend.Domain.Course> Course { get; set; }

        public DbSet<Backend.Domain.Student> Student { get; set; }

        public DbSet<Backend.Domain.Enrollment> Enrollment { get; set; }
    }
}
