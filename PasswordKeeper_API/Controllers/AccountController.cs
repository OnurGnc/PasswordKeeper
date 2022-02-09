using Microsoft.AspNetCore.Mvc;
using PasswordKeeper_API.Entity.Context;
using PasswordKeeper_API.Entity.Model;
using System.Collections.Generic;
using System.Linq;
using System;

namespace PasswordKeeper_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly PasswordKeeperContext _context;

        public AccountController(PasswordKeeperContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<Account> accounts = _context.Accounts
                                    .Where(b => b.IsActive == true)
                                    .Select(a => new Account {
                                        AccountId = a.AccountId,
                                        ImageUrl = a.ImageUrl,
                                        Name = a.Name,
                                        Url = a.Url 
                                    })
                                    .ToList();
            return Ok(accounts);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Account account = _context.Accounts
                                .Where(a => a.AccountId == id && a.IsActive == true)
                                .Select(b=> new Account {
                                    AccountId = b.AccountId,
                                    Name = b.Name,
                                    Url = b.Url,
                                    ImageUrl = b.ImageUrl
                                }).FirstOrDefault();
            if (account != null)
                return Ok(account);
            else
                return NotFound();
        }

        [HttpPost]
        public IActionResult Post([FromBody] Account account)
        {
            if (account != null && !string.IsNullOrEmpty(account.Name) && !string.IsNullOrEmpty(account.ImageUrl))
            {
                account.IsActive = true;
                account.ModifiedDate = DateTime.Now;
                account.ModifiedUser = "Admin";
                _context.Accounts.Add(account);
                _context.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Account account)
        {
            if (id != account.AccountId)
            {
                return BadRequest();
            }
            else if(!_context.Accounts.Any(a => a.AccountId == id))
            {
                return NotFound();
            }
            else
            {
                account.IsActive = true;
                account.ModifiedDate = DateTime.Now;
                account.ModifiedUser = "Admin";
                _context.Entry(account).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
                return Ok();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Account account = _context.Accounts.Where(a => a.AccountId == id && a.IsActive == true).FirstOrDefault();
            if (account != null)
            {
                account.IsActive = false;
                account.ModifiedDate = DateTime.Now;
                account.ModifiedUser = "Admin";
                _context.Accounts.Update(account);
                _context.SaveChanges();
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
