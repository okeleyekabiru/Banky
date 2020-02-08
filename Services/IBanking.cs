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
        void UpdateUser(Users user);
        void UpdateAccountBalance(decimal Balance,int accountNumber);
        void DeleteUser(Users user);

        void DeleteAccount(int accountnumber);
        Task<IEnumerable<Account>> GellAllAccounts(int id);
        Task<IEnumerable<Account>> GellAllAccounts();
        Account GetAccount( int Accountnumber);
        void FreezeAccount(bool decision, int accountnumber);

        void WithdrawFromBalance(decimal Balance, int accountNumber);
     void Transfer(int senderaccountnumber, decimal amount, int receiverAccount);
        Task<bool> SaveChangesAsync();
    }
}