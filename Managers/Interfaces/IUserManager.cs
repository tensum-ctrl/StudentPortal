using studentportal.Models;
using studentportal.Enums;

namespace studentportal.Managers.Interfaces
{
    public interface IUserManager
{
    void InitializeDefaultSuperAdmin();

    User? Login();

    void CreateAdmin(string loginUser, Role role);

    User StudentRegister();

    void CreateInstructor(string loginUser);

    List<User> GetAdmins();

    List<User> GetStudents();

    List<User> GetInstructors();
}
}