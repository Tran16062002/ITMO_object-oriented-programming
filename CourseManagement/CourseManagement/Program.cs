using System;
using System.Collections.Generic;
using System.Linq;
using CourseManagement.Models;
using CourseManagement.Repositories;
using CourseManagement.Services;

namespace CourseManagement
{
    class Program
    {
        static CourseService service = new CourseService();

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("=== Система управления курсами ===");

            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("\nВыберите действие:");
                Console.WriteLine("1. Добавить курс");
                Console.WriteLine("2. Удалить курс");
                Console.WriteLine("3. Добавить преподавателя");
                Console.WriteLine("4. Назначить преподавателя на курс");
                Console.WriteLine("5. Добавить студента");
                Console.WriteLine("6. Записать студента на курс");
                Console.WriteLine("7. Показать студентов курса");
                Console.WriteLine("8. Показать курсы преподавателя");
                Console.WriteLine("9. Показать все курсы");
                Console.WriteLine("0. Выход");
                Console.Write("→ ");
                string? choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1": AddCourse(); break;
                    case "2": RemoveCourse(); break;
                    case "3": AddTeacher(); break;
                    case "4": AssignTeacher(); break;
                    case "5": AddStudent(); break;
                    case "6": EnrollStudent(); break;
                    case "7": ShowStudentsInCourse(); break;
                    case "8": ShowCoursesByTeacher(); break;
                    case "9": ShowAllCourses(); break;
                    case "0": exit = true; break;
                    default: Console.WriteLine("Неверный выбор."); break;
                }
            }
        }

        // === МЕТОДЫ ===
        static void AddCourse()
        {
            Console.WriteLine("Выберите тип курса:");
            Console.WriteLine("1. Онлайн-курс");
            Console.WriteLine("2. Офлайн-курс");
            Console.Write("→ ");
            string? type = Console.ReadLine();

            Console.Write("Введите название курса: ");
            string? title = Console.ReadLine() ?? "Без названия";

            Course course;

            if (type == "1")
            {
                Console.Write("Введите платформу (Zoom, Moodle и т.п.): ");
                string platform = Console.ReadLine() ?? "Zoom";
                Console.Write("Введите ссылку на встречу: ");
                string link = Console.ReadLine() ?? "-";
                course = new OnlineCourse(title, platform, link);
            }
            else
            {
                Console.Write("Введите место проведения: ");
                string location = Console.ReadLine() ?? "Аудитория 1";
                Console.Write("Введите вместимость: ");
                int capacity = int.TryParse(Console.ReadLine(), out int c) ? c : 20;
                course = new OfflineCourse(title, location, capacity);
            }

            service.AddCourse(course);
            Console.WriteLine($"✅ Курс \"{course.Title}\" успешно добавлен!");
        }

        static void RemoveCourse()
        {
            ShowAllCourses();
            Console.Write("Введите ID курса для удаления: ");
            if (Guid.TryParse(Console.ReadLine(), out Guid id))
            {
                if (service.RemoveCourse(id))
                    Console.WriteLine("✅ Курс удалён.");
                else
                    Console.WriteLine("❌ Курс не найден.");
            }
        }

        static void AddTeacher()
        {
            Console.Write("Введите имя преподавателя: ");
            string name = Console.ReadLine() ?? "Без имени";
            var t = new Teacher(name);
            service.AddTeacher(t);
            Console.WriteLine($"✅ Преподаватель {t.Name} добавлен. ID: {t.Id}");
        }

        static void AssignTeacher()
        {
            ShowAllCourses();
            Console.Write("Введите ID курса: ");
            if (!Guid.TryParse(Console.ReadLine(), out Guid courseId)) return;

            Console.WriteLine("Список преподавателей:");
            foreach (var t in service.GetAllTeachers())
                Console.WriteLine($"{t.Id} — {t.Name}");

            Console.Write("Введите ID преподавателя: ");
            if (Guid.TryParse(Console.ReadLine(), out Guid teacherId))
            {
                if (service.AssignTeacherToCourse(teacherId, courseId))
                    Console.WriteLine("✅ Преподаватель назначен!");
                else
                    Console.WriteLine("❌ Ошибка: курс или преподаватель не найден.");
            }
        }

        static void AddStudent()
        {
            Console.Write("Введите имя студента: ");
            string name = Console.ReadLine() ?? "Без имени";
            var s = new Student(name);
            service.AddStudent(s);
            Console.WriteLine($"✅ Студент {s.Name} добавлен. ID: {s.Id}");
        }

        static void EnrollStudent()
        {
            ShowAllCourses();
            Console.Write("Введите ID курса: ");
            if (!Guid.TryParse(Console.ReadLine(), out Guid courseId)) return;

            Console.WriteLine("Список студентов:");
            foreach (var s in service.GetAllStudents())
                Console.WriteLine($"{s.Id} — {s.Name}");

            Console.Write("Введите ID студента: ");
            if (Guid.TryParse(Console.ReadLine(), out Guid studentId))
            {
                if (service.EnrollStudentToCourse(studentId, courseId))
                    Console.WriteLine("✅ Студент записан!");
                else
                    Console.WriteLine("❌ Ошибка при записи студента.");
            }
        }

        static void ShowStudentsInCourse()
        {
            ShowAllCourses();
            Console.Write("Введите ID курса: ");
            if (!Guid.TryParse(Console.ReadLine(), out Guid courseId)) return;

            var students = service.GetStudentsInCourse(courseId);
            if (!students.Any())
                Console.WriteLine("Нет студентов в этом курсе.");
            else
                Console.WriteLine("Студенты:");
            foreach (var s in students)
                Console.WriteLine($"- {s.Name}");
        }

        static void ShowCoursesByTeacher()
        {
            Console.WriteLine("Список преподавателей:");
            foreach (var t in service.GetAllTeachers())
                Console.WriteLine($"{t.Id} — {t.Name}");

            Console.Write("Введите ID преподавателя: ");
            if (!Guid.TryParse(Console.ReadLine(), out Guid teacherId)) return;

            var courses = service.GetCoursesByTeacher(teacherId);
            if (!courses.Any())
                Console.WriteLine("Этот преподаватель не ведет курсы.");
            else
            {
                Console.WriteLine("Курсы преподавателя:");
                foreach (var c in courses)
                    Console.WriteLine($"- {c.Title}");
            }
        }

        static void ShowAllCourses()
        {
            var courses = service.GetAllCourses();
            if (!courses.Any())
            {
                Console.WriteLine("Курсов пока нет.");
                return;
            }

            Console.WriteLine("Список курсов:");
            foreach (var c in courses)
            {
                string type = c is OnlineCourse ? "Онлайн" : "Офлайн";
                Console.WriteLine($"{c.Id} — {c.Title} ({type})");
            }
        }
    }
}
