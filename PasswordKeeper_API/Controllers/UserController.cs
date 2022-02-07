using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PasswordKeeper_API.Entity.Context;
using PasswordKeeper_API.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PasswordKeeper_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly PasswordKeeperContext _context;

        public UserController(PasswordKeeperContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var users = _context.Users.ToList();
            if (users != null || users.Count > 0)
                return Ok(users);
            else
                return NoContent();
        }

        [HttpPost]
        public IActionResult Register([FromBody] User user)
        {
            try
            {
                _context.Users.Add(user);
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult Login([FromBody] User user)
        {
            try
            {
                var SignUpUser = _context.Users
                                .Where(a => a.Username == user.Username && a.Password == user.Password && a.IsActive == true)
                                .Select(b => new User { Username = b.Username, Email = b.Email })
                                .FirstOrDefault();
                if (SignUpUser != null)
                    return Ok(SignUpUser);
                else
                    return BadRequest();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
