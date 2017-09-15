using System;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MyTrx.Data.Enums;

namespace MyTrx.Data.Entities
{
    public class Transaction : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } 
        public TransactionType Type { get; set; }
        public int PayeeId { get; set; }
        public virtual Payee Payee { get; set; }
        public decimal Amount { get; set; }
        public int AccountId { get; set; }
        public virtual Account Account { get; set; }
        public DateTime Date { get; set; }
        public int TargetAccountId { get; set; }
        public virtual Account TargetAccount { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public string Reference { get; set; }
        public bool Cleared { get; set; }
        public bool Reconciled { get; set; }
        public Flag Flag { get; set; }
        public string Note { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        
    }
}
