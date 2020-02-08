using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Banky.Models.Entity
{
    public class Users
    {
        public int Id  { get; set; }
        public int mockId { get; set; }
        public string FirstName { get; set; }
        public string LastName{ get; set; }
        public  string Password { get; set; }
        public List<Account>Account { get; set; } = new List<Account>();
    }
}