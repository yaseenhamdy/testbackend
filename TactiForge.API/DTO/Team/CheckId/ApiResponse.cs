using Microsoft.AspNetCore.Http;

namespace TactiForge.API.DTO.Team.CheckId
{
    public class ApiResponse
    {
        public int Status { get; set; }
        public string? Message { get; set; }

        public ApiResponse(int status, string? message=null)
        {
            Status = status;
            Message = message ?? GetDefaultMessageForStatusCode(status);
        }

        private string? GetDefaultMessageForStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "BadRequest",
                401 => "You Are Not Authorized",
                404 => "Not Found",
                500 => "Internal Server Error",
                _ => null
            };
        }
    }
}
