using studentportal.Enums;

namespace studentportal.Models
{
    public class BaseUser: BaseModel
    {
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string? PhoneNumber { get; set; }
        public string Email { get; set; } = default!;
        public string EncryptedPassword { get; set; } = default!;
        public string? Address { get; set; }
        public Role Role { get; set; } = default!;
        public double WalletBalance { get; private set; }

        public BaseUser(int id, string firstName, string lastName, string? phoneNumber, string email, string encryptedPassword, string? address, Role role, string createdBy)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Email = email;
            EncryptedPassword = encryptedPassword;
            Address = address;
            Role = role;
            CreatedBy = createdBy;
        }

        public override string ToString()
        {
            return $"ID: {Id}\tName: {FirstName} {LastName}\tPhoneNo: {PhoneNumber}\tEmail: {Email}\tAddress: {Address}\tUserType: {Role}\tWallet: {WalletBalance:C}";
        }

    }
}