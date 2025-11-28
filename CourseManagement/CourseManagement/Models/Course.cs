using System;
using System.Collections.Generic;

namespace CourseManagement.Models
{
    public abstract class Course
    {
        public Guid Id { get; } = Guid.NewGuid();
        public string Title { get; set; }
        public Teacher? Teacher { get; set; }
        public List<Student> Students { get; } = new();

        protected Course(string title)
        {
            Title = title;
        }

        public virtual bool EnrollStudent(Student student)
        {
            if (!Students.Contains(student))
            {
                Students.Add(student);
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            return $"{Title} (Преподаватель: {Teacher?.Name ?? "не назначен"})";
        }
    }
}
