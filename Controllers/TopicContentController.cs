using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC_Core_SocialMediaProject.Models;
using MVC_Core_SocialMediaProject.Services.Implementation;
using MVC_Core_SocialMediaProject.Services.Interfaces;

namespace MVC_Core_SocialMediaProject.Controllers
{
    public class TopicContentController : Controller
    {
        ITopicContentServices contentservices;
        IWebHostEnvironment _env;
        ITopicsServices topicServices;
        public TopicContentController(ITopicsServices topicServices,ITopicContentServices contentservices, IWebHostEnvironment env)
        {
            this.contentservices = contentservices;
            this._env = env;
            this.topicServices = topicServices;
        }

        public IActionResult Index()
        {
            ViewBag.topics = new SelectList(topicServices.GetTopics(), "TopicId", "TopicName");
            ViewData["contents"] = contentservices.GetTopicContents();
            TbltopicContent t = new TbltopicContent();
            return View(t);
        }
        [HttpPost]
        [RequestSizeLimit(2000L*1024L*1024L*1024L)]
        [RequestFormLimits(MultipartBodyLengthLimit =2004L*1024L*1024L*1024L)]
        public IActionResult Index(TbltopicContent ct,IFormFile photo,IFormFile video)
        {
            string topicfolder = _env.WebRootPath + "/TopicContent/" + ct.TopicId;
            if (!Directory.Exists(topicfolder))
            {
                Directory.CreateDirectory(topicfolder);        
            }
            string imgnmae = ct.ContentName + Path.GetExtension(photo.FileName);
            string imgpath = topicfolder + "/" + imgnmae;
            FileStream fs = new FileStream(imgpath, FileMode.Create);
            photo.CopyTo(fs);
            ct.CoverPhoto = imgnmae;

            string vidname = ct.ContentName + Path.GetExtension(video.FileName);
            string vidpath = topicfolder + "/" + vidname;
            FileStream fsv = new FileStream(vidpath, FileMode.Create);
            video.CopyTo(fsv);
            ct.VideoUrl = vidname;
            contentservices.AddTopicContents(ct);
            ModelState.Clear();
            ViewBag.msg = "Topic Content Added Successfully....";
            ViewData["contents"] = contentservices.GetTopicContents();

            ViewBag.topics = new SelectList(topicServices.GetTopics(), "TopicId", "TopicName");
            TbltopicContent t = new TbltopicContent();
            return View(t);
        }
        public IActionResult Videos()
        {
            List<TbltopicContent> lst = contentservices.GetTopicContents();
            return View(lst);
        }
    }
}
