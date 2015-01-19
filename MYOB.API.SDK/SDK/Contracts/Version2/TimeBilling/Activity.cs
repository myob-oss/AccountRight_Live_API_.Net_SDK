using MYOB.AccountRight.SDK.Contracts.Version2.GeneralLedger;

namespace MYOB.AccountRight.SDK.Contracts.Version2.TimeBilling
{
    /// <summary>
    /// Describes the base Activity
    /// </summary>
    public class Activity : BaseEntity
    {
        /// <summary>
        /// Construct an <see cref="Activity"/> object
        /// </summary>
        public Activity()
        {
            IsActive = true;
        }

        /// <summary>
        /// The display identifier
        /// </summary>
        public string DisplayID { get; set; }

        /// <summary>
        /// The name of the <see cref="Activity"/>
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The activity description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The active state
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// The activity type
        /// </summary>
        public ActivityType Type { get; set; }

        /// <summary>
        /// The unit of measurement; if <see cref="Type"/> is <see cref="ActivityType.Hourly"/> then this defaults to "Hour"
        /// </summary>
        public string UnitOfMeasurement { get; set; }

        /// <summary>
        /// The activity status
        /// </summary>
        public ActivityStatus Status { get; set; }

        /// <summary>
        /// Describes how the activity is charged
        /// </summary>
        public ChargeableDetails ChargeableDetails { get; set; }
    }

    /// <summary>
    /// Descibes how an activity is charged
    /// </summary>
    public class ChargeableDetails
    {
        /// <summary>
        /// Should the <see cref="Activity.Description"/> be used with Sales
        /// </summary>
        public bool UseDescriptionOnSales { get; set; }

        /// <summary>
        /// The income account
        /// </summary>
        public AccountLink IncomeAccount { get; set; }

        /// <summary>
        /// The tax code to apply
        /// </summary>
        public TaxCodeLink TaxCode { get; set; }

        /// <summary>
        /// What is the rate of the activity; if <see cref="Activity.Type"/> is <see cref="ActivityType.NonHourly"/> then this should default to <see cref="ChargeableDetailsRate.ActivityRate"/>.
        /// </summary>
        public ChargeableDetailsRate Rate { get; set; }

        /// <summary>
        /// The activity rate; only applicable when <see cref="ChargeableDetailsRate"/> is <see cref="ChargeableDetailsRate.ActivityRate"/>.
        /// </summary>
        public decimal? ActivityRateExcludingTax { get; set; }
    }

    /// <summary>
    /// Describes the type of activity
    /// </summary>
    public enum ActivityType
    {
        /// <summary>
        /// Hourly
        /// </summary>
        Hourly,

        /// <summary>
        /// Non-hourly
        /// </summary>
        NonHourly,
    }

    /// <summary>
    /// The activity status
    /// </summary>
    public enum ActivityStatus
    {
        /// <summary>
        /// Chargeable
        /// </summary>
        Chargeable,

        /// <summary>
        /// Non-chargeable
        /// </summary>
        NonChargeable
    }

    /// <summary>
    /// The chargeable details rate
    /// </summary>
    public enum ChargeableDetailsRate
    {
        /// <summary>
        /// Use the employee billing rate
        /// </summary>
        EmployeeBillingRate,

        /// <summary>
        /// Use the customer billing rate
        /// </summary>
        CustomerBillingRate,

        /// <summary>
        /// Use the activity billing rate
        /// </summary>
        ActivityRate,
    }
}