namespace MYOB.AccountRight.SDK.Contracts.Version2.GeneralLedger
{
    /// <summary>
    /// Describes an Account resource
    /// </summary>
    public class Account : SupportMulticurrencyEntity
    {
        /// <summary>
        /// Initialises an account resource
        /// </summary>
        public Account()
        {
            IsActive = true;
            Number = -1;
        }

        /// <summary>
        /// Account code format includes separator ie 1-1100
        /// </summary>
        public string DisplayID { get; set; }

        /// <summary>
        /// Name of the account.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The account classification. (Read only)
        /// </summary>
        /// <remarks>
        /// You change this field by modifying the Type property
        /// </remarks>
        public Classification Classification { get; set; }

        /// <summary>
        /// Account number for example 1150. Must be a unique four-digit number that does not include the account type classification number and account separator. 
        /// </summary>       
        public int Number { get; set; }

        /// <summary>
        /// Description of the Account
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Identifies the parent account. (Read only)
        /// </summary>
        public AccountLink ParentAccount { get; set; }

        /// <summary>
        /// The account active status. <br/>
        /// True indicates the account is active. <br/>
        /// False indicates the account is inactive.
        /// </summary>
        /// <remarks>
        /// A user marks an account as inactive when they no longer need to record transactions to it. An inactive account doesn't appear in selection lists, but it can still be assigned to a transaction, and be included in reports.
        /// </remarks>
        public bool IsActive { get; set; }

        /// <summary>
        /// Tax Code associated with the account
        /// </summary>
        public TaxCodeLink TaxCode { get; set; }

        /// <summary>
        /// The hierarchial level of the account in the Accounts List.
        /// </summary>
        /// <remarks>
        /// Possible values are 1, 2, 3, 4. The highest level accounts are level 1, the lowest 4. You can only assign levels 2 to 4 to a new account.
        /// </remarks>
        public short Level { get; set; }

        /// <summary>
        /// Depending on the classification of the account (e.g. asset), you can define the account's type.
        /// </summary>
        public AccountType Type { get; set; }

        /// <summary>
        /// Balance of the account as at the conversion date set for the company file.
        /// </summary>
        public decimal OpeningBalance { get; set; }

        /// <summary>
        /// Current balance of the account. Note that this balance will include all future-dated activity.
        /// </summary>
        public decimal CurrentBalance { get; set; }

        /// <summary>
        /// The bank details associated with the account.
        /// </summary>
        public BankingDetails BankingDetails { get; set; }

        /// <summary>
        /// Header account status. Header accounts are used to organise, group and subtotal accounts in the Accounts List and reports.
        /// </summary>
        /// <remarks>
        /// True indicates the account is a header account. Header accounts are used to organise, group and subtotal accounts in the Accounts List and reports. <br/>
        /// False indicates the account is a detail account. Only detail accounts can be assigned to transactions.
        /// </remarks>
        public bool IsHeader { get; set; }
    }
}
