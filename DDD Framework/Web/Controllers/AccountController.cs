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
        [HttpGet]
        public HttpResponseMessage GetAccount([FromUri] string email)
        {
            try
            {
                AccountService accountService = new AccountService();
                Account account = accountService.GetAccount(email);
                return Request.CreateResponse(System.Net.HttpStatusCode.OK, account); 
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(System.Net.HttpStatusCode.InternalServerError, ex);
            }
        }

    }
}
