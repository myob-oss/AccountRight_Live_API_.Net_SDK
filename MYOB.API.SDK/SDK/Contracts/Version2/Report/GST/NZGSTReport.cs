using System;
using Newtonsoft.Json;

namespace MYOB.AccountRight.SDK.Contracts.Version2.Report.GST
{
    /// <summary>
    ///     Get data suitable for producing the NZ GST report
    /// </summary>
    public class NZGSTReport : IETagSupport
    {
        /// <summary>
        /// The location where this entity with input parameters can be retrieved. (Read only)
        /// </summary>
        public Uri URI { get; set; }

        /// <summary>
        /// Company Name
        /// </summary>
        public string CompanyName { get; set; }

        /// <summary>
        /// NZ IRD number
        /// </summary>
        public string IrdNumber { get; set; }

        /// <summary>
        /// Company Address
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Company Phone No.
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Report Accounting basis
        /// </summary>
        /// <remarks>
        /// Accrual, Cash or Hybrid
        /// </remarks>
        public string ReportingBasis { get; set; }

        /// <summary>
        /// First date covered in report results
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Last date covered in report results
        /// </summary>
        public DateTime EndDate { get; set; }

        /// <summary>
        /// Duration of reporting period
        /// </summary>
        /// <remarks>
        /// 1, 2 or 6 months
        /// </remarks>
        public string ReportingPeriod { get; set; }

        /// <summary>
        /// Total sales for reporting period
        /// </summary>
        /// <remarks>
        /// Box 5 of GST return form
        /// </remarks>
        public decimal TotalSales { get; set; }

        /// <summary>
        /// Zero-rated supplies included in TotalSales(box 5)
        /// </summary>       
        /// <remarks>
        /// Box 6 of GST return form
        /// </remarks>
        public decimal ZeroRatedSupplies { get; set; }

        /// <summary>
        /// Net GST Sales 
        /// - Calculated by subtracting ZeroRatedSupplies(Box 6) from TotalSales(Box 5)
        /// </summary>    
        /// <remarks>
        /// Box 7 of GST return form
        /// </remarks>
        public decimal NetGSTSales { get; set; }

        /// <summary>
        /// Total GST Collected On Sales 
        /// - Calculated by mutiplying NetGSTSales(Box 7) by 3 and dividing by 23
        /// </summary>    
        /// <remarks>
        /// Box 8 of GGST return form
        /// </remarks>
        public decimal TotalGSTCollectedOnSales { get; set; }

        /// <summary>
        /// Debit Adjustments 
        /// - Adjustments from calculation worksheet
        /// </summary>  
        /// <remarks>
        /// Box 9 of GST return form
        /// </remarks>
        public decimal DebitAdjustments { get; set; }

        /// <summary>
        /// Total GST collected on sales and income for reporting period
        /// </summary>  
        /// <remarks>
        /// Box 10 of GST return form
        /// </remarks>
        public decimal TotalGSTCollected { get; set; }

        /// <summary>
        /// Total purchases and expenses inc GST and excludes imported goods
        /// </summary>  
        /// <remarks>
        /// Box 11 of GST return form
        /// </remarks>
        public decimal TotalPurchases { get; set; }

        /// <summary>
        ///Total GST Collected On Purchases 
        /// - Calculated by multiplying TotalPurchases(Box 11) by 3 and dividing by 23
        /// </summary>  
        /// <remarks>
        /// Box 12 of GST return form
        /// </remarks>
        public decimal TotalGSTCollectedOnPurchases { get; set; }

        /// <summary>
        /// Credit Adjustments from calculation worksheet
        /// </summary>   
        /// <remarks>
        /// Box 13 of GST return form
        /// </remarks>
        public decimal CreditAdjustments { get; set; }

        /// <summary>
        /// Total GST Credit on purchases and expenses 
        /// - Calculated by adding TotalGSTCollectedOnPurchases(Box12) and CreditAdjustments(Box13)
        /// </summary>  
        /// <remarks>
        /// Box 14 of GST return form
        /// </remarks>
        public decimal TotalGSTCredit { get; set; }

        /// <summary>
        /// Payment Amount 
        /// - Difference between TotalGSTCollected(Box 10) and TotalGSTCredit(Box 14) 
        /// </summary>   
        /// <remarks>
        /// Box 15 of GST return form
        /// </remarks>
        public decimal PaymentAmount { get; set; }

        /// <summary>
        /// Returns the ETag from the HTTP Response Header
        /// </summary>
        [JsonIgnore]
        public string ETag { get; set; }
    }
}