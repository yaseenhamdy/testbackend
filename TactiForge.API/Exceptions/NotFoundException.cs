namespace TactiForge.API.Exceptions
{
    public class NotFoundException : Exception
    {
        public int Status { get; set; }
        public string Message { get; set; }
    }
}
