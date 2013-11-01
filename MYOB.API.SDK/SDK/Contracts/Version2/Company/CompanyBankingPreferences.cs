namespace MYOB.AccountRight.SDK.Contracts.Version2.Company
{
    /// <summary>
    /// Describes the company banking preferences
    /// </summary>
    public class CompanyBankingPreferences
    {
        /// <summary>
        /// Group it with other undeposited funds when receive money
        /// <para>True - Group with other undeposited funds</para>
        /// <para>False - Do NOT group with other undeposited funds</para>
        /// </summary>
        public bool PreferToReceiveMoneyIntoUndepositedFunds { get; set; }
    }
}
