using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
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
        [Route()]
        [HttpGet]
        public async Task<IHttpActionResult >  Get(bool includesAccount = false)
        {
            
            try
            {
               
                
                var model = await _banking.GetAll( includesAccount:includesAccount) ;
//                var newMap = _mapper.Map<IEnumerable<Usermodel>>(model);
               
                    return Ok(model);
            
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }

            ;
        }
        [Route("{mockId}")]
        public async Task<IHttpActionResult> Get( int mockId, bool includesAccount = false)
        {
            try
            {
                var model = await _banking.Get(mockId, includesAccount: includesAccount);
                return Ok(model);
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
    }
}
