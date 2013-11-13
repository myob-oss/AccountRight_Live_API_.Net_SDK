using System.Collections.Generic;

namespace MYOB.AccountRight.SDK.Contracts.Version2.Sale
{
    /// <summary>
    /// Describe the response of CustomerPayment/RecordWithDiscountsAndFees resource
    /// </summary>
    public class CustomerPaymentRecordWithDiscountsAndFeesResponse
    {
        /// <summary>
        /// The link to customerpayment record generated
        /// </summary>
        public CustomerPaymentLink CustomerPayment { get; set; }

        /// <summary>
        /// The link to the finance charge invoice generated due to applied finance charge
        /// </summary>
        public InvoiceLink FinanceChargeInvoice { get; set; }

        /// <summary>
        /// The negative sale invoices generated due to applied discounts
        /// </summary>
        public IEnumerable<InvoiceLink> DiscountAppliedInvoices { get; set; }

        /// <summary>
        /// The credit settlements generated due to applied discounts
        /// </summary>
        public IEnumerable<CreditSettlementLink> CreditSettlements { get; set; }

    }
}