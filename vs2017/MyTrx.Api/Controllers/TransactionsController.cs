using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MyTrx.BusinessLogic.Models;
using MyTrx.BusinessLogic.Services;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

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
        public IEnumerable<TransactionModel> Get(object options = null)
        {
           return _queryService.GetAll(options); 
        }

        // GET api/transactions/5
        [HttpGet("{id}")]
        public TransactionModel Get(int id)
        {
            return _queryService.GetById(id);
        }

        // POST api/transactions
        [HttpPost]
        public void Post([FromBody]TransactionModel value)
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
