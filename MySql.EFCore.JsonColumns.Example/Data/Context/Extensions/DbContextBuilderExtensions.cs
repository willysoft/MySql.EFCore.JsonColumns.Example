using Microsoft.EntityFrameworkCore;
using MySql.EFCore.JsonColumns.Example.Data.Context;
using MySqlConnector;

namespace Microsoft.AspNetCore.Builder
{
    public static class DbContextBuilderExtensions
    {
        /// <summary>
        /// 將 DbContext 新增至依賴注入容器。
        /// </summary>
        /// <param name="services">服務集合。</param>
        /// <returns>更新後的 <see cref="IServiceCollection"/>。</returns>
        public static IServiceCollection AddAppDbContext(this IServiceCollection services)
        {
            services.AddDbContextPool<JsonBlogsContext>(optionsAction: (sp, options) =>
            {
                var configuration = sp.GetRequiredService<IConfiguration>();
                var environment = sp.GetRequiredService<IHostEnvironment>();
                var connectionString = configuration.GetConnectionString("Blogs");
                var serverVersion = ServerVersion.Parse("8.4.2-u2-cloud");

                options.UseMySql(connectionString, serverVersion, options => options.UseMicrosoftJson()
                                                                                    .EnableRetryOnFailure(maxRetryCount: 3,
                                                                                                          maxRetryDelay: TimeSpan.FromMinutes(2),
                                                                                                          errorNumbersToAdd:
                                                                                                          [
                                                                                                              // 表示資料庫指令執行超時，可能原因包括查詢複雜、資料庫負載過高或網路延遲。
                                                                                                              (int)MySqlErrorCode.CommandTimeoutExpired,
                                                                                                              // 表示在寫入資料時發生網路錯誤，可能原因包括網路不穩定、連線中斷或中間設備干擾。
                                                                                                              (int)MySqlErrorCode.NetErrorOnWrite,
                                                                                                              // 表示資料庫發生死鎖，通常是因為多個交易爭用相同資源而互相等待，導致其中一個交易被迫中止。
                                                                                                              (int)MySqlErrorCode.LockDeadlock,
                                                                                                              // 表示等待資料庫鎖定超時，可能是因為其他交易長時間持有鎖定資源，導致目前操作無法及時取得所需資源。
                                                                                                              (int)MySqlErrorCode.LockWaitTimeout,
                                                                                                          ]))
                       .EnableSensitiveDataLogging(environment.IsDevelopment());
            });

            return services;
        }
    }
}
