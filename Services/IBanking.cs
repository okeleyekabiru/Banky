using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Banky.Models.Entity;

namespace Banky.Services
{
    public interface IBanking
    {
        void Add(Users user);
        Task<Users> Get(int mockId, bool includesAccount);
        Task<IEnumerable<Users>> GetAll( bool includesAccount);
        void UpdateUser(Users user, int mockId);
        void UpdateAccount(Account account ,int accountNumber);
        void DeleteUser(int mockId);

        void DeleteAccount(int accountnumber);
        List<Account> GellAllAccounts();
        Account GetAccount( int Accountnumber);
        void FreezeAccount(bool decision, int accountnumber);
        Task<bool> SaveChangesAsync();
    }
}