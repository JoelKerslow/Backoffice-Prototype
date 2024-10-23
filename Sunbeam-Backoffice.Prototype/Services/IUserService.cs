using Sunbeam_Backoffice.Prototype.Models;
using Sunbeam_Backoffice.Prototype.Models.Common;

namespace Sunbeam_Backoffice.Prototype.Services
{
    public interface IUserService
    {
        Task<Result<UserDto>> GetUserByEmailAsync(string email);
    }
}