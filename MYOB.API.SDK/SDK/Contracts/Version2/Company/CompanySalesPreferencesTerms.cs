using MYOB.AccountRight.SDK.Contracts.Version2.GeneralLedger;

namespace MYOB.AccountRight.SDK.Contracts.Version2.Company
{
    /// <summary>
    /// Sales' terms preferences
    /// </summary>
    public class CompanySalesPreferencesTerms : Terms
    {
        /// <summary>
        /// % Monthly charge for late payment
        /// </summary>
        public double MonthlyChargeForLatePayment { get; set; }

        /// <summary>
        /// <para>BaseSellingPrice</para>
        /// <para>LevelA</para>
        /// <para>LevelB</para>
        /// <para>LevelC</para>
        /// <para>LevelD</para>
        /// <para>LevelE</para>
        /// <para>LevelF</para>
        /// </summary>
        public PriceLevel PriceLevel { get; set; }

        /// <summary>
        /// Tax code of sales
        /// </summary>
        public TaxCodeLink TaxCode { get; set; }

        /// <summary>
        /// Use customer's tax code instead of default tax code
        /// </summary>
        public bool UseCustomerTaxCode { get; set; }

        /// <summary>
        /// Tax code for sale freight
        /// </summary>
        public TaxCodeLink FreightTaxCode { get; set; }

        /// <summary>
        /// Credit limit of a sale
        /// </summary>
        public decimal CreditLimit { get; set; }
    }
}
