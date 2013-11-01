namespace MYOB.AccountRight.SDK.Contracts.Version2.Contact
{
    /// <summary>
    /// Describes an address for a Contact
    /// </summary>
    public class Address
    {
        /// <summary>
        /// The address slot location 1..5
        /// </summary>
        public int Location { get; set; }

        /// <summary>
        /// The street
        /// </summary>
        public string Street { get; set; }

        /// <summary>
        /// The city
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// The state
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// The postcode
        /// </summary>
        public string PostCode { get; set; }

        /// <summary>
        /// The country
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// A phone number
        /// </summary>
        public string Phone1 { get; set; }

        /// <summary>
        /// A phone number
        /// </summary>
        public string Phone2 { get; set; }

        /// <summary>
        /// A phone number
        /// </summary>
        public string Phone3 { get; set; }

        /// <summary>
        /// A fax number
        /// </summary>
        public string Fax { get; set; }

        /// <summary>
        /// An email address
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// A website
        /// </summary>
        public string Website { get; set; }

        /// <summary>
        /// The primary contact name
        /// </summary>
        public string ContactName { get; set; }

        /// <summary>
        /// Mr, Mrs, Miss, ...
        /// </summary>
        public string Salutation { get; set; }
    }
}