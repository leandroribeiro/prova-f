﻿using System;
using System.Collections.Generic;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using ProvaF.API.ViewModels;
using ProvaF.Domain.Entities;
using ProvaF.Domain.Exceptions;
using ProvaF.Domain.Services;

namespace ProvaF.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContasController : ControllerBase
    {
        private readonly IContaService _service;

        public ContasController(IContaService service)
        {
            _service = service;
        }

        [HttpGet("{numero}/saldo")]
        [ProducesResponseType(typeof(decimal), (int) HttpStatusCode.OK)]
        [ProducesResponseType((int) HttpStatusCode.NotFound)]
        public ActionResult<decimal> Get([FromRoute] int numero)
        {
            try
            {
                var saldo = _service.ObterSaldo(numero);
                return new OkObjectResult(saldo);
            }
            catch (ContaInvalidaValidationException e)
            {
                return new NotFoundObjectResult(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

        [HttpPost("{numero}/depositar")]
        [ProducesResponseType(typeof(DepositarResponse), (int) HttpStatusCode.OK)]
        [ProducesResponseType((int) HttpStatusCode.NotFound)]
        [ProducesResponseType((int) HttpStatusCode.BadRequest)]
        public ActionResult<decimal> Post([FromRoute] int numero, [FromBody] DepositarRequest model)
        {
            try
            {
                var saldo = _service.Depositar(numero, model.Valor);
                var response = new DepositarResponse(numero, saldo);
                
                return new OkObjectResult(response);
            }
            catch (ValorInvalidoValidationException e)
            {
                return new BadRequestObjectResult(e.Message);
            }
            catch (ContaInvalidaValidationException e)
            {
                return new NotFoundObjectResult(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        
        [HttpPost("{numero}/sacar")]
        [ProducesResponseType(typeof(SacarResponse), (int) HttpStatusCode.OK)]
        [ProducesResponseType((int) HttpStatusCode.NotFound)]
        [ProducesResponseType((int) HttpStatusCode.BadRequest)]
        public ActionResult<decimal> Post([FromRoute] int numero, [FromBody] SacarRequest model)
        {
            try
            {
                var saldo = _service.Sacar(numero, model.Valor);
                var response = new SacarResponse(numero, saldo);

                return new OkObjectResult(response);
            }
            catch (ValorInvalidoValidationException e)
            {
                return new BadRequestObjectResult(e.Message);
            }
            catch (ContaInvalidaValidationException e)
            {
                return new NotFoundObjectResult(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}