using MySql.EFCore.JsonColumns.Example.Models;

namespace MySql.EFCore.JsonColumns.Example.Data.Entitys
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public ContactDetails Contact { get; set; }
    }
}
