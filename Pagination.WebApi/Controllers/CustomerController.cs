using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pagination.WebApi.Contexts;
using Pagination.WebApi.Filter;
using Pagination.WebApi.Helpers;
using Pagination.WebApi.Models;
using Pagination.WebApi.Services;
using Pagination.WebApi.Wrappers;

namespace Pagination.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BondAppController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IUriService uriService;
        public BondAppController(ApplicationDbContext context, IUriService uriService)
        {
            this.context = context;
            this.uriService = uriService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] PaginationFilter filter)
        {
            var route = Request.Path.Value;
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
            var pagedData = await context.BondAppDatas
               .Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
               .Take(validFilter.PageSize)
               .ToListAsync();
            var totalRecords = await context.BondAppDatas.CountAsync();
            var pagedReponse = PaginationHelper.CreatePagedReponse<BondAppData>(pagedData, validFilter, totalRecords, uriService,route);
            return Ok(pagedReponse);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var customer = await context.BondAppDatas.Where(a => a.BondApplicationID == id).FirstOrDefaultAsync();
            return Ok(new Response<BondAppData>(customer));
        }
    }
}