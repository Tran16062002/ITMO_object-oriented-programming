using System;

namespace CourseManagement.Models
{
    public class Student
    {
        public Guid Id { get; } = Guid.NewGuid();
        public string Name { get; set; }

        public Student(string name)
        {
            Name = name;
        }

        public override string ToString() => Name;
    }
}
