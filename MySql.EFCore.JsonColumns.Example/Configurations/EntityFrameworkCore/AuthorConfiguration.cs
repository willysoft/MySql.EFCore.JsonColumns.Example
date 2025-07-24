using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MySql.EFCore.JsonColumns.Example.Data.Entitys;

namespace MySql.EFCore.JsonColumns.Example.Configurations.EntityFrameworkCore
{
    public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.Property(e => e.Contact)
                .HasColumnType("json");
        }
    }
}
