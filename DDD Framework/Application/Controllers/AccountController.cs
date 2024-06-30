using Application.Tags;
using Domain.DTOs;
using Domain.Interfaces;
using System;
using System.Data;
using System.Net.Http;
using System.Web.Http;

namespace Application.Controllers
{
    [RequiresAuthorization]
    [RoutePrefix("api/account")]
    public class AccountController : ApiController
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        [Route("{UUID:Guid}")]
        public HttpResponseMessage GetAccount(Guid UUID)
        {
            try
            {
                AccountDto accountDTO = _accountService.GetAccount(UUID);

                if (accountDTO == null) return Request.CreateResponse(System.Net.HttpStatusCode.NoContent);
                return Request.CreateResponse(System.Net.HttpStatusCode.OK, accountDTO); 
            }
            catch (ArgumentException ex)
            {
                return Request.CreateErrorResponse(System.Net.HttpStatusCode.BadRequest, ex);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(System.Net.HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpPost]
        [Route("")]
        public HttpResponseMessage CreateAccount(SimpleAccountDto simpleAccountDto)
        {
            try
            {
                AccountDto accountDTO = _accountService.CreateAccount(simpleAccountDto);
                return Request.CreateResponse(System.Net.HttpStatusCode.Created, accountDTO);
            }
            catch (ArgumentException ex)
            {
                return Request.CreateErrorResponse(System.Net.HttpStatusCode.BadRequest, ex);
            }
            catch (DuplicateNameException ex)
            {
                return Request.CreateErrorResponse(System.Net.HttpStatusCode.Conflict, ex);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(System.Net.HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpPut]
        [Route("{UUID:Guid}")]
        public HttpResponseMessage UpdateAccount(Guid UUID, UpdateAccountDto updateAccountDto)
        {
            try
            {
                AccountDto modifiedAccount = _accountService.UpdateAccount(UUID, updateAccountDto);
                return Request.CreateResponse(System.Net.HttpStatusCode.OK, modifiedAccount);
            }
            catch (ArgumentException ex)
            {
                return Request.CreateErrorResponse(System.Net.HttpStatusCode.BadRequest, ex);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(System.Net.HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpDelete]
        [Route("{UUID:Guid}")]
        public HttpResponseMessage DeleteAccount(Guid UUID)
        {
            try
            {
                _accountService.DeleteAccount(UUID);
                return Request.CreateResponse(System.Net.HttpStatusCode.OK);
            }
            catch (ArgumentException ex)
            {
                return Request.CreateErrorResponse(System.Net.HttpStatusCode.BadRequest, ex);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(System.Net.HttpStatusCode.InternalServerError, ex);
            }
        }

    }
}
