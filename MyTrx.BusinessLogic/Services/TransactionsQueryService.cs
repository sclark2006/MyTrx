using MyTrx.BusinessLogic.Models;
using MyTrx.Data.Entities;
using MyTrx.Data.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace MyTrx.BusinessLogic.Services
{
    public interface ITransactionsQueryService: IQueryService<TransactionModel,Transaction>
    {
        IEnumerable<TransactionModel> FindByPayee(int payeeId);

        IEnumerable<TransactionModel> FindByAccount(int accountId);

        IEnumerable<TransactionModel> FindByCategory(int categoryId);
    }


    public class TransactionsQueryService : ITransactionsQueryService
    {
        private readonly IRepository _repository;

        public TransactionsQueryService(IRepository repository)
        {
            _repository = repository;
        }


        public TransactionModel GetById(int id) {
            var trx = _repository.GetById<Transaction>(id);
            return MapToEditModel(trx);
        }

        public IEnumerable<TransactionModel> GetAll(object options)
        {
            var transactions = _repository.GetAll<Transaction>("Category","Payee","Account").OrderBy(x => x.Date).ThenBy(x => x.Id);
            var result =  transactions.Select(entity => MapToListModel(entity)).ToList();
            if(result.Any())
            {
                var first = result.First();
                first.RunningBalance = first.Amount;
                result.Aggregate((prev, current) => { current.RunningBalance = prev.RunningBalance + current.Amount; return current; });
            }
            return result;
        }

        public TransactionModel MapToListModel(Transaction transaction)
        {
            return new TransactionModel {
                Id = transaction.Id,
                Date = transaction.Date,
                Type = transaction.Type,
                AccountName = transaction.Account?.Name,
                TargetAccountName = transaction.TargetAccount?.Name,
                PayeeName = transaction.Payee?.Name,
                CategoryName = transaction.Category?.Name,
                Amount = transaction.Amount,
                Cleared = transaction.Cleared,
                Flag = transaction.Flag,
                Reconciled = transaction.Reconciled
            };
        }

        public TransactionModel MapToEditModel(Transaction transaction)
        {
            var result = MapToListModel(transaction);

            result.AccountId = transaction.AccountId;
            result.PayeeId = transaction.PayeeId;
            result.CategoryId = transaction.CategoryId;
            result.TargetAccountId = transaction.TargetAccountId;

            return result;
        }        

        public IEnumerable<TransactionModel> FindByPayee(int payeeId)
        {
            var transactions = _repository.FindBy<Transaction>(x => x.PayeeId == payeeId).ToList();
            return transactions.Select(entity => MapToListModel(entity));
        }

        public IEnumerable<TransactionModel> FindByAccount(int accountId)
        {
            var transactions = _repository.FindBy<Transaction>(x => x.AccountId == accountId).ToList();
            return transactions.Select(entity => MapToListModel(entity));
        }

        public IEnumerable<TransactionModel> FindByCategory(int categoryId)
        {
            var transactions = _repository.FindBy<Transaction>(x => x.CategoryId == categoryId).ToList();
            return transactions.Select(entity => MapToListModel(entity));
        }
    }
}
