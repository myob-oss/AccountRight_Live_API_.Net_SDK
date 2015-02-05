using System;
using MYOB.AccountRight.SDK.Contracts.Version2.GeneralLedger;

namespace MYOB.AccountRight.SDK.Contracts.Version2.Banking
{
    /// <summary>
    /// Get a bank account that is associated with a Bank Feed
    /// </summary>
    public class BankAccount : BaseEntity
    {
        /// <summary>
        /// The name of the financial institution
        /// </summary>
        public string FinancialInstitution { get; set; }

        /// <summary>
        /// The name of the bank account
        /// </summary>
        public string BankAccountName { get; set; }

        /// <summary>
        /// The sorting code
        /// </summary>
        /// <remarks>
        /// AU only
        /// </remarks>
        public string BSB { get; set; }

        /// <summary>
        /// The number of the bank account
        /// </summary>
        public string BankAccountNumber { get; set; }

        /// <summary>
        /// The name on the card
        /// </summary>
        public string CardName { get; set; }

        /// <summary>
        /// The number on the card (as stored in obfuscated form)
        /// </summary>
        public string CardNumber { get; set; }

        /// <summary>
        /// The <see cref="Account"/> that is linked to this BankAccount
        /// </summary>
        public AccountLink Account { get; set; }

        /// <summary>
        /// The status of the bank link
        /// </summary>
        public string BankLinkStatus { get; set; }

        /// <summary>
        /// The last time the account was reconciled
        /// </summary>
        public DateTime? LastReconciledDate { get; set; }
    }
}
