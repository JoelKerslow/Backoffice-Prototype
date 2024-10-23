namespace Sunbeam_Backoffice.Prototype.StartupExtensions
{
    public static class HttpClientConfig
    {
        public static void ConfigureHttpClients(WebApplicationBuilder builder)
        {
            builder.Services.AddHttpClient("User", client =>
            {
                client.BaseAddress = new Uri(builder.Configuration["USERSERVICE_BASEURL"]!);
            });

            builder.Services.AddHttpClient("Asset", client =>
            {
                client.BaseAddress = new Uri(builder.Configuration["ASSETSERVICE_BASEURL"]!);
            });

            builder.Services.AddHttpClient("Solar", client =>
            {
                client.BaseAddress = new Uri(builder.Configuration["SOLARSERVICE_BASEURL"]!);
            });
        }
    }
}
