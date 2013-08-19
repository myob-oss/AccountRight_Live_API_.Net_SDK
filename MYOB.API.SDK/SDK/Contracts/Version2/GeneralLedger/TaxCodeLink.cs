namespace MYOB.AccountRight.SDK.Contracts.Version2.GeneralLedger
{

    /// <summary>
    /// A reference to a related <see cref="TaxCode"/> entity
    /// </summary>
    public class TaxCodeLink : BaseLink
    {
        /// <summary>
        /// 3 didgit tax code.
        /// </summary>
        public string Code { get; set; }
    }
}