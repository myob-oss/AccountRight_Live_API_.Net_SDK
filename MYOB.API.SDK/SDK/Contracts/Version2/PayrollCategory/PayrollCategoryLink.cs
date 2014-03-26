namespace MYOB.AccountRight.SDK.Contracts.Version2.PayrollCategory
{
    /// <summary>
    /// A link to a PayrollCategory
    /// </summary>
    public class PayrollCategoryLink : BaseLink
    {
        /// <summary>
        /// The name  of the <see cref="PayrollCategory"/>
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The type of <see cref="PayrollCategory"/>
        /// </summary>
        public PayrollCategoryType Type { get; set; }
    }
}