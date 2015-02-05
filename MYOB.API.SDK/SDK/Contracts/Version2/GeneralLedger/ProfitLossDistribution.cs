namespace MYOB.AccountRight.SDK.Contracts.Version2.GeneralLedger
{
    /// <summary>
    /// Describes the entity of a <see cref="ProfitLossDistribution" />
    /// </summary>
    public enum ProfitLossDistributionEntityType
    {
        /// <summary>
        /// Company - there will be no <see cref="ProfitLossDistributionAccount"/> supplied
        /// </summary>
        Company,

        /// <summary>
        /// Partnership
        /// </summary>
        Partnership,

        /// <summary>
        /// Unit-trust
        /// </summary>
        UnitTrust,
    }

    /// <summary>
    /// Describes what the <see cref="ProfitLossDistributionAccount.Value"/> represents 
    /// </summary>
    public enum ProfitLossDistributionUnit
    {
        /// <summary>
        /// The <see cref="ProfitLossDistributionAccount.Value"/> is a percentage
        /// </summary>
        Percent,

        /// <summary>
        /// The <see cref="ProfitLossDistributionAccount.Value"/> is a fixed amount
        /// </summary>
        FixedAmount
    }

    /// <summary>
    /// Describes a profit loss distribution for a company file
    /// </summary>
    public class ProfitLossDistribution
    {
        /// <summary>
        /// The type of entity
        /// </summary>
        public ProfitLossDistributionEntityType Entity { get; set; }

        /// <summary>
        /// The distribution accounts
        /// </summary>
        public ProfitLossDistributionAccount[] ProfitLossDistributionAccounts { get; set; }

        /// <summary>
        /// A number that can be used for change control but does not preserve a date or a time. <br/>
        /// </summary>
        /// <remarks>
        /// ONLY required for updating an existing account. <br/>
        /// NOT required when creating a new account. 
        /// </remarks>
        public string RowVersion { get; set; }
    }

    /// <summary>
    /// A distribution account
    /// </summary>
    public class ProfitLossDistributionAccount
    {
        /// <summary>
        /// The shared header account
        /// </summary>
        public AccountLink HeaderAccount { get; set; }

        /// <summary>
        /// The retained earnings account
        /// </summary>
        public AccountLink RetainedEarningsAccount { get; set; }

        /// <summary>
        /// The current earnings account
        /// </summary>
        public AccountLink CurrentEarningsAccount { get; set; }

        /// <summary>
        /// The value, maybe a <see cref="ProfitLossDistributionUnit.Percent"/> or a <see cref="ProfitLossDistributionUnit.FixedAmount"/>
        /// </summary>
        public decimal Value { get; set; }

        /// <summary>
        /// Describes the type that is in the <see cref="ProfitLossDistributionAccount.Value"/> field
        /// </summary>
        public ProfitLossDistributionUnit Unit { get; set; }
    }
}
