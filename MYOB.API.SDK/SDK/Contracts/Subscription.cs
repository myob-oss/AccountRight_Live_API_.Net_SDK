using System;

namespace MYOB.AccountRight.SDK.Contracts
{
    /// <summary>
    /// SubscriptionProduct class
    /// </summary>
    public class SubscriptionProduct
    {
        /// <summary>
        /// Product Line the product is associated with, i.e. New Essentials
        /// </summary>
        public string ProductLine { get; set; }

        /// <summary>
        /// New Essentials product name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Display Name for the New Essentials product
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// New Essentials product code
        /// </summary>
        public string Id { get; set; }
    }

    /// <summary>
    /// Subscription Class
    /// </summary>
    public class Subscription
    {
        /// <summary>
        ///  Indicates if the file is a Trial version
        /// </summary>
        public bool IsTrial { get; set; }

        /// <summary>
        /// The following set of information pulls through details for the New Essentials product
        /// </summary>
        public SubscriptionProduct Product { get; set; }
    }
}
