
namespace MYOB.AccountRight.SDK.Contracts.Version2.Contact
{
    /// <summary>
    /// Describes the Employee Payment Details
    /// </summary>
    public class EmployeePaymentDetails : BaseEntity
    {
        /// <summary>
        /// Employee
        /// </summary>
        public EmployeeLink Employee { get; set; }

        /// <summary>
        /// Payment Method
        /// </summary>
        public PaymentMethod PaymentMethod { get; set; }

        /// <summary>
        /// Bank Statement Text
        /// </summary>
        public string BankStatementText { get; set; }

        /// <summary>
        /// Bank Accounts
        /// </summary>
        public BankAccount[] BankAccounts { get; set; }

    }

    /// <summary>
    /// Bank Account
    /// </summary>
    public class BankAccount
    {
        /// <summary>
        /// Account BSB number
        /// </summary>
        public string BSBNumber { get; set; }

        /// <summary>
        /// Account number
        /// </summary>
        public string BankAccountNumber { get; set; }

        /// <summary>
        /// Account name
        /// </summary>
        public string BankAccountName { get; set; }

        /// <summary>
        /// Allocation amount, percent or dollar amount
        /// </summary>
        public decimal? Value { get; set; }

        /// <summary>
        /// Allocation type
        /// </summary>
        public AllocationType Unit { get; set; }
    }

    /// <summary>
    /// Payment Method
    /// </summary>
    public enum PaymentMethod
    {
        /// <summary>
        /// Cash
        /// </summary>
        Cash,

        /// <summary>
        /// Cheque
        /// </summary>
        Cheque,

        /// <summary>
        /// Electronic
        /// </summary>
        Electronic
    }

    /// <summary>
    /// Payment Allocation Type
    /// </summary>
    public enum AllocationType
    {
        /// <summary>
        /// Percentage
        /// </summary>
        Percent,
        
        /// <summary>
        /// Dollars
        /// </summary>
        Dollars,

        /// <summary>
        /// Remaining Amount
        /// </summary>
        RemainingAmount
    }

}
