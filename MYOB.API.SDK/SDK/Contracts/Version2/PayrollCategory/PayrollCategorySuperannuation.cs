using System.Collections.Generic;
using MYOB.AccountRight.SDK.Contracts.Version2.GeneralLedger;

namespace MYOB.AccountRight.SDK.Contracts.Version2.PayrollCategory
{
    /// <summary>
    /// Describes the Superannuation PayrollCategory
    /// </summary>
    public class PayrollCategorySuperannuation : PayrollCategory
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
        /// The type of superannuation contribution
        /// </summary>
        public PayrollCategorySuperannuationContributionType ContributionType { get; set; }

        /// <summary>
        /// Print details on the pay advice
        /// </summary>
        public bool PrintOnPayAdvice { get; set; }

        /// <summary>
        /// Details about the calculation
        /// </summary>
        public PayrollCategorySuperannuationCalculationBasis CalculationBasis { get; set; }

        /// <summary>
        /// The first amount of the wage to be excluded
        /// </summary>
        public decimal Exclusion { get; set; }

        /// <summary>
        /// Details about the limit
        /// </summary>
        public PayrollCategorySuperannuationLimit Limit { get; set; }

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
    /// Describes how the <see cref="PayrollCategorySuperannuation"/> is calculated
    /// </summary>
    public class PayrollCategorySuperannuationCalculationBasis
    {
        /// <summary>
        /// The type of calculation
        /// </summary>
        public PayrollCategorySuperannuationCalculationBasisType Type { get; set; }

        /// <summary>
        /// The calculation is the percentage of the <see cref="MYOB.AccountRight.SDK.Contracts.Version2.PayrollCategory.PayrollCategorySuperannuationCalculationBasis.PayrollCategory"/>
        /// </summary>
        public decimal? PercentageOf { get; set; }

        /// <summary>
        /// The <see cref="PayrollCategory"/> whose percentge of makes up the calculation
        /// </summary>
        public PayrollCategoryLink PayrollCategory { get; set; }

        /// <summary>
        /// The calculation is based on a fixed amount of dollars per <see cref="MYOB.AccountRight.SDK.Contracts.Version2.PayrollCategory.PayrollCategorySuperannuationCalculationBasis.AccrualPeriod"/>
        /// </summary>
        public decimal? FixedDollarsOf { get; set; }

        /// <summary>
        /// The period over which the total dollars amount is calculated
        /// </summary>
        public PayrollCategorySuperannuationAccrualPeriod? AccrualPeriod { get; set; }
    }

    /// <summary>
    /// Describes how the <see cref="PayrollCategorySuperannuation"/> is limited
    /// </summary>
    public class PayrollCategorySuperannuationLimit
    {
        /// <summary>
        /// The type of limit
        /// </summary>
        public PayrollCategorySuperannuationLimitType Type { get; set; }

        /// <summary>
        /// The calculation is the percentage of the <see cref="MYOB.AccountRight.SDK.Contracts.Version2.PayrollCategory.PayrollCategorySuperannuationCalculationBasis.PayrollCategory"/>
        /// </summary>
        public decimal? PercentageOf { get; set; }

        /// <summary>
        /// The <see cref="PayrollCategory"/> whose percentge of makes up the calculation
        /// </summary>
        public PayrollCategoryLink PayrollCategory { get; set; }

        /// <summary>
        /// The calculation is based on a fixed amount of dollars per <see cref="MYOB.AccountRight.SDK.Contracts.Version2.PayrollCategory.PayrollCategorySuperannuationCalculationBasis.AccrualPeriod"/>
        /// </summary>
        public decimal? FixedDollarsOf { get; set; }

        /// <summary>
        /// The period over which the total dollars amount is calculated
        /// </summary>
        public PayrollCategorySuperannuationLimitAccrualPeriod? AccrualPeriod { get; set; }
    }

    /// <summary>
    /// The superannuation contribution type
    /// </summary>
    public enum PayrollCategorySuperannuationContributionType
    {
        /// <summary>
        /// SuperannuationGuarantee
        /// </summary>
        SuperannuationGuarantee,

        /// <summary>
        /// EmployerAdditional
        /// </summary>
        EmployerAdditional,

        /// <summary>
        /// Productivity
        /// </summary>
        Productivity,

        /// <summary>
        /// Redundancy
        /// </summary>
        Redundancy,

        /// <summary>
        /// EmployeeAdditional
        /// </summary>
        EmployeeAdditional,

        /// <summary>
        /// Spouse
        /// </summary>
        Spouse,

        /// <summary>
        /// SalarySacrifice
        /// </summary>
        SalarySacrifice,

    }

    /// <summary>
    /// The superannuation calulation basis type
    /// </summary>
    public enum PayrollCategorySuperannuationCalculationBasisType
    {
        /// <summary>
        /// User entered
        /// </summary>
        UserEntered,

        /// <summary>
        /// A percenatge of the payroll category
        /// </summary>
        PercentageOfPayrollCategory,

        /// <summary>
        /// A fixed dollar amount per accrual period
        /// </summary>
        FixedDollars
    }

    /// <summary>
    /// The superannuation limit type
    /// </summary>
    public enum PayrollCategorySuperannuationLimitType
    {
        /// <summary>
        /// No limit
        /// </summary>
        NoLimit,

        /// <summary>
        /// A percenatge of the payroll category
        /// </summary>
        PercentageOfPayrollCategory,

        /// <summary>
        /// A fixed dollar amount per accrual period
        /// </summary>
        FixedDollars
    }

    /// <summary>
    /// The superannuation accrual period
    /// </summary>
    public enum PayrollCategorySuperannuationAccrualPeriod
    {
        /// <summary>
        /// Pay period
        /// </summary>
        PayPeriod,

        /// <summary>
        /// Month
        /// </summary>
        Month,

        /// <summary>
        /// Quarter
        /// </summary>
        Quarter,

        /// <summary>
        /// Year
        /// </summary>
        Year,

        /// <summary>
        /// Hour
        /// </summary>
        Hour,
    }

    /// <summary>
    /// The superannuation limit accrual period
    /// </summary>
    public enum PayrollCategorySuperannuationLimitAccrualPeriod
    {
        /// <summary>
        /// Pay period
        /// </summary>
        PayPeriod,

        /// <summary>
        /// Month
        /// </summary>
        Month,

        /// <summary>
        /// Quarter
        /// </summary>
        Quarter,

        /// <summary>
        /// Year
        /// </summary>
        Year,

        /// <summary>
        /// Hour
        /// </summary>
        Hour,
    }
}