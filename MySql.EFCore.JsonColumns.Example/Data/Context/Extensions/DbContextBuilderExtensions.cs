using Microsoft.EntityFrameworkCore;
using MySql.EFCore.JsonColumns.Example.Data.Context;

namespace Microsoft.AspNetCore.Builder
{
    public static class DbContextBuilderExtensions
    {
        public static IServiceCollection AddAppDbContext(this IServiceCollection services)
        {
            services.AddDbContext<JsonBlogsContext>((sp, options) =>
            {
                var configuration = sp.GetRequiredService<IConfiguration>();
                var connectionString = configuration.GetConnectionString("Blogs");
                var serverVersion = ServerVersion.AutoDetect(connectionString);

                options.UseMySql(connectionString, serverVersion, options => options.UseMicrosoftJson());
            });

            return services;
        }
    }
}
