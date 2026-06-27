using studentportal.Models;
using studentportal.Managers.Interfaces;
using studentportal.Enums;

namespace studentportal.Managers.Implementations
{
    public class UserManager : IUserManager
    {
        private static int _nextId = 1;
 
        private static List<User> _allUsers = new();

        public void InitializeDefaultSuperAdmin()
        {
            var defaultEmail = "admin@sbsc.com";

            if (!_allUsers.Any(u =>
                u.Email.Equals(defaultEmail, StringComparison.OrdinalIgnoreCase)))
            {
                var admin = new User(
                    _nextId++,
                    "Super",
                    "Admin",
                    null,
                    defaultEmail,
                    "Admin@123",
                    null,
                   Role.SuperAdmin ,
                    "System",
                    "SYS001"
                );

                _allUsers.Add(admin);
            }
        }

        private bool EmailAlreadyExist(string email)
        {
            return _allUsers.Any(u =>
                u.Email.Equals(email, StringComparison.OrdinalIgnoreCase));
        }

        public void CreateAdmin(string loginUser, Role role)
        {
            Console.Write("First Name: ");
            var firstName = Console.ReadLine()!;

            Console.Write("Last Name: ");
            var lastName = Console.ReadLine()!;

            Console.Write("Phone Number: ");
            var phone = Console.ReadLine();

            string email;
            do
            {
                Console.Write("Email: ");
                email = Console.ReadLine()!;
            }
            while (string.IsNullOrEmpty(email) || EmailAlreadyExist(email));

            Console.Write("Address: ");
            var address = Console.ReadLine();

            Console.Write("Password: ");
            var password = Console.ReadLine()!;

            var user = new User(
                _nextId++,
                firstName,
                lastName,
                phone,
                email,
                password,
                address,
                role,
                loginUser,
                null
            );

            _allUsers.Add(user);

            Console.WriteLine($"Successfully created {role}: {firstName} {lastName}");
        }

        public User? Login()
        {
            Console.Write("Email: ");
            var email = Console.ReadLine();

            Console.Write("Password: ");
            var password = Console.ReadLine();

            var encrypted = password!;

            return _allUsers.FirstOrDefault(u =>
                u.Email.Equals(email, StringComparison.OrdinalIgnoreCase)
                && u.EncryptedPassword == encrypted);
        }

        public User StudentRegister()
        {
            Console.Write("First Name: ");
            var firstName = Console.ReadLine()!;

            Console.Write("Last Name: ");
            var lastName = Console.ReadLine()!;

            Console.Write("Phone: ");
            var phone = Console.ReadLine();

            Console.Write("Email: ");
            var email = Console.ReadLine()!;

            Console.Write("Address: ");
            var address = Console.ReadLine();

            Console.Write("Password: ");
            var password = Console.ReadLine()!;

            var student = new User(
                _nextId++,
                firstName,
                lastName,
                phone,
                email,
                password,
                address,
                Role.Student,
                "Self-Registration"
            );

            _allUsers.Add(student);

            return student;
        }
    }
}