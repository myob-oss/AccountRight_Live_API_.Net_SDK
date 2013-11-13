using MYOB.AccountRight.SDK.Contracts.Version2.Contact;

namespace MYOB.AccountRight.SDK.Contracts.Version2.GeneralLedger
{
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
        public string Type { get; set; }

        /// <summary>
        /// Rate of tax assigned
        /// </summary>
        public double Rate { get; set; }

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
        public AccountLink WithHoldingCreditAccount { get; set; }

        /// <summary>
        /// A link to the <see cref="Account"/> resource to use for withholding payable
        /// </summary>
        public AccountLink WithHoldingPayableAccount { get; set; }

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