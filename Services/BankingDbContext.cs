using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Banky.Models.Entity;

namespace Banky.Services
{
    public class BankingDbContext:DbContext
    {
        public DbSet<Users> Users { get; set; }
        public DbSet<Account> Account { get; set; }
    }
}