using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using AutoMapper;
using Banky.Services;

namespace Banky.Controllers
{
  
    [RoutePrefix("api/banking/{mockId}/account")]
    public class AccountController : ApiController

    {
        private readonly IBanking _banking;
        private readonly IMapper _mapper;

        public AccountController(IBanking banking, IMapper mapper)
        {
            _banking = banking;
            _mapper = mapper;
        }
        [HttpGet]
        [Route()]
        public async Task<IHttpActionResult> Get(int mockId)
        {


            try
            {
                var model = await _banking.Get(mockId, true);
                if (model != null)
                {
                    var getallmodel = await _banking.GellAllAccounts(model.Id);
                    if (getallmodel != null)
                    {
                        return Ok(getallmodel);
                    }
                }
            }
            catch (Exception e)
            {
                InternalServerError(e);
            }

            return NotFound();

            
           
            
        }
        [HttpPut]
        [Route("deposit/{accountnumber:int}")]
        public async Task<IHttpActionResult> Put(int accountnumber,decimal amount )
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _banking.UpdateAccountBalance(amount, accountnumber);
                    if (await _banking.SaveChangesAsync())
                    {
                        return Ok();
                    }
                }
              
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }

            return NotFound();
        }
        [HttpPut]
        [Route("withdraw/{accountnumber:int}")]
        public async Task<IHttpActionResult> PutWithdraw(int accountnumber, decimal amount)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _banking.WithdrawFromBalance(amount, accountnumber);
                    if (await _banking.SaveChangesAsync())
                    {
                        return Ok();
                    }
                }

            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }

            return NotFound();
        }
        [HttpPut]
        [Route("transfer/{senderaccountnumber:int}/{receiverAccount:int}")]
        public async Task<IHttpActionResult> PutTransfer(int senderaccountnumber, int receiverAccount,decimal amount )
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _banking.Transfer(senderaccountnumber, amount, receiverAccount);
                    
                    if (await _banking.SaveChangesAsync())
                    {
                        return Ok();
                    }
                }

            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }

            return NotFound();
        }

    }
}
