namespace TactiForge.API.Helper
{
    public interface IMailSettings
    {
        void SendEmail(Email email);
    }


    public class Email
    {
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }


}
