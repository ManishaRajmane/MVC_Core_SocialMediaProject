using MVC_Core_SocialMediaProject.Models;
using MVC_Core_SocialMediaProject.Services.Interfaces;

namespace MVC_Core_SocialMediaProject.Services.Implementation
{
    public class TopicServices : ITopicsServices
    {
        CiitcoderDbContext _context;
        public TopicServices(CiitcoderDbContext context)
        { 
            _context = context;
        }
        public void AddTopics(Tbltopic topics)
        {
            _context.Tbltopics.Add(topics);
            _context.SaveChanges();
        }

        public Tbltopic GetTopic(int topic_id)
        {
            return _context.Tbltopics.Find(topic_id);
        }

        public List<Tbltopic> GetTopics()
        {
            return _context.Tbltopics.ToList();
        }
    }
}
