using MYOB.AccountRight.SDK.Contracts.Version2.PayrollCategory;

namespace MYOB.AccountRight.SDK.Contracts.Version2.Contact
{
    /// <summary>
    /// EmployeeTaxInfo
    /// </summary>
    public class EmployeeTaxInfo
    {
        /// <summary>
        /// Tax File Number
        /// </summary>
        public string TaxFileNumber { get; set; }

        /// <summary>
        /// Tax Table
        /// </summary>
        public TaxTableLink TaxTable { get; set; }

        /// <summary>
        /// Withholding Variation Rate
        /// </summary>
        public decimal WithholdingVariationRate { get; set; }

        /// <summary>
        /// Total Rebates Per Year
        /// </summary>
        public decimal TotalRebatesPerYear { get; set; }

        /// <summary>
        /// Extra Tax Per Pay
        /// </summary>
        public decimal ExtraTaxPerPay { get; set; }

        /// <summary>
        /// Tax Category
        /// </summary>
        public PayrollCategoryLink TaxCategory { get; set; }
    }
}