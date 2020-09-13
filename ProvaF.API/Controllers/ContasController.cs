using System.Collections.Generic;
using System.Net;
using Microsoft.AspNetCore.Mvc;
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
        [ProducesResponseType(typeof(decimal), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BusinessRuleValidationException), (int)HttpStatusCode.InternalServerError)]
        public ActionResult<decimal> Get([FromRoute] int numero)
        {
            var saldo = _service.ObterSaldo(numero);

            return new OkObjectResult(saldo);
        }
    }
}