namespace MYOB.AccountRight.SDK.Contracts.Version2.Company
{
    /// <summary>
    /// Describes the reports and forms preferences
    /// </summary>
    public class CompanyReportsAndFormsPreferences
    {
        /// <summary>
        /// Report taxable payments made to contractors
        /// </summary>
        public bool ReportTaxablePayments { get; set; }

        /// <summary>
        /// Email default templates preferences
        /// </summary>
        public CompanyReportsAndFormsEmailDefaults EmailDefaults { get; set; }
    }

    /// <summary>
    ///Email default templates preferences
    /// </summary>
    public class CompanyReportsAndFormsEmailDefaults
    {
        /// <summary>
        /// Email defaults for sales
        /// </summary>
        public EmailDefaultsSales Sales { get; set; }
        
        /// <summary>
        /// Email defaults for purchases
        /// </summary>
        public EmailDefaultsPurchases Purchases { get; set; }

        /// <summary>
        /// Email defaults for pay slip
        /// </summary>
        public EmailDefaultsTemplateBase PaySlips { get; set; }
    }

    /// <summary>
    /// Email defaults for purchases
    /// </summary>
    public class EmailDefaultsPurchases
    {
        /// <summary>
        /// Email defaults for purchases - Bill
        /// </summary>
        public EmailDefaultsTemplate Bill { get; set; }

        /// <summary>
        /// Email defaults for purchases - Order
        /// </summary>
        public EmailDefaultsTemplate Order { get; set; }

        /// <summary>
        /// Email defaults for purchases - Quote
        /// </summary>
        public EmailDefaultsTemplate Quote { get; set; }
    }

    /// <summary>
    /// Email defaults for sales
    /// </summary>
    public class EmailDefaultsSales
    {
        /// <summary>
        /// Email defaults for sales - Invoice
        /// </summary>
        public EmailDefaultsTemplate Invoice { get; set; }

        /// <summary>
        /// Email defaults for sales - Order
        /// </summary>
        public EmailDefaultsTemplate Order { get; set; }

        /// <summary>
        /// Email defaults for sales - Quote
        /// </summary>
        public EmailDefaultsTemplate Quote { get; set; }
    }

    /// <summary>
    /// Email defaults base template inlcude subject and message
    /// </summary>
    public class EmailDefaultsTemplateBase
    {
        /// <summary>
        /// Default email subject lines
        /// </summary>
        public string Subject { get; set; }
        
        /// <summary>
        /// Default email message body
        /// </summary>
        public string Message { get; set; }
    }

    /// <summary>
    /// Email defaults template inlcude subject, message and flag of including transaction number in subject
    /// </summary>
    public class EmailDefaultsTemplate : EmailDefaultsTemplateBase
    {
        /// <summary>
        /// Indicates whether or not include transaction number in subject
        /// </summary>
        public bool IncludeNumberInSubject { get; set; }
    }

}
