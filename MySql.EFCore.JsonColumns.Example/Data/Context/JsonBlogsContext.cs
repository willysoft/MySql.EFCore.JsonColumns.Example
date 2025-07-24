using Microsoft.EntityFrameworkCore;
using MySql.EFCore.JsonColumns.Example.Data.Entitys;

namespace MySql.EFCore.JsonColumns.Example.Data.Context
{
    public partial class JsonBlogsContext : DbContext
    {
        private readonly IConfiguration m_Configuration;
        private readonly IHostEnvironment m_Environment;

        /// <summary>
        /// 初始化 CmsDbContext 類別的新執行個體。
        /// </summary>
        /// <param name="options">資料庫上下文選項。</param>
        /// <param name="configuration">應用程式配置。</param>
        /// <param name="environment">應用程式環境。</param>
        public JsonBlogsContext(DbContextOptions<JsonBlogsContext> options, IConfiguration configuration, IHostEnvironment environment)
            : base(options)
        {
            m_Configuration = configuration;
            m_Environment = environment;
        }

        /// <summary>
        /// 作者資料表
        /// </summary>
        public virtual DbSet<Author> Authors { get; set; }

        /// <summary>
        /// 配置模型和資料表的對應關係。
        /// </summary>
        /// <param name="modelBuilder">模型建構器。</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb3_bin")
                        .HasCharSet("utf8mb3");

            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
