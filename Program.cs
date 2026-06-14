using System.Collections.Generic;
using System.Linq;

namespace StudentPortal
{
    class Program
    {
        static List<Student> students = new List<Student>();
        static List<Instructor> instructors = new List<Instructor>();
        static List<Admin> admins = new List<Admin>();
        static List<Course> courses = new List<Course>();

        static void Main(string[] args)
        {
            SeedAdmin();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("===== STUDENT PORTAL =====");
                Console.WriteLine("1. Register Student");
                Console.WriteLine("2. Register Instructor");
                Console.WriteLine("3. Student Login");
                Console.WriteLine("4. Admin Login");
                Console.WriteLine("5. Exit");
                Console.Write("Select Option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        RegisterStudent();
                        break;

                    case "2":
                        RegisterInstructor();
                        break;

                    case "3":
                        StudentLogin();
                        break;

                    case "4":
                        AdminLogin();
                        break;

                    case "5":
                        return;

                    default:
                        Console.WriteLine("Invalid Option");
                        Pause();
                        break;
                }
            }
        }

        static void SeedAdmin()
        {
            admins.Add(new Admin
            {
                Username = "admin",
                Password = "admin123"
            });
        }

        static void RegisterStudent()
        {
            Console.Clear();

            Student student = new Student();

            Console.Write("Username: ");
            student.Username = Console.ReadLine();

            Console.Write("Password: ");
            student.Password = Console.ReadLine();

            students.Add(student);

            Console.WriteLine("\nStudent Registered Successfully.");
            Console.WriteLine($"Admission Status: {student.AdmissionStatus}");

            Pause();
        }

        static void RegisterInstructor()
        {
            Console.Clear();

            Instructor instructor = new Instructor();

            Console.Write("Username: ");
            instructor.Username = Console.ReadLine();

            Console.Write("Password: ");
            instructor.Password = Console.ReadLine();

            instructors.Add(instructor);

            Console.WriteLine("\nInstructor Registered Successfully.");

            Pause();
        }

        static void StudentLogin()
        {
            Console.Clear();

            Console.Write("Username: ");
            string username = Console.ReadLine();

            Console.Write("Password: ");
            string password = Console.ReadLine();

            Student student = students.FirstOrDefault(
                s => s.Username == username &&
                     s.Password == password);

            if (student == null)
            {
                Console.WriteLine("Invalid Login.");
                Pause();
                return;
            }

            StudentMenu(student);
        }

        static void StudentMenu(Student student)
        {
            while (true)
            {
                Console.Clear();

                Console.WriteLine($"Welcome {student.Username}");
                Console.WriteLine($"Admission Status: {student.AdmissionStatus}");

                Console.WriteLine("\n1. View Courses");
                Console.WriteLine("2. Select Courses");
                Console.WriteLine("3. View My Courses");
                Console.WriteLine("4. Logout");

                Console.Write("Select Option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ViewCourses();
                        break;

                    case "2":
                        SelectCourse(student);
                        break;

                    case "3":
                        ViewStudentCourses(student);
                        break;

                    case "4":
                        return;

                    default:
                        Console.WriteLine("Invalid Option");
                        Pause();
                        break;
                }
            }
        }

        static void AdminLogin()
        {
            Console.Clear();

            Console.Write("Username: ");
            string username = Console.ReadLine();

            Console.Write("Password: ");
            string password = Console.ReadLine();

            Admin admin = admins.FirstOrDefault(
                a => a.Username == username &&
                     a.Password == password);

            if (admin == null)
            {
                Console.WriteLine("Invalid Login.");
                Pause();
                return;
            }

            AdminMenu();
        }

        static void AdminMenu()
        {
            while (true)
            {
                Console.Clear();

                Console.WriteLine("===== ADMIN MENU =====");
                Console.WriteLine("1. Create Course");
                Console.WriteLine("2. View Courses");
                Console.WriteLine("3. View Students");
                Console.WriteLine("4. Approve Student");
                Console.WriteLine("5. Logout");

                Console.Write("Select Option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        CreateCourse();
                        break;

                    case "2":
                        ViewCourses();
                        break;

                    case "3":
                        ViewStudents();
                        break;

                    case "4":
                        ApproveStudent();
                        break;

                    case "5":
                        return;

                    default:
                        Console.WriteLine("Invalid Option");
                        Pause();
                        break;
                }
            }
        }

        static void CreateCourse()
        {
            Console.Clear();

            Course course = new Course();

            Console.Write("Course Code: ");
            course.CourseCode = Console.ReadLine();

            Console.Write("Course Name: ");
            course.CourseName = Console.ReadLine();

            courses.Add(course);

            Console.WriteLine("Course Created Successfully.");

            Pause();
        }

        static void ViewCourses()
        {
            Console.Clear();

            if (courses.Count == 0)
            {
                Console.WriteLine("No Courses Available.");
            }
            else
            {
                Console.WriteLine("AVAILABLE COURSES");

                foreach (Course course in courses)
                {
                    Console.WriteLine(
                        $"{course.CourseCode} - {course.CourseName}");
                }
            }

            Pause();
        }

        static void SelectCourse(Student student)
        {
            Console.Clear();

            if (courses.Count == 0)
            {
                Console.WriteLine("No Courses Available.");
                Pause();
                return;
            }

            Console.WriteLine("Available Courses");

            for (int i = 0; i < courses.Count; i++)
            {
                Console.WriteLine(
                    $"{i + 1}. {courses[i].CourseCode} - {courses[i].CourseName}");
            }

            Console.Write("\nSelect Course Number: ");

            if (int.TryParse(Console.ReadLine(), out int selection))
            {
                if (selection >= 1 &&
                    selection <= courses.Count)
                {
                    Course selectedCourse = courses[selection - 1];

                    if (!student.SelectedCourses.Contains(selectedCourse))
                    {
                        student.SelectedCourses.Add(selectedCourse);

                        student.AdmissionStatus =
                            "Awaiting Admin Approval";

                        Console.WriteLine(
                            $"Course {selectedCourse.CourseName} Added.");
                    }
                    else
                    {
                        Console.WriteLine("Course Already Selected.");
                    }
                }
            }

            Pause();
        }

        static void ViewStudentCourses(Student student)
        {
            Console.Clear();

            Console.WriteLine("MY COURSES");

            if (student.SelectedCourses.Count == 0)
            {
                Console.WriteLine("No Courses Selected.");
            }
            else
            {
                foreach (Course course in student.SelectedCourses)
                {
                    Console.WriteLine(
                        $"{course.CourseCode} - {course.CourseName}");
                }
            }

            Pause();
        }

        static void ViewStudents()
        {
            Console.Clear();

            if (students.Count == 0)
            {
                Console.WriteLine("No Students Registered.");
            }
            else
            {
                foreach (Student student in students)
                {
                    Console.WriteLine(
                        $"{student.Username} | {student.AdmissionStatus}");
                }
            }

            Pause();
        }

        static void ApproveStudent()
        {
            Console.Clear();

            Console.Write("Enter Student Username: ");
            string username = Console.ReadLine();

            Student student =
                students.FirstOrDefault(
                    s => s.Username == username);

            if (student == null)
            {
                Console.WriteLine("Student Not Found.");
                Pause();
                return;
            }

            if (student.SelectedCourses.Count == 0)
            {
                Console.WriteLine(
                    "Cannot Approve Student. No Courses Selected.");
            }
            else
            {
                student.AdmissionStatus = "Approved";

                Console.WriteLine(
                    "Student Admission Approved.");
            }

            Pause();
        }

        static void Pause()
        {
            Console.WriteLine("\nPress Enter To Continue...");
            Console.ReadLine();
        }
    }

    class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    class Admin : User
    {
    }

    class Instructor : User
    {
    }

    class Student : User
    {
        public string AdmissionStatus { get; set; }

        public List<Course> SelectedCourses { get; set; }

        public Student()
        {
            AdmissionStatus = "Pending";
            SelectedCourses = new List<Course>();
        }
    }

    class Course
    {
        public string CourseCode { get; set; }
        public string CourseName { get; set; }
    }
}