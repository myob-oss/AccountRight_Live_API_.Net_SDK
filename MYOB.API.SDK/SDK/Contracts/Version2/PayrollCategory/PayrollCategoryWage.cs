using System.Collections.Generic;
using MYOB.AccountRight.SDK.Contracts.Version2.GeneralLedger;

namespace MYOB.AccountRight.SDK.Contracts.Version2.PayrollCategory
{
    /// <summary>
    /// Describes the Wage PayrollCategory
    /// </summary>
    public class PayrollCategoryWage : PayrollCategory
    {
        /// <summary>
        /// The wage type
        /// </summary>
        public WageType WageType { get; set; }

        /// <summary>
        /// The overridden wages expense account
        /// </summary>
        public AccountLink OverriddenWagesExpenseAccount { get; set; }

        /// <summary>
        /// Extra details when dealing with a Hourly <see cref="WageType"/>
        /// </summary>
        public HourlyDetails HourlyDetails { get; set; }

        /// <summary>
        /// Exempt this <see cref="PayrollCategory"/> from deduction and tax calculations 
        /// </summary>
        public IEnumerable<PayrollCategoryLink> Exemptions { get; set; } 
    }

    /// <summary>
    /// The type of the <see cref="PayrollCategoryWage"/>
    /// </summary>
    public enum WageType
    {
        /// <summary>
        /// Hourly
        /// </summary>
        Hourly,

        /// <summary>
        /// Salary
        /// </summary>
        Salary
    }

    /// <summary>
    /// The extra details for Hourly <see cref="WageType"/>
    /// </summary>
    public class HourlyDetails
    {
        /// <summary>
        /// The type of adjustment
        /// </summary>
        public HourlyDetailsPayRate PayRate { get; set; }

        /// <summary>
        /// The multiplier when dealing with a change to regular rate
        /// </summary>
        public decimal? RegularRateMultiplier { get; set; }

        /// <summary>
        /// The alternative fixed-rate 
        /// </summary>
        public decimal? FixedHourlyRate { get; set; }

        /// <summary>
        /// True, if this category used for paid leave entitlements
        /// </summary>
        public bool AutomaticallyAdjustBaseAmounts { get; set; }
    }

    /// <summary>
    /// The pay rate adjustment method
    /// </summary>
    public enum HourlyDetailsPayRate
    {
        /// <summary>
        /// The adjustment is to be made to the regular rate
        /// </summary>
        RegularRate,

        /// <summary>
        /// The adjustment is a fixed-hourly rate
        /// </summary>
        FixedHourly
    }
}