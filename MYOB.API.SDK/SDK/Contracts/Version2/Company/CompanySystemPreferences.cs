using System;

namespace MYOB.AccountRight.SDK.Contracts.Version2.Company
{
    /// <summary>
    /// Describes the company file system preferences
    /// </summary>
    public class CompanySystemPreferences
    {
        /// <summary>
        /// <para>Off - turn off the category tracking</para>
        /// <para>OnAndNotRequired - turn on the category tracking categories are not required on All Transactions</para>
        /// <para>OnAndRequired - turn on the category tracking categories are required on All Transactions</para>
        /// </summary>
        public CategoryTracking CategoryTracking { get; set; }

        /// <summary>
        /// Transactions CAN'T be Changed; They Must be Reversed
        /// </summary>
        public bool TransactionsCannotBeChangedMustBeReversed { get; set; }

        /// <summary>
        /// Lock Period
        /// <para>Null - Unlock period for allow entries</para>
        /// <para>Not null - Period locked and disallow entries prior to [value]</para>
        /// </summary>
        public DateTime? LockPeriodPriorTo { get; set; }

        /// <summary>
        /// Use AlphaAccountIdentifier
        /// <para>true - Use Alphanumeric account identifier</para>
        /// <para>false - Use ARL account identifier format</para>
        /// </summary>
        public bool UseAlphaAccountIdentifier { get; set; }
    }
}
