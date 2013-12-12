using MYOB.AccountRight.SDK.Contracts.Version2.Contact;

namespace MYOB.AccountRight.SDK.Contracts.Version2.GeneralLedger
{
    /// <summary>
    /// The different tax code types
    /// </summary>
    public enum TaxCodeType
    {
        /// <summary>
        /// Consolidated
        /// </summary>
        Consolidated,
        
        /// <summary>
        /// ImportDuty
        /// </summary>
        ImportDuty,
        
        /// <summary>
        /// SalesTax
        /// </summary>
        SalesTax,
        
        /// <summary>
        /// GST_VAT (Goods and Services Tax)
        /// </summary>
        GST_VAT,
        
        /// <summary>
        /// InputTaxed
        /// </summary>
        InputTaxed,
        
        /// <summary>
        /// QST
        /// </summary>
        QST,
        
        /// <summary>
        /// LuxuryCarTax
        /// </summary>
        LuxuryCarTax,
        
        /// <summary>
        /// WithholdingsTax (negative rate)
        /// </summary>
        WithholdingsTax,
        
        /// <summary>
        /// NoABN_TFN (negative rate)
        /// </summary>
        NoABN_TFN,
        
        /// <summary>
        /// ECPurchVAT
        /// </summary>
        ECPurchVAT,
        
        /// <summary>
        /// ECSalesVAT
        /// </summary>
        ECSalesVAT,
    }

    /// <summary>
    /// Describes a tax code resource
    /// </summary>
    public class TaxCode : BaseEntity
    {
        /// <summary>
        /// 3 digit code assigned to the tax code.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Description given to the tax code.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The tax types
        /// </summary>
        public TaxCodeType Type { get; set; }

        /// <summary>
        /// Rate of tax assigned
        /// </summary>
        public double Rate { get; set; }

        /// <summary>
        /// Indicates if the rate will be treated as a negative number i.e. see <see cref="TaxCodeType.WithholdingsTax"/> and <see cref="TaxCodeType.NoABN_TFN"/>
        /// </summary>
        public bool IsRateNegative { get; set; }

        /// <summary>
        /// A link to the <see cref="Account"/> resource to use for tax collected
        /// </summary>
        public AccountLink TaxCollectedAccount { get; set; }

        /// <summary>
        /// A link to the <see cref="Account"/> resource to use for tax paid
        /// </summary>
        public AccountLink TaxPaidAccount { get; set; }

        /// <summary>
        /// /// <summary>
        /// A link to the <see cref="Account"/> resource to use for withholding credit
        /// </summary>
        /// </summary>
        public AccountLink WithholdingCreditAccount { get; set; }

        /// <summary>
        /// A link to the <see cref="Account"/> resource to use for withholding payable
        /// </summary>
        public AccountLink WithholdingPayableAccount { get; set; }

        /// <summary>
        /// A link to the <see cref="Account"/> resource to use for import duty payable
        /// </summary>
        public AccountLink ImportDutyPayableAccount { get; set; }

        /// <summary>
        /// A link to a <see cref="Supplier"/> resource
        /// </summary>
        public SupplierLink LinkedSupplier { get; set; }

        /// <summary>
        /// Value which must be exceeded before tax is calculated using this tax code.
        /// </summary>
        public decimal LuxuryCarTaxThreshold { get; set; }
    }
}