using studentportal.Models;
using studentportal.Managers.Interfaces;
using studentportal.Enums;
using studentportal.Helpers;

namespace studentportal.Managers.Implementations
{
    public class UserManager : IUserManager
    {
        private static int _nextId = 1;
        private static string _fileName = "users.txt";
        private static List<User> _allUsers = new List<User>();

        public UserManager()
        {
            _allUsers = FileUtil.ReadFromFile<User>(_fileName);
            if(_allUsers.Count == 0)
            {
                InitializeDefaultSuperAdmin();
            }
            
        }

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
                    UserHelper.EncryptPassword("Admin@123"),
                    null,
                   Role.SuperAdmin,
                    "System",
                    "SYS001"
                );

                _allUsers.Add(admin);
                FileUtil.SaveToFile(_allUsers, _fileName);
            }
        }

        private bool EmailAlreadyExist(string email)
        {
            var exists = _allUsers.Any(u => u.Email.Equals(email, StringComparison.InvariantCultureIgnoreCase));
            if (exists)
            {
                Console.WriteLine($"{email} already exist, please use another email.");
                return true;
            }
            return false;
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
            FileUtil.SaveToFile(_allUsers, _fileName);

            Console.WriteLine($"Successfully created {role}: {firstName} {lastName}");
        }

        public User? Login()
        {
            Console.Write("Enter your email: ");
            var email = Console.ReadLine()!;
            Console.Write("Enter your password: ");
            var password = Console.ReadLine()!;
            var user = _allUsers.Where(u => u.Email.Equals(email, StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();
            if (user != null)
            {
                if(UserHelper.IsValidPassword(password, user.EncryptedPassword))
                {
                    return user;
                }
            }
            Console.WriteLine("Invalid user email or password.");
            return null;
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

            FileUtil.SaveToFile(_allUsers, _fileName);
            return student;
        }

        public void CreateInstructor(string loginUser)
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
                Role.Instructor,
                loginUser,
                null
            );

            _allUsers.Add(user);
            FileUtil.SaveToFile(_allUsers, _fileName);

            Console.WriteLine($"Total users: {_allUsers.Count}");

            foreach (var item in _allUsers)
            {
                Console.WriteLine($"{item.FirstName} - {item.Role}");
            }

            Console.WriteLine($"Successfully created Instructor: {firstName} {lastName}");
        }

        public List<User> GetAdmins()
        {
            return _allUsers.Where(u => u.Role == Role.Admin || u.Role == Role.SuperAdmin).ToList();
        }

        public List<User> GetStudents()
        {
            return _allUsers.Where(u => u.Role == Role.Student).ToList();
        }

        public List<User> GetInstructors()
        {
            return _allUsers.Where(u => u.Role == Role.Instructor).ToList();
        }


    }
}