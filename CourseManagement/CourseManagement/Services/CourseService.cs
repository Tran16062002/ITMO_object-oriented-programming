using System;
using System.Collections.Generic;
using System.Linq;
using CourseManagement.Models;
using CourseManagement.Repositories;

namespace CourseManagement.Services
{
    public class CourseService
    {
        private readonly IRepository<Course> _courseRepo;
        private readonly IRepository<Teacher> _teacherRepo;
        private readonly IRepository<Student> _studentRepo;

        public CourseService()
        {
            _courseRepo = new InMemoryRepository<Course>();
            _teacherRepo = new InMemoryRepository<Teacher>();
            _studentRepo = new InMemoryRepository<Student>();
        }

        // === КУРСЫ ===
        public void AddCourse(Course course) => _courseRepo.Add(course);

        public bool RemoveCourse(Guid id)
        {
            var course = _courseRepo.GetById(id);
            if (course == null) return false;
            _courseRepo.Remove(course);
            return true;
        }

        public IEnumerable<Course> GetAllCourses() => _courseRepo.GetAll();

        // === ПРЕПОДАВАТЕЛИ ===
        public void AddTeacher(Teacher teacher) => _teacherRepo.Add(teacher);

        public IEnumerable<Teacher> GetAllTeachers() => _teacherRepo.GetAll();

        public bool AssignTeacherToCourse(Guid teacherId, Guid courseId)
        {
            var course = _courseRepo.GetById(courseId);
            var teacher = _teacherRepo.GetById(teacherId);
            if (course == null || teacher == null) return false;
            course.Teacher = teacher;
            teacher.Courses.Add(course);
            return true;
        }

        public IEnumerable<Course> GetCoursesByTeacher(Guid teacherId)
        {
            return _courseRepo.GetAll().Where(c => c.Teacher != null && c.Teacher.Id == teacherId);
        }

        // === СТУДЕНТЫ ===
        public void AddStudent(Student student) => _studentRepo.Add(student);

        public IEnumerable<Student> GetAllStudents() => _studentRepo.GetAll();

        public bool EnrollStudentToCourse(Guid studentId, Guid courseId)
        {
            var course = _courseRepo.GetById(courseId);
            var student = _studentRepo.GetById(studentId);
            if (course == null || student == null) return false;
            return course.EnrollStudent(student);
        }

        public IEnumerable<Student> GetStudentsInCourse(Guid courseId)
        {
            var course = _courseRepo.GetById(courseId);
            return course?.Students ?? new List<Student>();
        }
    }
}
