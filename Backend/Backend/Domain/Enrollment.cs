using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Domain
{
    public class Enrollment
    {
        public Guid Id { get; set; }
        public Guid StudentId { get; set; }

        public Student Student { get; set; }

        public Guid CourseId { get; set; }

        public Course Course { get; set; }

        public DateTime? StartDate { get; set; }
    }
}
