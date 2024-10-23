using Sunbeam_Backoffice.Prototype.Services;


namespace Sunbeam_Backoffice.Prototype.StartupExtensions
{
    public static class DependencyInjections
    {

        public static void InjectServices(WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IUserService, UserService>();
        }
    }
}
