namespace MySql.EFCore.JsonColumns.Example.Models
{
    public class ContactDetails
    {
        public Address Address { get; set; } = null!;
        public string? Phone { get; set; }
    }
}
