using Microsoft.AspNetCore.Mvc;
using MVC_Core_SocialMediaProject.Models;
using MVC_Core_SocialMediaProject.Services.Interfaces;

namespace MVC_Core_SocialMediaProject.Controllers
{
    public class AccountController : Controller
    {
        IWebHostEnvironment env;
        IUserServices userServices;
        IExtraservice extrasService;
        public AccountController(IWebHostEnvironment env,IUserServices userServices,IExtraservice extraservice)
        { 
            this.env = env;
            this.userServices = userServices;
            this.extrasService = extraservice;
        }
        public IActionResult Login()
        {
            if (HttpContext.Session.GetString("User_Name") != null)
            {
                return Redirect("/Admin/Dashboard");
            }
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginModel m)
        {
            if (m.UserName == "admin" && m.Password == "admin")
            {
                HttpContext.Session.SetString("User_Name", m.UserName);
                return Redirect("/Admin/Dashboard");
            }
            else
            {
                Tbluser ur = userServices.CheckUserLogin(m.UserName, m.Password);
                if (ur != null)
                {
                    HttpContext.Session.SetString("User_Name", ur.EmailAddress);
                    HttpContext.Session.SetInt32("User_Id", ur.UserId);
                    return Redirect("/Video/Index");

                }
                else
                {
                    ViewBag.msg = "Invalid User Name or Password";
                    return View();
                }
            }
        }
        public IActionResult Register()
        {
            Tbluser t = new Tbluser();
            return View(t);
        }
        [HttpPost]
        public IActionResult Register(Tbluser u,IFormFile photo)
        {
            string password = extrasService.GetRandomPassword(10);
            u.Password = password;

            string imgname = u.UserName+DateTime.Now.Year+DateTime.Now.Month+DateTime.Now.Day+DateTime.Now.Millisecond+Path.GetExtension(photo.FileName);
            string imgpath = env.WebRootPath + "/Users/" + imgname;

            FileStream fs = new FileStream(imgpath, FileMode.Create,FileAccess.Write);
            photo.CopyTo(fs);
            u.UserPhoto = imgname;
            u.JoiningDate = DateTime.Now;
            userServices.AddUser(u);
            ModelState.Clear();
            ViewBag.msg = "User Registered Successfully..";

            string msg = "<h2>Dear " + u.UserName + ",</h2><p>Your Account has Been Created Successfully.</p><p>Your Login Details are as Below</p><p>User Name = <b></b>"+u.EmailAddress+"</p><p>Password = <b>"+password+"</b></p>";
            
            EmailModel email = new EmailModel()
            { 
             UserName = u.UserName,
             EmailAddress = u.EmailAddress,
             Message = msg,
             Subject="User Registration Confirmation"
            };

            extrasService.SendEmail(email);
            Tbluser t = new Tbluser();
            return View(t);
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("User_Name");
            return RedirectToAction("Login");
        }
    }
}
