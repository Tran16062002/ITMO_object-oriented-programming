using System;
using System.Collections.Generic;

namespace CourseManagement.Models
{
    public class Teacher
    {
        public Guid Id { get; } = Guid.NewGuid();
        public string Name { get; set; }
        public List<Course> Courses { get; } = new();

        public Teacher(string name)
        {
            Name = name;
        }

        public override string ToString() => $"{Name}";
    }
}
