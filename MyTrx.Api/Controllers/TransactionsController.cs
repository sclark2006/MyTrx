using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MyTrx.BusinessLogic.Models;
using MyTrx.BusinessLogic.Services;
using System.ComponentModel.DataAnnotations;

namespace MyTrx.Api.Controllers
{
    [Route("api/[controller]")]
    public class TransactionsController : Controller
    {
        private readonly ITransactionsQueryService _queryService;


        public TransactionsController(ITransactionsQueryService queryService)
        {
            _queryService = queryService;
        }

        // GET: api/transactions
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<TransactionModel>), 200)]
        public IActionResult Get(object options = null)
        {
           return Ok( _queryService.GetAll(options)); 
        }

        // GET api/transactions/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(TransactionModel), 200)]
        public IActionResult Get(int id)
        {
            return Ok(_queryService.GetById(id));
        }

        // POST api/transactions
        [HttpPost]
        public void Post([FromBody, Required] TransactionModel value)
        {
        }

        // PUT api/transactions/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]TransactionModel value)
        {
        }

        // DELETE api/transactions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
