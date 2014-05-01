namespace MYOB.AccountRight.SDK.Contracts.Version2.Company
{
    /// <summary>
    /// Company preferences
    /// </summary>
    public class CompanyPreferences
    {
        /// <summary>
        /// System preferences
        /// </summary>
        public CompanySystemPreferences System { get; set; }

        /// <summary>
        /// Reports and forms preferences
        /// </summary>
        public CompanyReportsAndFormsPreferences ReportsAndForms { get; set; }

        /// <summary>
        /// Banking preferences
        /// </summary>
        public CompanyBankingPreferences Banking { get; set; }

        /// <summary>
        /// Sales preferences
        /// </summary>
        public CompanySalesPreferences Sales { get; set; }

        /// <summary>
        /// Purchase preferences
        /// </summary>
        public CompanyPurchasesPreferences Purchases { get; set; }

        /// <summary>
        /// Timesheet preferences
        /// </summary>
        public CompanyTimesheetPreferences Timesheets { get; set; }

        /// <summary>
        /// A number that can be used for change control but does not preserve a date or a time. <br/>
        /// </summary>
        public string RowVersion { get; set; }
    }

}
