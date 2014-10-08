namespace MYOB.AccountRight.SDK.Contracts.Version2.Sale
{
    /// <summary>
    /// Describes the different order types
    /// </summary>
    public enum OrderLayoutType
    {
        /// <summary>
        /// The order is an <see cref="ServiceOrder"/>
        /// </summary>
        Service,

        /// <summary>
        /// The order is an <see cref="ItemOrder"/>
        /// </summary>
        Item,

        /// <summary>
        /// The order is an <see cref="ProfessionalOrder"/>
        /// </summary>
        Professional,

        /// <summary>
        /// The order is an <see cref="MiscellaneousOrder"/>
        /// </summary>
        Miscellaneous,

        /// <summary>
        /// The order is an <see cref="TimeBillingOrder"/>
        /// </summary>
        TimeBilling,
    }
}