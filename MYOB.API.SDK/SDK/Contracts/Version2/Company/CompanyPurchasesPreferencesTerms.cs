using MYOB.AccountRight.SDK.Contracts.Version2.GeneralLedger;

namespace MYOB.AccountRight.SDK.Contracts.Version2.Company
{
    /// <summary>
    /// Purchases' terms preferences
    /// </summary>
    public class CompanyPurchasesPreferencesTerms : Terms
    {
        /// <summary>
        /// Tax code of purchases
        /// </summary>
        public TaxCodeLink TaxCode { get; set; }

        /// <summary>
        /// Use supplier's tax code instead of default tax code
        /// </summary>
        public bool UseSupplierTaxCode { get; set; }

        /// <summary>
        /// Tax code of purchase freight
        /// </summary>
        public TaxCodeLink FreightTaxCode { get; set; }

        /// <summary>
        /// Credit limit of a purchase
        /// </summary>
        public decimal CreditLimit { get; set; }
    }
}
