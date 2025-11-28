using Xunit;
using CourseManagement.Models;
using CourseManagement.Services;
using CourseManagement.Repositories;
using System.Linq;

namespace CourseManagement.Tests
{
    public class CourseServiceTests
    {
        private readonly CourseService _service;

        public CourseServiceTests()
        {
            _service = new CourseService();
        }

        [Fact]
        public void CanAddAndRetrieveCourse()
        {
            var course = new OnlineCourse("Programming 101", "Zoom", "http://online-course.com");
            _service.AddCourse(course);

            var courses = _service.GetAllCourses().ToList();

            Assert.Single(courses);
            Assert.Equal("Programming 101", courses.First().Title);
        }

        [Fact]
        public void CanAddTeacherAndAssignToCourse()
        {
            var teacher = new Teacher("Dr. Smith");
            var course = new OfflineCourse("Algorithms", "Room 5", 2);

            _service.AddTeacher(teacher);
            _service.AddCourse(course);
            _service.AssignTeacherToCourse(teacher.Id, course.Id);

            var teacherCourses = _service.GetCoursesByTeacher(teacher.Id).ToList();

            Assert.Single(teacherCourses);
            Assert.Equal("Algorithms", teacherCourses.First().Title);
        }

        [Fact]
        public void CanAddStudentToCourse()
        {
            var student = new Student("Alice");
            var course = new OnlineCourse("Databases","Zoom", "http://db.com");

            _service.AddStudent(student);
            _service.AddCourse(course);
            _service.EnrollStudentToCourse(student.Id, course.Id);

            var students = _service.GetStudentsInCourse(course.Id).ToList();

            Assert.Single(students);
            Assert.Equal("Alice", students.First().Name);
        }
    }
}
