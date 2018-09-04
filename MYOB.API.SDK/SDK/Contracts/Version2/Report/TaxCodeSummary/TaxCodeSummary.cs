using System;
using System.Collections.Generic;
using MYOB.AccountRight.SDK.Contracts.Version2.GeneralLedger;

namespace MYOB.AccountRight.SDK.Contracts.Version2.Report.TaxCodeSummary
{
    /// <summary>
    ///  Tax Code breakdown with Amount and Rate
    /// </summary>
    public class TaxCodeSummary
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
        /// Tax Code Breakdown of sales and purchases per tax code in a given time period and reporting basis 
        /// </summary>
        public List<TaxCodeBreakdown> TaxCodeBreakdown { get; set; }
    }

    /// <summary>
    /// Breakdown of sales and purchases per taxcode
    /// </summary>
    public class TaxCodeBreakdown
    {
        /// <summary>
        /// Total Sales in $
        /// </summary>
        public decimal SalesTotal { get; set; }

        /// <summary>
        /// Total purchases in $
        /// </summary>
        public decimal PurchasesTotal { get; set; }

        /// <summary>
        /// Total tax collected
        /// </summary>
        public decimal TaxCollected { get; set; }

        /// <summary>
        /// Total tax paid
        /// </summary>
        public decimal TaxPaid { get; set; }

        /// <summary>
        /// Tax rate in %
        /// </summary>
        public decimal TaxRate { get; set; }

        /// <summary>
        /// Link to the actual tax code
        /// </summary>
        public TaxCodeLink TaxCode { get; set; }
    }

    /// <summary>
    /// Reporting basis 
    /// </summary>
    public enum ReportingBasis
    {
        /// <summary>
        /// Accrual
        /// </summary>
        Accrual,

        /// <summary>
        /// Cash
        /// </summary>
        Cash
    }
}
