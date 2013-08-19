using System;
using System.Collections.Generic;
using MYOB.AccountRight.SDK.Contracts.Version2.GeneralLedger;

namespace MYOB.AccountRight.SDK.Contracts.Version2.Contact
{

    public class Contact : BaseEntity
    {
        public Contact()
        {
            IsActive = true;
        }

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

        public IEnumerable<Address> Addresses { get; set; }

        public IEnumerable<Identifier> Identifiers { get; set; }

        public Identifier CustomList1 { get; set; }
        public Identifier CustomList2 { get; set; }
        public Identifier CustomList3 { get; set; }
        public Identifier CustomField1 { get; set; }
        public Identifier CustomField2 { get; set; }
        public Identifier CustomField3 { get; set; }

        /// <summary>
        /// Read only - only returned for <see cref="Contact"/> entities and not its subtypes.
        /// </summary>
        public ContactType? Type { get; set; }

        public Uri PhotoURI { get; set; }
    }
}