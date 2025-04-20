using MVC_Core_SocialMediaProject.Models;

namespace MVC_Core_SocialMediaProject.Services.Interfaces
{
    public interface IExtraservice
    {
        void SendEmail (EmailModel email);
        string GetRandomPassword(int length);
        string GenerateOTP(int size);
    }
}
