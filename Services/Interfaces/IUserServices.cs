using MVC_Core_SocialMediaProject.Models;

namespace MVC_Core_SocialMediaProject.Services.Interfaces
{
    public interface IUserServices
    {
        void AddUser(Tbluser user);
        List<Tbluser> GetUsers();
        Tbluser GetUser(int id);
        Tbluser CheckUserLogin(string email_address, string password);
    }
}
