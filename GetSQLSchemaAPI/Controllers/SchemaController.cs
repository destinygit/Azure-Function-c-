﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GetSQLSchemaAPI.Models;
using GetSQLSchemaAPI.Services;
using GetSQLSchemaAPI.Helpers;
using Microsoft.EntityFrameworkCore;

namespace GetSQLSchemaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchemaController : ControllerBase
    {

        private readonly azwideworldimportersdataDBContext _context;
        private readonly IUriService uriService;
        public SchemaController(azwideworldimportersdataDBContext context, IUriService uriService)
        {
            this._context = context;
            this.uriService = uriService;
        }

        public IQueryable<Employee> FindAll()
        {
            return this._context.Set<Employee>();
        }


        //verb, what action are we trying to do
        //clinet is trying to request this API pattern

        [HttpGet("GetSchema")]
        public async Task<IActionResult> GetAll([FromQuery] Pagination filter)
        {
            var route = Request.Path.Value;
            var validFilter = new Pagination(filter.pageSize, filter.pageNumber);
            var pagedData = await _context.Employees
               .Skip((validFilter.pageNumber - 1) * validFilter.pageSize)
               .Take(validFilter.pageSize)
               .ToListAsync();
            var totalRecords = await _context.Employees.CountAsync();
            var pagedReponse = PaginationHelperscs.CreatePagedReponse<Employee>(pagedData, validFilter, totalRecords, uriService, route);
            return Ok(pagedReponse);
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
