using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GetSQLSchemaAPI.Models;

namespace GetSQLSchemaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchemaController : ControllerBase
    {

        private azwideworldimportersdataDBContext _context;
        public SchemaController(azwideworldimportersdataDBContext context)
        {
            _context = context;
        }

        public IQueryable<Employee> FindAll()
        {
            return this._context.Set<Employee>();
        }


        //verb, what action are we trying to do
        //clinet is trying to request this API pattern

        [HttpGet("GetSchema")]
        public IEnumerable<Employee> Get([FromQuery] Pagination filter)
        {
            var Pagination = new Pagination(filter.pageSize, filter.pageNumber);
            return FindAll()
                .Skip((Pagination.pageNumber - 1) * Pagination.pageSize)
                .Take(Pagination.pageSize)
                .ToArray();

        }

        //request/require object {parameter} take object put by user and save it to DB
        [HttpPost("CreateSchema")]
        public IActionResult Create([FromBody] Employee request)
        {
            return BadRequest();
        }

        //frombody - suppose to take employee class properties
        [HttpPut("UpdateSchema")]
        public IActionResult Update([FromBody] Employee request)
        {
            return BadRequest();
        }

        //pass an Id par, and tell method that its suppose to take an Id
        [HttpDelete("DeleteSchema/{Id}")]
        public IActionResult Delete(int Id)
        {
            return BadRequest();
        }
    }
}
