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