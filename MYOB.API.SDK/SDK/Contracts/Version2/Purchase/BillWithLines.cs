using System.Collections.Generic;

namespace MYOB.AccountRight.SDK.Contracts.Version2.Purchase
{
    public class BillWithLines<TBillLine>: Bill
        where TBillLine : BillLine
    {
        public IEnumerable<TBillLine> Lines { get; set; }
    }
}
