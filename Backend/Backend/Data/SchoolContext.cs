using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Backend.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Backend.Data
{
    public class SchoolContext : IdentityDbContext<ApplicationUser>
    {
        public SchoolContext (DbContextOptions<SchoolContext> options)
            : base(options)
        {
        }

        public DbSet<Course> Course { get; set; }

        public DbSet<Student> Student { get; set; }

        public DbSet<Enrollment> Enrollment { get; set; }

		public DbSet<Library> Library { get; set; }

        public DbSet<Librarian> Librarian { get; set; }
    }
}
