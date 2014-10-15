using MYOB.AccountRight.SDK.Contracts.Version2.GeneralLedger;
using MYOB.AccountRight.SDK.Contracts.Version2.Sale;

namespace MYOB.AccountRight.SDK.Contracts.Version2.Purchase
{
    /// <summary>
    /// Describes a line for a <see cref="MiscellaneousPurchaseOrder"/>
    /// </summary>
    public class MiscellaneousPurchaseOrderLine : OrderLine
    {
        /// <summary>
        /// The line amount (depends on the value of <see cref="PurchaseOrder.IsTaxInclusive"/> in the parent <see cref="PurchaseOrder"/>)
        /// </summary>
        /// <remarks>
        /// Only applicable when <see cref="OrderLine.Type"/>=<see cref="OrderLineType.Transaction"/>
        /// </remarks>
        public decimal Total { get; set; }

        /// <summary>
        /// The account
        /// </summary>
        /// <remarks>
        /// Only applicable when <see cref="OrderLine.Type"/>=<see cref="OrderLineType.Transaction"/>
        /// </remarks>
        public AccountLink Account { get; set; }

        /// <summary>
        /// The job
        /// </summary>
        /// <remarks>
        /// Only applicable when <see cref="OrderLine.Type"/>=<see cref="OrderLineType.Transaction"/>
        /// </remarks>
        public JobLink Job { get; set; }

        /// <summary>
        /// The applied tax code
        /// </summary>
        /// <remarks>
        /// Only applicable when <see cref="OrderLine.Type"/>=<see cref="OrderLineType.Transaction"/>
        /// </remarks>
        public TaxCodeLink TaxCode { get; set; }
    }
}