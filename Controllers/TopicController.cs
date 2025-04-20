using Microsoft.AspNetCore.Mvc;
using MVC_Core_SocialMediaProject.Models;
using MVC_Core_SocialMediaProject.Services.Implementation;
using MVC_Core_SocialMediaProject.Services.Interfaces;

namespace MVC_Core_SocialMediaProject.Controllers
{
    public class TopicController : Controller
    {
        ITopicsServices _services;
        public TopicController(ITopicsServices services)
        {
            this._services = services;
        }

        public IActionResult Index()
        {
            ViewData["topics"] = _services.GetTopics();
            Tbltopic t = new Tbltopic();
            return View();
        }
        [HttpPost]
        public IActionResult Index(Tbltopic topic)
        {
            _services.AddTopics(topic);
            ModelState.Clear();
            ViewBag.msg = "Topics Added Successfully..!";
            ViewData["topics"] = _services.GetTopics();
            Tbltopic t = new Tbltopic();
            return View();
        }
        public JsonResult GetAllTopics()
        {
            return Json(_services.GetTopics());
        }
    }
}
