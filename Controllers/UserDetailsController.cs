using Microsoft.AspNetCore.Mvc;
using MVC_Core_SocialMediaProject.Models;
using MVC_Core_SocialMediaProject.Services.Interfaces;

namespace MVC_Core_SocialMediaProject.Controllers
{
    public class UserDetailsController : Controller
    {
        IUserServices Services;
        public UserDetailsController(IUserServices userServices)
        { 
            Services = userServices;
        }
        public IActionResult Index()
        {
            List<Tbluser> lst =  Services.GetUsers();
            return View(lst);
        }
    }
}
