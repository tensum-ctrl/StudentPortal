using studentportal.Enums;

namespace studentportal.Models
{
    public class User : BaseUser
    {
        public string? StaffId { get; set; }

        public User(
            int id,
            string firstName,
            string lastName,
            string? phoneNumber,
            string email,
            string encryptedPassword,
            string? address,
            Role role,
            string createdBy,
            string? staffId = null
        ) : base(id, firstName, lastName, phoneNumber, email, encryptedPassword, address, role, createdBy)
        {
            StaffId = staffId;
        }
    }
}