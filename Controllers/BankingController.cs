using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using AutoMapper;
using Banky.Models.Entity;
using Banky.Services;

namespace Banky.Controllers
{[RoutePrefix("api/banking")]
    public class BankingController : ApiController
    {
        private readonly IBanking _banking;
        private readonly IMapper _mapper;

        public BankingController(IBanking banking, IMapper mapper)
        {
            _banking = banking;
            _mapper = mapper;
        }
        [Route("user")]
        [HttpGet]
        public async Task<IHttpActionResult >  Get(bool includesAccount = false)
        {
            
            try
            {
               
                
                var model = await _banking.GetAll( includesAccount:includesAccount) ;
//                var newMap = _mapper.Map<IEnumerable<Usermodel>>(model);
                if (model == null) return NotFound();
             
               
                    return Ok(model);
            
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }

            ;
        }
        [Route("user/{mockId}")]
        public async Task<IHttpActionResult> Get( int mockId, bool includesAccount = false)
        {
            try
            {
                var model = await _banking.Get(mockId, includesAccount: includesAccount);
                if (model == null) return NotFound();
                var map = _mapper.Map<Usermodel>(model);
                return Ok(map);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }

           
        }
        [HttpPost]
[Route()]
        public async Task<IHttpActionResult> Post(Users user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                   _banking .Add(user);
                   if (await _banking.SaveChangesAsync() )
                   {
                       return Ok();
                   }
                 
                }
            }
            catch (Exception e)
            {
              return InternalServerError(e);
            }

            return BadRequest();
        }
        [Route("{mockId}")]
        [HttpPut]
        public async Task<IHttpActionResult> Put(int mockId , Users user, bool includeAccount = false)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var users = await _banking.Get(mockId, includeAccount);

                    if (users != null)
                    {
                        users.mockId = user.mockId;
                        users.FirstName = user.FirstName;
                        users.Password = user.Password;
                        _banking.UpdateUser(users);
                       if (await _banking.SaveChangesAsync())
                       {
                       return    Ok(users);
                       }
                    }

                }
             
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }

            return BadRequest(modelState: ModelState);
        }
        [Route("{mockId}")]
        [HttpDelete]
        public async Task<IHttpActionResult> Delete(int mockId,bool includesAccount = false)
        {
            try
            {
                var model =  await _banking.Get(mockId, includesAccount: includesAccount);
                if (model != null)
                {
                _banking.DeleteUser(model);
                if (await  _banking.SaveChangesAsync())
                {
                    return Ok(model);
                }
                }
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }

            return NotFound();
        }
        [HttpGet]
        [Route("account")]
        public async Task<IHttpActionResult> Get()
        {
            try
            {
                var model = await _banking.GellAllAccounts();
                if (model != null)
                {
                    return Ok(model);
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
