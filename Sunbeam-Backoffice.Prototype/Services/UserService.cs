using Sunbeam_Backoffice.Prototype.Models;
using Sunbeam_Backoffice.Prototype.Models.Common;

namespace Sunbeam_Backoffice.Prototype.Services
{
    public class UserService : IUserService
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<UserService> _logger;
        public UserService(IHttpClientFactory httpClientFactory, ILogger<UserService> logger)
        {
            _httpClientFactory = httpClientFactory;
            _httpClient = _httpClientFactory!.CreateClient("User");
            _logger = logger;
        }

        public async Task<Result<UserDto>> GetUserByEmailAsync(string email)
        {
            try
            {
                var response = await _httpClient.GetAsync($"/user-by-email/{email}");

                if (response.IsSuccessStatusCode)
                {
                    var user = await response.Content.ReadFromJsonAsync<UserDto>();
                    if (user != null)
                    {
                        return Result<UserDto>.Success(user);
                    }
                    else
                    {
                        return Result<UserDto>.Fail("User not found", (int)response.StatusCode);
                    }
                }
                else
                {
                    _logger.LogError($"Failed to get user by email {email}. Status code: {response.StatusCode}");
                    return Result<UserDto>.Fail("Service returned an error.", (int)response.StatusCode);
                }
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, "Network error occurred.");
                return Result<UserDto>.Fail("Network error occurred.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unexpected error occurred.");
                return Result<UserDto>.Fail("An unexpected error occurred.");
            }
        }
    }
}
