using MyTrx.Data.Entities;
using MyTrx.Data.Enums;
using System;

namespace MyTrx.BusinessLogic.Models
{
    public class TransactionModel : IModelOf<Transaction>
    {
        public int Id { get; set; }
        public TransactionType Type { get; set; }
        public string TypeDescription { get { return Type.ToString(); } }
        public int PayeeId { get; set; }
        public string PayeeName { get; set; }
        public decimal Amount { get; set; }
        public decimal Outflow { get { return Amount < 0 ? Amount : 0; } }
        public decimal Inflow { get { return Amount > 0 ? Amount : 0; } }
        public decimal RunningBalance { get; set; }
        public int AccountId { get; set; }
        public string AccountName { get; set; }
        public DateTime Date { get; set; }
        public string DateFormatted { get { return Date.ToString("d"); } }
        public int TargetAccountId { get; set; }
        public string TargetAccountName { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Reference { get; set; }
        public bool Cleared { get; set; }
        public bool Reconciled { get; set; }
        public Flag Flag { get; set; }
        public string FlagDescription { get { return Flag.ToString(); } }
        public string Note { get; set; }
    }
}
