using DatingApp.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatingApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly DatabaseContext _dbContex;
        public ValuesController(DatabaseContext context)
        {
            _dbContex = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var users = await _dbContex.Users.ToListAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var user = await _dbContex.Users.FirstOrDefaultAsync(x=> x.Id == id);
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> Post(User user)
        {

                     _dbContex.Users.Add(user);
           int row = await _dbContex.SaveChangesAsync();
            if(row > 0)
            {
                return Ok(user);

            }
            return NotFound();

        }
        [HttpPut]
        public async Task<IActionResult> Put(User user)
        {
            var _user = await _dbContex.Users.FirstOrDefaultAsync(x => x.Id == user.Id);
            if(user != null)
            {
                _user.Name = user.Name;
            }
            int row = await _dbContex.SaveChangesAsync();
            if(row  > 0)
            {
                return Ok("User Updated Successfully");

            }
            else
            {
                return Ok("User Can't be Updated");
            }
        }

    }
}
