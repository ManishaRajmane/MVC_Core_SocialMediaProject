using Microsoft.AspNetCore.Mvc;

namespace MVC_Core_SocialMediaProject.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Dashboard()
        {
            if (HttpContext.Session.GetString("User_Name") == null)
            {
                return Redirect("/Account/Login");
            } 
            return View();
        }
    }
}
