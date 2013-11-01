namespace MYOB.AccountRight.SDK.Contracts.Version2.GeneralLedger
{
    /// <summary>
    /// Banking Details
    /// </summary>
    public class BankingDetails
    {
        /// <summary>
        /// BSB as provided by the financial institution.
        /// </summary>
        public string BSBNumber { get; set; }

        /// <summary>
        /// Account number as provided by the financial institution.
        /// </summary>
        /// <remarks>
        /// For Australia: formatted as BankAccountNumber e.g. <br/>
        /// For New Zealand: formatted as BankCode-BankAccountNumber-Suffix e.g.
        /// </remarks>
        public string BankAccountNumber { get; set; }

        /// <summary>
        /// Bank account name.
        /// </summary>
        public string BankAccountName { get; set; }

        /// <summary>
        /// Company trading name if applicable for bank account
        /// </summary>
        public string CompanyTradingName { get; set; }

        /// <summary>
        /// Bank code as provided by the financial institution.
        /// </summary>
        public string BankCode { get; set; }

        /// <summary>
        /// True indicates the bank account will be used to create bank files (ABA). <br/>
        /// False indicates the bank account will not be used to create bank files.
        /// </summary>
        public bool CreateBankFiles { get; set; }

        /// <summary>
        /// Direct entry user id as provided by the financial institution.
        /// </summary>
        public string DirectEntryUserId { get; set; }

        /// <summary>
        /// True indicates the bank account requires a self balancing transaction. <br/>
        /// False indicates the bank account does not require a self balancing transaction.
        /// </summary>
        public bool IncludeSelfBalancingTransaction { get; set; }
        
        /// <summary>
        /// Statement Code (New Zealand only)
        /// </summary>
        public string StatementCode { get; set; }

        /// <summary>
        /// Statement Reference (New Zealand only)
        /// </summary>
        public string StatementReference { get; set; }

        /// <summary>
        /// Statement Particulars (Statement Text - Australia, Particulars - New Zealand)
        /// </summary>
        public string StatementParticulars { get; set; }
    }
}