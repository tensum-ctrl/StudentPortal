using System.Linq;
using System.Threading.Tasks;
using StudentPortal.Models;

namespace StudentPortal.Managers.Interfaces
{
    public interface IUserManager
    {
       public User? Login();
        void CreateAdmin(string loginUser);
        public User Register();
        void UpdateUser(string loginUser);
        public void UpdateUser(User user);
        void GetUserByEmail(string email);
        void GetUserById(int id);
        void GetAll();
    }
}