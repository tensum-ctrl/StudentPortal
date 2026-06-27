using studentportal.Models;
using studentportal.Enums;

namespace studentportal.Managers.Interfaces
{
    public interface IUserManager
    {
        void InitializeDefaultSuperAdmin();
       public User? Login();
        void CreateAdmin(string loginUser, Role role);
        public User StudentRegister();
    }
}