using MyTrx.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyTrx.BusinessLogic.Models
{
    public class TransactionModel : IModelOf<Transaction>
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }

    }
}
