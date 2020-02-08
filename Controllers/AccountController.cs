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
//        [HttpGet]
//        [Route("account")]
//        public async Task<IHttpActionResult> Get()
//        {
//            try
//            {
//                var model = await _banking.GellAllAccounts();
//                if (model !=  null)
//                {
//                    return Ok(model);
//                }
//            }
//            catch (Exception e)
//            {
//                return InternalServerError(e);
//            }
//
//            return NotFound();
//        }
    }
}
