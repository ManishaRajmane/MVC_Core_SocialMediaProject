namespace MVC_Core_SocialMediaProject.Models
{
    public class EmailSettings
    {
        public string UserName { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
        public bool UseSSL { get; set; }
    }
}
