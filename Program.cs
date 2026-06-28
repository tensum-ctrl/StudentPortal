using studentportal.Managers.Implementations;
using studentportal.Menus;
using studentportal.Enums;

var userManager = new UserManager();

var adminMenu = new AdminMenu(userManager);

var user = userManager.Login();

if (user != null &&
    (user.Role == Role.Admin || user.Role == Role.SuperAdmin))
{
    adminMenu.Show(user);
}
else
{
    Console.WriteLine("Invalid login or access denied.");
    Console.WriteLine(AppDomain.CurrentDomain.BaseDirectory);
}