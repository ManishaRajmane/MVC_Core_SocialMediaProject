using MVC_Core_SocialMediaProject.Models;

namespace MVC_Core_SocialMediaProject.Services.Interfaces
{
    public interface ITopicsServices
    {
        void AddTopics(Tbltopic topics);
        List<Tbltopic> GetTopics();
        Tbltopic GetTopic(int topic_id);
    }
}
