namespace TactiForge.API.Setting
{
    public class JwtOptions
    {
        public string Key { get; set; }
        public string ValidIssuer { get; set; }
        public string ValidAudience { get; set; }
        public string DurationInDays { get; set; }
    }
}
