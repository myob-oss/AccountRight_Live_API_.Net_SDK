using System.Collections.Generic;

namespace MYOB.AccountRight.SDK.Contracts.Version2.Purchase
{
    /// <summary>
    /// Describe the response of SupplierPayment/RecordWithDiscountsAndFees resource
    /// </summary>
    public class SupplierPaymentRecordWithDiscountsAndFeesResponse
    {
        /// <summary>
        /// Link to generated SupplierPayment record 
        /// </summary>
        public SupplierPaymentLink SupplierPayment { get; set; }

        /// <summary>
        /// Link to generated finance charge invoice due to applied finance charge
        /// </summary>
        public BillLink FinanceChargeBill { get; set; }

        /// <summary>
        /// The generated negative purchase bills due to applied discounts
        /// </summary>
        public IEnumerable<BillLink> DiscountAppliedBills { get; set; }

        /// <summary>
        /// The generated credit settlements due to applied discounts
        /// </summary>
        public IEnumerable<DebitSettlementLink> DebitSettlements { get; set; }
    }
}
