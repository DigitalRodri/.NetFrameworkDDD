﻿using Domain.DTOs;
using Domain.Interfaces;
using System;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net.Http;
using System.Web.Http;

namespace Application.Controllers
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
        public HttpResponseMessage GetAccount([FromUri] Guid UUID)
        {
            try
            {
                AccountDto accountDTO = _accountService.GetAccount(UUID);
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
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(System.Net.HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpPut]
        public HttpResponseMessage UpdateAccount([FromUri] Guid UUID, SimpleAccountDto simpleAccountDto)
        {
            try
            {
                AccountDto modifiedAccount = _accountService.UpdateAccount(UUID, simpleAccountDto);
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
        public HttpResponseMessage DeleteAccount([FromUri] Guid UUID)
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