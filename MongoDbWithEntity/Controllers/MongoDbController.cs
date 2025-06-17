using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using MongoDbWithEntity.MongoDataBase;
using MongoDbWithEntity.MongoDataBase.Entity;
using System;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MongoDbWithEntity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MongoDbController : ControllerBase
    {
        private readonly developDbContext _context;
        public MongoDbController( developDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _context.Users.ToListAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
           var Id3=ObjectId.Parse(id);
            var product = await _context.Users.FirstOrDefaultAsync(x=>x.Id==Id3);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            await _context.AddAsync(user);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = user.Id.ToString() }, user);
        }
    }
}
