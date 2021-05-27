using Microsoft.EntityFrameworkCore;
using Backend.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Threading.Tasks;
using System;

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
