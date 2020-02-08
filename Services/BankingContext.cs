using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Threading.Tasks;
using System.Web;
using Banky.Models.Entity;
using StackExchange.Profiling.Internal;

namespace Banky.Services
{
    public class BankingContext:IBanking
    {
        private readonly BankingDbContext _context;


        public BankingContext(BankingDbContext context )
        {
            _context = context;
        }

        public  void Add(Users user)
        {
             _context.Users.Add(user);
            


        }

        public async Task<Users> Get(int mockId, bool includesAccount)
        {
            if (includesAccount == false)
            {
               return  await _context.Users.Where(r => r.mockId == mockId).FirstOrDefaultAsync();
            }

            var response = await _context.Users.Include(b => b.Account).FirstAsync(R => R.mockId == mockId);

            return response;

        }

        public async Task<IEnumerable<Users>> GetAll(bool includesAccount )
        {
            if (includesAccount == false)
            {
                return await _context.Users.ToListAsync();
            }
            
            var response = await _context.Users.Include(b => b.Account).ToListAsync();

            return response;
        }

        public void UpdateUser(Users user)
        {
           
              _context.Users.Attach(user);
           _context.Entry(user).State = EntityState.Modified;
          
        }

        public void UpdateAccount(Account account, int accountNumber)
        {
           
        }

        public  void DeleteUser(Users user)
        {
            
            _context.Users.Remove(user);
           
        }

        public void DeleteAccount(int accountnumber)
        {
            throw new NotImplementedException();
        }

        public  async Task<IEnumerable<Account>> GellAllAccounts(int id)
        {
      var model =    await   _context.Account.Where(r => r.UserId == id).OrderBy(r => r.AccountType).ToListAsync();
      return model;
        }

        public Account GetAccount(int Accountnumber)
        {
            return _context.Account.Find(Accountnumber);
        }

        public void FreezeAccount(bool decision, int accountnumber)
        {
            throw new NotImplementedException();
        }
        public async Task<bool> SaveChangesAsync()
        {
            // Only return success if at least one row was changed
            return (await _context.SaveChangesAsync()) > 0;
        }

        public async Task<IEnumerable<Account>> GellAllAccounts()
        {
            return await _context.Account.ToListAsync();
        }
    }
}