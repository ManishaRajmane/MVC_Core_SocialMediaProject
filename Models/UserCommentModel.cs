namespace MVC_Core_SocialMediaProject.Models
{
    public class UserCommentModel
    {
        public int comment_id { get; set; }
        public int user_id { get; set; }
        public string user_name { get; set; }
        public int content_id { get; set; }
        public string comment_message { get; set; }
        public DateTime comment_date { get; set; }
    }
}
