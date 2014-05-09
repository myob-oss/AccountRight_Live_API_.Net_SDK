using System;
using System.Linq;
using System.Text;

namespace MYOB.AccountRight.SDK.Contracts.Version2.PayrollCategory
{
    /// <summary>
    /// Describes the base PayrollCategory
    /// </summary>
    public class PayrollCategory : BaseEntity
    {
        /// <summary>
        /// The name of the <see cref="PayrollCategory"/>
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The type of <see cref="PayrollCategory"/>
        /// </summary>
        public PayrollCategoryType Type { get; set; }
    }

    /// <summary>
    /// The calculation basis details for <see cref="PayrollCategoryEntitlement"/>
    /// </summary>
    public class PayrollCategoryEntitlementCalculationBasis
    {
        /// <summary>
        /// The type of calculation basis
        /// </summary>
        public PayrollCategoryEntitlementCalculationBasisType Type { get; set; }

        /// <summary>
        /// The percentage of the PayrollCategory, used when <see cref="Type"/> is <see cref="PayrollCategoryEntitlementCalculationBasisType.PercentageOfPayrollCategory"/>
        /// </summary>
        public decimal? PercentageOf { get; set; }

        /// <summary>
        /// The <see cref="PayrollCategory"/> to take a percentage of, used when <see cref="Type"/> is <see cref="PayrollCategoryEntitlementCalculationBasisType.PercentageOfPayrollCategory"/>
        /// </summary>
        public PayrollCategoryLink PayrollCategory { get; set; }

        /// <summary>
        /// The number of fixed hours to accrue per <see cref="AccrualPeriod"/>, used when <see cref="Type"/> is <see cref="PayrollCategoryEntitlementCalculationBasisType.FixedHours"/>
        /// </summary>
        public decimal? FixedHoursOf { get; set; }

        /// <summary>
        /// The Accrual Period that the <see cref="FixedHoursOf"/> is based, used when <see cref="Type"/> is <see cref="PayrollCategoryEntitlementCalculationBasisType.FixedHours"/>
        /// </summary>
        public PayrollCategoryEntitlementAccrualPeriod? AccrualPeriod { get; set; }
    }

    /// <summary>
    /// The calculation basis type for <see cref="PayrollCategoryEntitlement"/>
    /// </summary>
    public enum PayrollCategoryEntitlementCalculationBasisType
    {
        /// <summary>
        /// Use user entered value
        /// </summary>
        UserEntered,

        /// <summary>
        /// Calculate entitlements based on a percentage of another <see cref="PayrollCategory"/>
        /// </summary>
        PercentageOfPayrollCategory,

        /// <summary>
        /// Calculate entitlements based on a number of hours per period
        /// </summary>
        FixedHours
    }

    /// <summary>
    /// The accrual period for <see cref="PayrollCategoryEntitlement"/>
    /// </summary>
    public enum PayrollCategoryEntitlementAccrualPeriod
    {
        /// <summary>
        /// Base on the current pay period
        /// </summary>
        PayPeriod,

        /// <summary>
        /// Base on a month
        /// </summary>
        Month,

        /// <summary>
        /// Base on the year
        /// </summary>
        Year
    }

    /// <summary>
    /// describes the type of PayrollCategory
    /// </summary>
    public enum PayrollCategoryType
    {
        /// <summary>
        /// Wage
        /// </summary>
        Wage,

        /// <summary>
        /// Deduction
        /// </summary>
        Deduction,

        /// <summary>
        /// Entitlement
        /// </summary>
        Entitlement,

        /// <summary>
        /// Expense
        /// </summary>
        Expense,

        /// <summary>
        /// WagesGroup
        /// </summary>
        WagesGroup,

        /// <summary>
        /// Tax
        /// </summary>
        Tax,

        /// <summary>
        /// Superannuation
        /// </summary>
        Superannuation,

        /// <summary>
        /// HourlyGroup
        /// </summary>
        HourlyGroup
    }
}
