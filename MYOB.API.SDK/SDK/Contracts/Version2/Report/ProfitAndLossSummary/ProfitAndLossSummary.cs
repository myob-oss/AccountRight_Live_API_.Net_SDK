using System;
using System.Collections.Generic;
using MYOB.AccountRight.SDK.Contracts.Version2.GeneralLedger;
using MYOB.AccountRight.SDK.Contracts.Version2.Report.TaxCodeSummary;

namespace MYOB.AccountRight.SDK.Contracts.Version2.Report.ProfitAndLossSummary
{
    /// <summary>
    ///  Profit and Loss Summary
    /// </summary>
    public class ProfitAndLossSummary
    {
        /// <summary>
        /// Start Date of the reporting period
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// End Date of the reporting period
        /// </summary>
        public DateTime EndDate { get; set; }

        /// <summary>
        /// ReportingBasis should be Accrual or Cash
        /// </summary>
        public ReportingBasis ReportingBasis { get; set; }

        /// <summary>
        /// Year end adjustment
        /// </summary>
        public Boolean YearEndAdjust { get; set; }

        /// <summary>
        /// Accounts Breakdown
        /// </summary>
        public List<AccountsBreakdown> AccountsBreakdown { get; set; }


    }

    /// <summary>
    /// Breakdown of accounts
    /// </summary>
    public class AccountsBreakdown
    {
        /// <summary>
        /// Balance
        /// </summary>
        public Decimal AccountTotal { get; set; }

        /// <summary>
        /// Account information
        /// </summary>
        public AccountLink Account { get; set; }
    }
}
