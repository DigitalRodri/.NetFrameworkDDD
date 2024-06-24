using Application;
using Application.Service;
using System;
using System.Net.Http;
using System.Web.Http;

namespace Web.Controllers
{
    [RoutePrefix("Account")]
    public class AccountController : ApiController
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        public HttpResponseMessage GetAccount([FromUri] string email)
        {
            try
            {
                Account account = _accountService.GetAccount(email);
                return Request.CreateResponse(System.Net.HttpStatusCode.OK, account); 
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(System.Net.HttpStatusCode.InternalServerError, ex);
            }
        }

    }
}
