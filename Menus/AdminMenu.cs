using studentportal.Enums;
using studentportal.Managers.Interfaces;
using studentportal.Models;

namespace studentportal.Menus
{
    public class AdminMenu
    {
        private readonly IUserManager _userManager;

        public AdminMenu(IUserManager userManager)
        {
            _userManager = userManager;
        }

        public void Show(User admin)
        {
            var exit = false;

            while (!exit)
            {
                Console.WriteLine();
                Console.WriteLine("========== ADMIN MENU ==========");
                Console.WriteLine("1. Create Admin");
                Console.WriteLine("2. View Admins");
                Console.WriteLine("3. View Students");
                Console.WriteLine("4. Create Instructors");
                Console.WriteLine("5. View Instructors");
                Console.WriteLine("6. Create Lessons");
                Console.WriteLine("7. View Lessons");
                Console.WriteLine("0. Logout");
                Console.Write("Select an option: ");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("Select role:");
                        Console.WriteLine("1. Admin");
                        Console.WriteLine("2. SuperAdmin");

                        var roleChoice = Console.ReadLine();

                        Role role = roleChoice == "2"
                            ? Role.SuperAdmin
                            : Role.Admin;

                        _userManager.CreateAdmin(admin.Email, role);
                        break;

                    case "2":

                        var admins = _userManager.GetAdmins();

                        if (!admins.Any())
                        {
                            Console.WriteLine("No admins found.");
                        }
                        else
                        {
                            foreach (var item in admins)
                            {
                                Console.WriteLine(item);
                            }
                        }

                        break;

                    case "3":

                        var students = _userManager.GetStudents();

                        if (!students.Any())
                        {
                            Console.WriteLine("No students found.");
                        }
                        else
                        {
                            foreach (var item in students)
                            {
                                Console.WriteLine(item);
                            }
                        }

                        break;

                    case "4":

                        _userManager.CreateInstructor(admin.Email);

                        break;

                    case "5":

                        var instructors = _userManager.GetInstructors();

                        if (!instructors.Any())
                        {
                            Console.WriteLine("No instructors found.");
                        }
                        else
                        {
                            foreach (var item in instructors)
                            {
                                Console.WriteLine(item);
                            }
                        }

                        break;



                    case "0":
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("Invalid option, try again.");
                        break;
                }
            }
        }
    }
}