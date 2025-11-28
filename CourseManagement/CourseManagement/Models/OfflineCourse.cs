namespace CourseManagement.Models
{
    public class OfflineCourse : Course
    {
        public string Location { get; set; }
        public int Capacity { get; set; }

        public OfflineCourse(string title, string location, int capacity)
            : base(title)
        {
            Location = location;
            Capacity = capacity;
        }

        public override bool EnrollStudent(Student student)
        {
            if (Students.Count >= Capacity) return false;
            return base.EnrollStudent(student);
        }

        public override string ToString()
        {
            return $"{base.ToString()} [Аудитория: {Location}, мест: {Capacity}]";
        }
    }
}
