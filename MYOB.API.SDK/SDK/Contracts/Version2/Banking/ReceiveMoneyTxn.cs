using System;
using System.Collections.Generic;
using MYOB.AccountRight.SDK.Contracts.Version2.Contact;
using MYOB.AccountRight.SDK.Contracts.Version2.GeneralLedger;
using MYOB.AccountRight.SDK.Contracts.Version2.Sale;

namespace MYOB.AccountRight.SDK.Contracts.Version2.Banking
{
    /// <summary>
    /// A receive money transaction entity
    /// </summary>
    public class ReceiveMoneyTxn : SupportMulticurrencyEntity
    {
        /// <summary>
        /// Deposit To "Account" OR "Undeposited Funds"
        /// </summary>
        public DepositTo DepositTo { get; set; }

        /// <summary>
        /// The account to DepositTo A
        /// </summary>
        public AccountLink Account { get; set; }
        
        /// <summary>
        /// The Contact (Card) associated with the transaction
        /// </summary>
        public CardLink Contact { get; set; }
        
        /// <summary>
        /// Receipt Number with the transcation
        /// </summary>
        public string ReceiptNumber { get; set; }
        
        /// <summary>
        /// Transcation Receive Date
        /// </summary>
        public DateTime Date { get; set; }
        
        /// <summary>
        /// The Total Amount Received
        /// </summary>
        public decimal? AmountReceived { get; set; }
        
        /// <summary>
        /// <para>True indicates the transaction is set to tax inclusive.</para>
        /// <para>False indicates the transaction is not tax inclusive.</para>
        /// </summary>
        public bool IsTaxInclusive { get; set; }
       
        /// <summary>
        /// Memo text describing the transaction.
        /// </summary>
        public decimal TotalTax { get; set; }
        
        /// <summary>
        /// The transaction payment method 
        /// </summary>
        public string PaymentMethod { get; set; }

        /// <summary>
        /// Memo text describing the transaction.
        /// </summary>
        public string Memo { get; set; }
        
        /// <summary>
        /// The Category associated with the transaction
        /// </summary>
        public CategoryLink Category { get; set; }

        /// <summary>
        /// Transaction Lines
        /// </summary>
        public IEnumerable<ReceiveMoneyTxnLine> Lines { get; set; }
    }
}