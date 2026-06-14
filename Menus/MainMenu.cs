using System.Collections.Generic;
using StudentPortal.Enums;
using StudentPortal.Managers.Implementations;
using StudentPortal.Managers.Interfaces;

namespace StudentPortal.Menus
{
    public class MainMenu
    {
        private readonly IUserManager _userManager;
       public MainMenu()
        {
            _userManager = new UserManager();
        }

        public void Run()
        {
            
            Console.Clear();
            Console.WriteLine("===== STUDENT PORTAL =====");
            Console.WriteLine("1. Register Student");
            Console.WriteLine("2. Register Intstructor");
            Console.WriteLine("3. Student Login");
            Console.WriteLine("4. Admin Login");
            Console.WriteLine("5. Exit");
            Console.Write("Select Option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    //RegisterStudent();
                    Console.WriteLine("RegsterStudent");
                    break;

                case "2":
                    //RegisterInstructor();
                    Console.WriteLine("ReisterInstrcutor");
                    break;

                case "3":
                    //StudentLogin();
                    Console.WriteLine("StudentLogin");
                    break;

                case "4":
                    //AdminLogin();
                    Console.WriteLine("AdminLogin");
                    break;

                case "5":
                    return;

                default:
                    Console.WriteLine("Invalid Option");
                    //Pause();
                    break;
            }
        }

    }
}