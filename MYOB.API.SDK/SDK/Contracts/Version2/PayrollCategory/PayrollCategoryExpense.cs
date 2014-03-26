using System.Collections.Generic;
using MYOB.AccountRight.SDK.Contracts.Version2.GeneralLedger;

namespace MYOB.AccountRight.SDK.Contracts.Version2.PayrollCategory
{
    /// <summary>
    /// Describes the expense PayrollCategory
    /// </summary>
    public class PayrollCategoryExpense : PayrollCategory
    {
        /// <summary>
        /// The account that is affected
        /// </summary>
        public AccountLink ExpenseAccount { get; set; }

        /// <summary>
        /// The account that is affected
        /// </summary>
        public AccountLink PayableAccount { get; set; }

        /// <summary>
        /// Print details on the pay advice
        /// </summary>
        public bool PrintOnPayAdvice { get; set; }

        /// <summary>
        /// Details about the calculation
        /// </summary>
        public PayrollCategoryExpenseCalculationBasis CalculationBasis { get; set; }

        /// <summary>
        /// Details about the limit
        /// </summary>
        public PayrollCategoryExpenseLimit Limit { get; set; }

        /// <summary>
        /// The threshold above which the PayrollCategory takes affect
        /// </summary>
        public decimal Threshold { get; set; }

        /// <summary>
        /// The <see cref="PayrollCategory"/> that are excluded during calculations
        /// </summary>
        public IEnumerable<PayrollCategoryLink> Exemptions { get; set; }
    }

    /// <summary>
    /// Describes how the <see cref="PayrollCategoryExpense"/> is calculated
    /// </summary>
    public class PayrollCategoryExpenseCalculationBasis
    {
        /// <summary>
        /// The type of calculation
        /// </summary>
        public PayrollCategoryExpenseCalculationBasisType Type { get; set; }

        /// <summary>
        /// The calculation is the percentage of the <see cref="MYOB.AccountRight.SDK.Contracts.Version2.PayrollCategory.PayrollCategoryExpenseCalculationBasis.PayrollCategory"/>
        /// </summary>
        public decimal? PercentageOf { get; set; }

        /// <summary>
        /// The <see cref="PayrollCategory"/> whose percentge of makes up the calculation
        /// </summary>
        public PayrollCategoryLink PayrollCategory { get; set; }

        /// <summary>
        /// The calculation is based on a fixed amount of dollars per <see cref="MYOB.AccountRight.SDK.Contracts.Version2.PayrollCategory.PayrollCategoryExpenseCalculationBasis.AccrualPeriod"/>
        /// </summary>
        public decimal? FixedDollarsOf { get; set; }

        /// <summary>
        /// The period over which the total dollars amount is calculated
        /// </summary>
        public PayrollCategoryExpenseAccrualPeriod? AccrualPeriod { get; set; }
    }

    /// <summary>
    /// Describes how the <see cref="PayrollCategoryExpense"/> is limited
    /// </summary>
    public class PayrollCategoryExpenseLimit
    {
        /// <summary>
        /// The type of limit
        /// </summary>
        public PayrollCategoryExpenseLimitType Type { get; set; }

        /// <summary>
        /// The calculation is the percentage of the <see cref="MYOB.AccountRight.SDK.Contracts.Version2.PayrollCategory.PayrollCategoryExpenseCalculationBasis.PayrollCategory"/>
        /// </summary>
        public decimal? PercentageOf { get; set; }

        /// <summary>
        /// The <see cref="PayrollCategory"/> whose percentge of makes up the calculation
        /// </summary>
        public PayrollCategoryLink PayrollCategory { get; set; }

        /// <summary>
        /// The calculation is based on a fixed amount of dollars per <see cref="MYOB.AccountRight.SDK.Contracts.Version2.PayrollCategory.PayrollCategoryExpenseCalculationBasis.AccrualPeriod"/>
        /// </summary>
        public decimal? FixedDollarsOf { get; set; }

        /// <summary>
        /// The period over which the total dollars amount is calculated
        /// </summary>
        public PayrollCategoryLimitAccrualPeriod? AccrualPeriod { get; set; }
    }

    /// <summary>
    /// The type of calculation
    /// </summary>
    public enum PayrollCategoryExpenseCalculationBasisType
    {
        /// <summary>
        /// The calculation is a percentage of a supplied <see cref="PayrollCategory"/>
        /// </summary>
        PercentageOfPayrollCategory,

        /// <summary>
        /// The value is a fixed value per period
        /// </summary>
        FixedDollars
    }

    /// <summary>
    /// The type of accrual periods for <see cref="PayrollCategoryExpense"/> calculation
    /// </summary>
    public enum PayrollCategoryExpenseAccrualPeriod
    {
        /// <summary>
        /// The pay period
        /// </summary>
        PayPeriod,

        /// <summary>
        /// Month
        /// </summary>
        Month,

        /// <summary>
        /// Year
        /// </summary>
        Year,
    }

    /// <summary>
    /// The type of limit
    /// </summary>
    public enum PayrollCategoryExpenseLimitType
    {
        /// <summary>
        /// No-limit
        /// </summary>
        NoLimit,

        /// <summary>
        /// The calculation is a percentage of a supplied <see cref="PayrollCategory"/>
        /// </summary>
        PercentageOfPayrollCategory,

        /// <summary>
        /// The value is a fixed value per period
        /// </summary>
        FixedDollars
    }

}