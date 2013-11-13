using System.Collections.Generic;

namespace MYOB.AccountRight.SDK.Contracts.Version2.Purchase
{
    /// <summary>
    /// Common class for purcahse Professional, Miscelleneous, Service and Item bill
    /// </summary>
    /// <typeparam name="TBillLine">Class that implement BillLine</typeparam>
    public class BillWithLines<TBillLine>: Bill
        where TBillLine : BillLine
    {
        /// <summary>
        /// Collection of purchase line
        /// </summary>
        public IEnumerable<TBillLine> Lines { get; set; }
    }
}
