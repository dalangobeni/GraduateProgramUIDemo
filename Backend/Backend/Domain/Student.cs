using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Domain
{
    public class Student
    {
        public Student()
        {
            Enrollments = new List<Enrollment>();
        }
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public IList<Enrollment> Enrollments { get; set; }
    }
}
