using MyTrx.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyTrx.Data.Entities
{
    public class Account : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public AccountType AccountType { get; set; }
        public string Note { get; set; }
        public bool IsOpen { get; set; }
        //public virtual IEnumerable<Transaction> Transactions { get; set; }
        public DateTime CreatedDate { get; set; }


        public Account()
        {
            //Transactions = new List<Transaction>();
        }
    }
}
