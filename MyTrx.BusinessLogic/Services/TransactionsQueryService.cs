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
            //var transactions = _repository.GetDbSet<Transaction>(options);
            var transactions = _repository.GetAll<Transaction>(options).ToList();
            return transactions.Select(entity => MapToListModel(entity));
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
            return new TransactionModel
            {
                Id = transaction.Id,
                Date = transaction.Date,
                Type = transaction.Type,
                AccountId = transaction.AccountId,
                AccountName = transaction.Account?.Name,
                PayeeId = transaction.PayeeId,
                PayeeName = transaction.Payee?.Name,
                CategoryId = transaction.CategoryId,
                CategoryName = transaction.Category?.Name,
                Amount = transaction.Amount,
                Cleared = transaction.Cleared,
                Flag = transaction.Flag,
                Reconciled = transaction.Reconciled,
                TargetAccountId = transaction.TargetAccountId,
                TargetAccountName = transaction.TargetAccount?.Name,
                Note = transaction.Note,
                Reference = transaction.Reference

            };
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
