using MyTrx.BusinessLogic.Models;
using MyTrx.Data.Entities;
using MyTrx.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyTrx.BusinessLogic.Services
{
    public class TransactionsQueryService : ITransactionsQueryService
    {
        private readonly IRepository _repository;

        public TransactionsQueryService(IRepository repository)
        {
            _repository = repository;
        }


        public TransactionModel GetById(int id) {
            var trx = _repository.GetById<Transaction>(id);
            return MapToModel(trx);
        }

        public IEnumerable<TransactionModel> GetAll(object options)
        {
            var transactions = _repository.GetAll<Transaction>(options).ToList();
            return transactions.Select(entity => MapToModel(entity));
        }

        public TransactionModel MapToModel(Transaction transaction)
        {
            return new TransactionModel {
                Id = transaction.Id,
                Amount = transaction.Amount
            };
        }

        public IEnumerable<TransactionModel> FindByPayee(int payeeId)
        {
            var transactions = _repository.FindBy<Transaction>(x => x.PayeeId == payeeId).ToList();
            return transactions.Select(entity => MapToModel(entity));
        }

        public IEnumerable<TransactionModel> FindByAccount(int accountId)
        {
            var transactions = _repository.FindBy<Transaction>(x => x.AccountId == accountId).ToList();
            return transactions.Select(entity => MapToModel(entity));
        }

        public IEnumerable<TransactionModel> FindByCategory(int categoryId)
        {
            var transactions = _repository.FindBy<Transaction>(x => x.CategoryId == categoryId).ToList();
            return transactions.Select(entity => MapToModel(entity));
        }
    }
}
