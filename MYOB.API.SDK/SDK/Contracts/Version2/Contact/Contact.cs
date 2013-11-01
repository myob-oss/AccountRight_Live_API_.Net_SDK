using System;
using System.Collections.Generic;
using MYOB.AccountRight.SDK.Contracts.Version2.GeneralLedger;

namespace MYOB.AccountRight.SDK.Contracts.Version2.Contact
{
    /// <summary>
    /// A contact entity
    /// </summary>
    public class Contact : BaseEntity
    {
        /// <summary>
        /// Initialises a new instance of the Contact class
        /// </summary>
        public Contact()
        {
            IsActive = true;
        }

        /// <summary>
        /// The company name
        /// </summary>
        public string CompanyName { get; set; }

        /// <summary>
        /// Last Name / Company Name
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// First Name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Is the card an individual or company
        /// </summary>
        public bool IsIndividual { get; set; }

        /// <summary>
        /// Card Identifier
        /// </summary>
        public string DisplayID { get; set; }

        /// <summary>
        /// Status of the Customer
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Notes
        /// </summary>
        public string Notes { get; set; }

        /// <summary>
        /// Identifiers
        /// </summary>
        public string Tags { get; set; }

        /// <summary>
        /// Customer Balance
        /// </summary>
        public decimal CurrentBalance { get; set; }

        /// <summary>
        /// A number of adresses (max 5)
        /// </summary>
        public IEnumerable<Address> Addresses { get; set; }

        /// <summary>
        /// The identifiers applied to this contact
        /// </summary>
        public IEnumerable<Identifier> Identifiers { get; set; }

        /// <summary>
        /// An identifier
        /// </summary>
        public Identifier CustomList1 { get; set; }

        /// <summary>
        /// An identifier
        /// </summary>
        public Identifier CustomList2 { get; set; }

        /// <summary>
        /// An identifier
        /// </summary>
        public Identifier CustomList3 { get; set; }

        /// <summary>
        /// An identifier
        /// </summary>
        public Identifier CustomField1 { get; set; }

        /// <summary>
        /// An identifier
        /// </summary>
        public Identifier CustomField2 { get; set; }

        /// <summary>
        /// An identifier
        /// </summary>
        public Identifier CustomField3 { get; set; }

        /// <summary>
        /// Read only - only returned for <see cref="Contact"/> entities and not its subtypes.
        /// </summary>
        public ContactType? Type { get; set; }

        /// <summary>
        /// The URI to a photo (image) of this contact
        /// </summary>
        public Uri PhotoURI { get; set; }
    }
}