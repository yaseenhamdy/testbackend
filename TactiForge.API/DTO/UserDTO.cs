namespace TactiForge.API.DTO
{
    public class UserDTO
    {
        public string Email { get; set; }
        public string DisplayName { get; set; }
        public string Token { get; set; }
        public bool EmailConfirmed { get; set; }
        public StatusResponse Status { get; set; }
    }
}
