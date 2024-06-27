﻿using System;
using MYOB.AccountRight.SDK.Contracts.Version2.Contact;
using MYOB.AccountRight.SDK.Contracts.Version2.GeneralLedger;

namespace MYOB.AccountRight.SDK.Contracts.Version2.Sale
{
    /// <summary>
    /// Describe the Sale/Invoice resource
    /// </summary>
    public class Invoice : Sale
    {
        /// <summary>
        /// Initialise
        /// </summary>
        public Invoice()
        {
            IsTaxInclusive = true;
            InvoiceDeliveryStatus = DocumentAction.Print;
        }

        /// <summary>
        /// The invoice type - this is only populated when querying the "/Sale/Invoice" endpoint
        /// </summary>
        public InvoiceLayoutType? InvoiceType { get; set; }

        /// <summary>
        /// ShipTo address of the sale invoice.
        /// </summary>
        /// <remarks>
        /// Not supported by Professional or Miscellaneous invoices
        /// </remarks>
        public string ShipToAddress { get; set; }

        /// <summary>
        /// Customer payment terms
        /// </summary>
        public InvoiceTerms Terms { get; set; }

        /// <summary>
        /// True indicates the transaction is set to tax inclusive.
        /// False indicates the transaction is not tax inclusive.
        /// </summary>
        public bool IsTaxInclusive { get; set; }

        /// <summary>
        /// Sum of all tax exclusive line amounts applicable to the sale invoice.
        /// </summary>
        public decimal Subtotal { get; set; }
        /// <summary>
        /// Sum of all tax exclusive line amounts applicable to the sale invoice in foreign currency.
        /// </summary>
        public decimal? SubtotalForeign { get; set; }

        /// <summary>
        /// Tax freight amount applicable to the sale invoice.
        /// </summary>
        /// <remarks>
        /// Not supported by Professional or Miscellaneous invoices
        /// </remarks>
        public decimal Freight { get; set; }
        /// <summary>
        /// Tax freight amount applicable to the sale invoice in foreign currency.
        /// </summary>
        /// <remarks>
        /// Not supported by Professional or Miscellaneous invoices
        /// </remarks>
        public decimal? FreightForeign { get; set; }

        /// <summary>
        /// The freight Tax code
        /// </summary>
        /// <remarks>
        /// Not supported by Professional or Miscellaneous invoices
        /// </remarks>
        public TaxCodeLink FreightTaxCode { get; set; }

        /// <summary>
        /// Total of all tax amounts applicable to the sale invoice.
        /// </summary>
        public decimal TotalTax { get; set; }
        /// <summary>
        /// Total of all tax amounts applicable to the sale invoice in foreign currency.
        /// </summary>
        public decimal? TotalTaxForeign { get; set; }

        /// <summary>
        /// Total amount of the sale invoice.
        /// </summary>
        public decimal TotalAmount { get; set; }
        /// <summary>
        /// Total amount of the sale invoice in foreign currency.
        /// </summary>
        public decimal? TotalAmountForeign { get; set; }

        /// <summary>
        /// The category associated with the Invoice
        /// </summary>
        public CategoryLink Category { get; set; }

        /// <summary>
        /// The employee contact
        /// </summary>
        public CardLink Salesperson { get; set; }

        /// <summary>
        /// Sale invoice comment.
        /// </summary>
        /// <remarks>
        /// Not supported by Miscellaneous invoices
        /// </remarks>
        public string Comment { get; set; }

        /// <summary>
        /// Shipping method text.
        /// </summary>
        /// <remarks>
        /// Not supported by Professional or Miscellaneous invoices
        /// </remarks>
        public string ShippingMethod { get; set; }

        /// <summary>
        /// Journal memo text describing the sale.
        /// </summary>
        public string JournalMemo { get; set; }

        /// <summary>
        /// Referral Source selected on the sale invoice.
        /// </summary>
        public string ReferralSource { get; set; }

        /// <summary>
        /// The date of the last payment made on the invoice
        /// </summary>
        /// <remarks>
        /// Availability: 2013.5 (Cloud), 2014.1 (Desktop)
        /// </remarks>
        public DateTime? LastPaymentDate { get; set; }

        /// <summary>
        /// Invoice delivery status assigned.
        /// </summary>
        /// <remarks>
        /// Not supported by Miscellaneous invoices
        /// </remarks>
        public DocumentAction InvoiceDeliveryStatus { get; set; }

        /// <summary>
        /// The source Order when an Invoice is converted from an Order
        /// or when you wish to convert an existing Open Order to a new Invoice
        /// Available from 2014.3
        /// </summary>
        public SaleOrderLink Order { get; set; }
        
        /// <summary>
        /// The Foreign Currency associated with the entity
        /// </summary>
        public CurrencyLink ForeignCurrency { get; set; }

        /// <summary>
        /// The Local to Foreign Currency Exchange Rate associated with the entity
        /// </summary>
        public decimal? CurrencyExchangeRate { get; set; }

        /// <summary>
        /// If true, surcharge fee could apply to invoice 
        /// </summary>
        public bool CanApplySurcharge { get; set; }
        
        /// <summary>
        /// If true or null, BPay could apply to invoice when OIP enabled  
        /// </summary>
        public bool? CanApplyBPay { get; set; }

    }
}
