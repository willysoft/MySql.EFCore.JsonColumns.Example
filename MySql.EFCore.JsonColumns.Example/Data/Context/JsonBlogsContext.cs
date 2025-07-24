using Microsoft.EntityFrameworkCore;
using MySql.EFCore.JsonColumns.Example.Data.Entitys;

namespace MySql.EFCore.JsonColumns.Example.Data.Context
{
    public partial class JsonBlogsContext : DbContext
    {
        public JsonBlogsContext(DbContextOptions<JsonBlogsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Author> Authors { get; set; }

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
