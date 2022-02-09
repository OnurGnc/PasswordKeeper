using Microsoft.EntityFrameworkCore;
using PasswordKeeper_API.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PasswordKeeper_API.Entity.Context
{
    public class PasswordKeeperContext : DbContext
    {
        public PasswordKeeperContext(DbContextOptions<PasswordKeeperContext> options) : base(options)
        {

        }

        //public DbSet<User> Users { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<User_Account> User_Account { get; set; }
    }
}
