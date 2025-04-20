using MVC_Core_SocialMediaProject.Models;
using MVC_Core_SocialMediaProject.Services.Interfaces;

namespace MVC_Core_SocialMediaProject.Services.Implementation
{
    public class TopicContentServices : ITopicContentServices
    {
        CiitcoderDbContext _context;
        public TopicContentServices(CiitcoderDbContext context)
        {
            _context = context;
        }

        public void AddContentVideoComment(TblcontentUserComment comment)
        {
            _context.TblcontentUserComments.Add(comment);
            _context.SaveChanges();
        }

        public void AddLikeDisLike(TblcontentVideoLike v)
        {
            _context.TblcontentVideoLikes.Add(v);
            _context.SaveChanges();
        }

        public void AddTopicContents(TbltopicContent content)
        {
            _context.TbltopicContents.Add(content);
            _context.SaveChanges();
        }

        public List<TblcontentVideoLike> GetContentWiseAllLikesAndDisLikes(int content_id)
        {
            return _context.TblcontentVideoLikes.ToList().Where(e=>e.ContentId.Equals(content_id)).ToList();
        }

        public List<UserCommentModel> GetContentWiseComments(int content_id)
        {
            List<UserCommentModel> lst = new List<UserCommentModel>();

            List<TblcontentUserComment> comments = _context.TblcontentUserComments.ToList().Where(e=>e.ContentId.Equals(content_id)).ToList().OrderByDescending(e=>e.CommentDate).ToList();

            foreach (TblcontentUserComment c in comments)
            {
                Tbluser u = _context.Tblusers.Find(c.UserId);
                UserCommentModel uc = new UserCommentModel()
                {
                    comment_id = c.CommentId,
                    comment_date = (DateTime)c.CommentDate,
                     comment_message =c.Comment,
                     content_id=(int)c.ContentId,
                      user_id = (int)c.UserId,
                       user_name = u.UserName
                };
                lst.Add(uc);
            }
            return lst;
        }

        public TbltopicContent GetTopicContent(int content_id)
        {
            return _context.TbltopicContents.Find(content_id);
        }

        public List<TbltopicContent> GetTopicContents()
        {
            return _context.TbltopicContents.ToList();
        }

        public List<TbltopicContent> GetTopicWiseContent(int topic_id)
        {
            return _context.TbltopicContents.ToList().Where(e=>e.TopicId.Equals(topic_id)).ToList();
        }
    }
}
