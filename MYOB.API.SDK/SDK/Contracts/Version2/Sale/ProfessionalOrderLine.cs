﻿using System;
using MYOB.AccountRight.SDK.Contracts.Version2.GeneralLedger;

namespace MYOB.AccountRight.SDK.Contracts.Version2.Sale
{
    /// <summary>
    /// Describes a line for a <see cref="ProfessionalOrder"/>
    /// </summary>
    public class ProfessionalOrderLine : OrderLine
    {
        /// <summary>
        /// The date         
        /// </summary>
        /// <remarks>
        /// Only applicable when <see cref="OrderLine.Type"/>=<see cref="OrderLineType.Transaction"/>
        /// </remarks>
        public DateTime? Date { get; set; }

        /// <summary>
        /// The line amount (depends on the value of <see cref="Order.IsTaxInclusive"/> in the parent <see cref="Order"/>)
        /// </summary>
        /// <remarks>
        /// Only applicable when <see cref="OrderLine.Type"/>=<see cref="OrderLineType.Transaction"/>
        /// </remarks>
        public decimal Total { get; set; }

        /// <summary>
        /// The account
        /// </summary>
        /// <remarks>
        /// Only applicable when <see cref="OrderLine.Type"/>=<see cref="OrderLineType.Transaction"/>
        /// </remarks>
        public AccountLink Account { get; set; }

        /// <summary>
        /// The job
        /// </summary>
        /// <remarks>
        /// Only applicable when <see cref="OrderLine.Type"/>=<see cref="OrderLineType.Transaction"/>
        /// </remarks>
        public JobLink Job { get; set; }

        /// <summary>
        /// The applied tax code
        /// </summary>
        /// <remarks>
        /// Only applicable when <see cref="OrderLine.Type"/>=<see cref="OrderLineType.Transaction"/>
        /// </remarks>
        public TaxCodeLink TaxCode { get; set; }
    }
}