using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Domain
{
    public class Course
    {
        public Course()
        {
            Enrollments = new List<Enrollment>();
        }
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public string Description { get; set; }

        public IList<Enrollment> Enrollments { get; set; }
    }
}
