using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Banky.Models.Entity
{
    public class Account
    {
        public int Id { get; set; }
        public int  UserId { get; set; }
        public int  AccountNumber { get; set; }
        public AccountType AccountType { get; set; }
        public decimal Balance { get; set; }
        public bool IsActive { get; set; } = true;
    }
}