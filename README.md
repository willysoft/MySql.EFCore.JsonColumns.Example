# MySql.EFCore.JsonColumns.Example

## Quick Start

1. First, navigate to your project folder (in this example, it's `MySql.EFCore.JsonColumns.Example`):
   ```shell
   cd ./MySql.EFCore.JsonColumns.Example
   ```
2. Use the `dotnet user-secrets` command to set your database connection string. Here, "`ConnectionStrings:Blogs`" is used as the key:
   ```shell
   dotnet user-secrets set "ConnectionStrings:Blogs" "<your_connection_string>"
   ```
   Remember to replace `<your_connection_string>` with your actual connection string.

3. Update to the latest migration:
   ```shell
   dotnet ef database update --context JsonBlogsContext
   ```

#### Reference Documents

- [ASP.NET Core Application Secrets Management](https://learn.microsoft.com/en-us/aspnet/core/security/app-secrets?view=aspnetcore-9.0&tabs=windows)
- [EF Core Migrations Management](https://learn.microsoft.com/en-us/ef/core/managing-schemas/migrations/managing?tabs=dotnet-core-cli)
- [Applying EF Core Migrations](https://learn.microsoft.com/en-us/ef/core/managing-schemas/migrations/applying?tabs=dotnet-core-cli)