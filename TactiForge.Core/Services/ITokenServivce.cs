using TactiForge.Core.Identity;

namespace TactiForge.Core.Services
{
    public interface ITokenService
    {
        Task<string> CreateTokenAsync(AppUser user, int teamId, int coachId);
    }
}
