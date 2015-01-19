namespace MYOB.AccountRight.SDK.Contracts
{
    /// <summary>
    /// Company's info
    /// </summary>
    public class Company 
    {
        /// <summary>
        /// Company Name
        /// </summary>
        public string CompanyName { get; set; }

         /// <summary>
        /// Serial Number
        /// </summary>
        public string SerialNumber { get; set; }
        
        /// <summary>
        /// Company Address
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Company Phone Number
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Company Fax Number
        /// </summary>
        public string FaxNumber { get; set; }

        /// <summary>
        /// Company Email Address
        /// </summary>
        public string EmailAddress { get; set; }

        /// <summary>
        /// Australian Business Number (ABN) OR  Tax File Number (TFN)
        /// <para>ONLY for AU Company File</para>
        /// </summary>
        public string ABNOrTFN { get; set; }

        /// <summary>
        /// ABN Branch 
        /// <para>ONLY for AU Company File</para>
        /// </summary>
        public string ABNBranch { get; set; }

        /// <summary>
        /// Australian Company Number 
        /// <para>ONLY for AU Company File</para>
        /// </summary>
        public string ACN { get; set; }

        /// <summary>
        /// Sales Tax Number 
        /// <para>ONLY for AU Company File</para>
        /// </summary>
        public string SalesTaxNumber { get; set; }

        /// <summary>
        /// Payee Number
        /// <para>ONLY for AU Company File</para>
        /// </summary>
        public string PayeeNumber { get; set; }

        /// <summary>
        /// GST Registration Number
        /// <para>ONLY for NZ Company File</para>
        /// </summary>
        public string GSTRegistrationNumber { get; set; }

        /// <summary>
        /// Company Registration Number
        /// <para>ONLY for NZ Company File</para>
        /// </summary>
        public string CompanyRegistrationNumber { get; set; }

        /// <summary>
        /// <para>True indicates the company file is readonly.</para>
        /// <para>False indicates the company file not readonly.</para>
        /// </summary>
        public bool ReadOnly { get; set; }
    }
}
