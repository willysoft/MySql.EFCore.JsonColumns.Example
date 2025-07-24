using Microsoft.AspNetCore.Mvc;
using MySql.EFCore.JsonColumns.Example.Data.Context;
using MySql.EFCore.JsonColumns.Example.Data.Entitys;

namespace MySql.EFCore.JsonColumns.Example.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthorsController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get(JsonBlogsContext dbContext)
        {
            var authors = dbContext.Authors.ToArray();
            return Ok(authors);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Author author, JsonBlogsContext dbContext)
        {
            dbContext.Authors.Add(author);
            await dbContext.SaveChangesAsync();

            return NoContent();
        }
    }
}
