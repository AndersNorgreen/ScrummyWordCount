using Microsoft.EntityFrameworkCore;
using ScrummyWordCountApi.Infrastructure;

namespace ScrummyWordCountApi.Config;

public static class DatabaseConfig
{
    public static void ConfigureDatabase(this WebApplicationBuilder builder)
    {
        builder.Configuration.AddUserSecrets<Program>(); 
        
        var scrummyWordCountConnectionString = builder.Configuration.GetConnectionString("ScrummyWordCountDB");
        builder.Services.AddDbContext<ScrummyWordCountContext>(options => options.UseNpgsql(scrummyWordCountConnectionString, opt =>
        {
            opt.EnableRetryOnFailure(
                maxRetryCount: 5, 
                maxRetryDelay: TimeSpan.FromSeconds(10), 
                errorCodesToAdd: null);
        }));
    }
}