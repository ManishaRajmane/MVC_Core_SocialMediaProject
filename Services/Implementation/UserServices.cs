using MVC_Core_SocialMediaProject.Models;
using MVC_Core_SocialMediaProject.Services.Interfaces;

namespace MVC_Core_SocialMediaProject.Services.Implementation
{
    public class UserServices : IUserServices
    {
        CiitcoderDbContext _context;
        public UserServices(CiitcoderDbContext context)
        {
            _context = context;
        }
        public void AddUser(Tbluser user)
        {
            _context.Tblusers.Add(user);
            _context.SaveChanges();
        }

        public Tbluser CheckUserLogin(string email_address, string password)
        {
            Tbluser u = null;
            u = _context.Tblusers.ToList().FirstOrDefault(e => e.EmailAddress.ToLower().Equals(email_address) & e.Password.Equals(password));
            return u;
        }

        public Tbluser GetUser(int id)
        {
            return _context.Tblusers.Find(id);
        }

        public List<Tbluser> GetUsers()
        {
            return _context.Tblusers.ToList();
        }
    }
}
