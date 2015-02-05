namespace MYOB.AccountRight.SDK.Contracts.Version2.GeneralLedger
{
    /// <summary>
    ///   JobBudget
    /// </summary>
    public class JobBudget : BaseEntity
    {
        /// <summary>
        /// The job to which the budgets apply
        /// </summary>
        public JobLink Job { get; set; }

        /// <summary>
        /// The allocated budgets
        /// </summary>
        public JobAccountBudget[] Budgets { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class JobAccountBudget
    {
        /// <summary>
        /// The account against which the budget is allocated
        /// </summary>
        public AccountLink Account { get; set; }

        /// <summary>
        /// The amount budgeted
        /// </summary>
        public decimal Amount { get; set; }
    }
    
}
