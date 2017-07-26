using MyTrx.BusinessLogic.Models;
using MyTrx.Data.Entities;
using System.Collections.Generic;

namespace MyTrx.BusinessLogic.Services
{
    public interface ITransactionsQueryService
    {
        TransactionModel GetById(int id);

        IEnumerable<TransactionModel> GetAll(object options);

        TransactionModel MapToModel(Transaction transaction);

        IEnumerable<TransactionModel> FindByPayee(int payeeId);

        IEnumerable<TransactionModel> FindByAccount(int accountId);

        IEnumerable<TransactionModel> FindByCategory(int categoryId);
    }
}