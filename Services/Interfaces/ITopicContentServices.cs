using MVC_Core_SocialMediaProject.Models;

namespace MVC_Core_SocialMediaProject.Services.Interfaces
{
    public interface ITopicContentServices
    {
        void AddTopicContents(TbltopicContent content);
        List<TbltopicContent> GetTopicContents();
        List<TbltopicContent> GetTopicWiseContent(int topic_id);
        TbltopicContent GetTopicContent(int content_id);
        void AddContentVideoComment(TblcontentUserComment comment);
        List<UserCommentModel> GetContentWiseComments(int content_id);
        void AddLikeDisLike(TblcontentVideoLike v);
        List<TblcontentVideoLike> GetContentWiseAllLikesAndDisLikes(int content_id);
    }
}
