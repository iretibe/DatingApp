using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DatingApp.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace DatingApp.API.Controllers
{
    // http://localhost:500/api/values
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly DataContext _ctx;

        public ValuesController(DataContext ctx)
        {
            _ctx = ctx;
        }

        // GET api/values
        [HttpGet]
        public async Task<IActionResult> GetValues()
        {
            var obj = await _ctx.Values.ToListAsync();

            return Ok(obj);
        }

        // GET api/values/5
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetValue(int id)
        {
            var obj = await _ctx.Values.FirstOrDefaultAsync(x => x.Id == id);

            return Ok(obj);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
