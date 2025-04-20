using Microsoft.AspNetCore.Mvc;
using MVC_Core_SocialMediaProject.Models;
using MVC_Core_SocialMediaProject.Services.Interfaces;
using System.Net.Sockets;

namespace MVC_Core_SocialMediaProject.Controllers
{
    public class VideoController : Controller
    {
        ITopicsServices topicsServices;
        ITopicContentServices topicContentServices;
        public VideoController(ITopicsServices topicsServices, ITopicContentServices topicContentServices)
        {
            this.topicsServices = topicsServices;
            this.topicContentServices = topicContentServices;
        }

        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("User_Name") == null)
            {
                return Redirect("/Account/Login");
            }
            List<TbltopicContent> contents = topicContentServices.GetTopicContents();
            return View(contents);
        }
        [HttpPost]
        public IActionResult Index(string txtfilter)
        {
            if (HttpContext.Session.GetString("User_Name") == null)
            {
                return Redirect("/Account/Login");
            }

            Tbltopic tp = topicsServices.GetTopics().FirstOrDefault(e => e.TopicName.ToLower().Contains(txtfilter.ToLower()));
            
            List<TbltopicContent> contents = topicContentServices.GetTopicWiseContent(tp.TopicId);
            return View(contents);
        }
        public IActionResult PlayVideo(int id)
        {
            TbltopicContent c = topicContentServices.GetTopicContent(id);
            Tbltopic t = topicsServices.GetTopic((int)c.TopicId);

            List<TbltopicContent> contents = topicContentServices.GetTopicWiseContent(t.TopicId);
            ViewData["contents"] = contents;
            List<UserCommentModel> comments = topicContentServices.GetContentWiseComments((int)c.ContentId);
            ViewData["comments"] = comments;
            List<TblcontentVideoLike> like = topicContentServices.GetContentWiseAllLikesAndDisLikes((int)c.ContentId);
            ViewData["like"]= like;
            return View(c);
        }
        public string AddComments(UserCommentModel uc)
        { 
            int user_id = (int)HttpContext.Session.GetInt32("User_Id");

            TblcontentUserComment c = new TblcontentUserComment() 
            {
             UserId = user_id,
              CommentDate = DateTime.Now,
               ContentId = uc.content_id,
                Comment = uc.comment_message
            };
            topicContentServices.AddContentVideoComment(c);

            return "Comment Added Successfully...";
        }
        public string AddLikeDisLike(TblcontentVideoLike cd)
        {
            int user_id = (int)HttpContext.Session.GetInt32("User_Id");

            cd.UserId = user_id;
            cd.LikeDate = DateTime.Now;

            topicContentServices.AddLikeDisLike(cd);
            return "Added Sucessfully..";
        }
    }
}
