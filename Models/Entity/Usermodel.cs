using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Banky.Models.Entity
{
    public class Usermodel
    {
        public int mockId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Account Account { get; set; } = new Account();
    }
}