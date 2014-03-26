using System.Collections.Generic;
using MYOB.AccountRight.SDK.Contracts.Version2.GeneralLedger;

namespace MYOB.AccountRight.SDK.Contracts.Version2.PayrollCategory
{
    /// <summary>
    /// Describes the deduction PayrollCategory
    /// </summary>
    public class PayrollCategoryDeduction : PayrollCategory
    {
        /// <summary>
        /// The account that is affected
        /// </summary>
        public AccountLink PayableAccount { get; set; }

        /// <summary>
        /// Details about the calculation
        /// </summary>
        public PayrollCategoryDeductionCalculationBasis CalculationBasis { get; set; }

        /// <summary>
        /// Details about the limit
        /// </summary>
        public PayrollCategoryDeductionLimit Limit { get; set; }

        /// <summary>
        /// The <see cref="PayrollCategory"/> that are excluded during calculations
        /// </summary>
        public IEnumerable<PayrollCategoryLink> Exemptions { get; set; }
    }

    /// <summary>
    /// Describes how the <see cref="PayrollCategoryDeduction"/> is calculated
    /// </summary>
    public class PayrollCategoryDeductionCalculationBasis
    {
        /// <summary>
        /// The type of calculation
        /// </summary>
        public PayrollCategoryDeductionCalculationBasisType Type { get; set; }

        /// <summary>
        /// The calculation is the percentage of the <see cref="PayrollCategoryDeductionCalculationBasis.PayrollCategory"/>
        /// </summary>
        public decimal? PercentageOf { get; set; }

        /// <summary>
        /// The <see cref="PayrollCategory"/> whose percentge of makes up the calculation
        /// </summary>
        public PayrollCategoryLink PayrollCategory { get; set; }

        /// <summary>
        /// The calculation is based on a fixed amount of dollars per <see cref="PayrollCategoryDeductionCalculationBasis.AccrualPeriod"/>
        /// </summary>
        public decimal? FixedDollarsOf { get; set; }

        /// <summary>
        /// The period over which the total dollars amount is calculated
        /// </summary>
        public PayrollCategoryDeductionAccrualPeriod? AccrualPeriod { get; set; }
    }

    /// <summary>
    /// Describes how the <see cref="PayrollCategoryDeduction"/> is limited
    /// </summary>
    public class PayrollCategoryDeductionLimit
    {
        /// <summary>
        /// The type of limit
        /// </summary>
        public PayrollCategoryDeductionLimitType Type { get; set; }

        /// <summary>
        /// The calculation is the percentage of the <see cref="PayrollCategoryDeductionCalculationBasis.PayrollCategory"/>
        /// </summary>
        public decimal? PercentageOf { get; set; }

        /// <summary>
        /// The <see cref="PayrollCategory"/> whose percentge of makes up the calculation
        /// </summary>
        public PayrollCategoryLink PayrollCategory { get; set; }

        /// <summary>
        /// The calculation is based on a fixed amount of dollars per <see cref="PayrollCategoryDeductionCalculationBasis.AccrualPeriod"/>
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
    public enum PayrollCategoryDeductionCalculationBasisType
    {
        /// <summary>
        /// Value is user-entered
        /// </summary>
        UserEntered,

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
    /// The type of accrual periods for <see cref="PayrollCategoryDeduction"/> calculation
    /// </summary>
    public enum PayrollCategoryDeductionAccrualPeriod
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

        /// <summary>
        /// Hour
        /// </summary>
        Hour
    }

    /// <summary>
    /// The type of limit
    /// </summary>
    public enum PayrollCategoryDeductionLimitType
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

    /// <summary>
    /// The type of accrual periods for <see cref="PayrollCategoryDeduction"/> limits
    /// </summary>
    public enum PayrollCategoryLimitAccrualPeriod
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

        /// <summary>
        /// Quarter
        /// </summary>
        Quarter,
    }

}