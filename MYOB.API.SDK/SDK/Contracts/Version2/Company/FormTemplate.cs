namespace MYOB.AccountRight.SDK.Contracts.Version2.Company
{
    /// <summary>
    /// Printed Form Template
    /// </summary>
    public class FormTemplate
    {
        /// <summary>
        /// Form name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Type
        /// </summary>
        public FormTemplateType Type { get; set; }

        /// <summary>
        /// Form Layout where applicable (e.g. Invoice, Order, Bill)
        /// </summary>
        public FormTemplateTypeLayout? Layout { get; set; }

        /// <summary>
        /// Template is System (e.g. not Custom)
        /// </summary>
        public bool IsSystem { get; set; }
    }

    /// <summary>
    /// Layout
    /// </summary>
    public enum FormTemplateTypeLayout
    {
        /// <summary>
        /// Item Layout
        /// </summary>
        Item,
        /// <summary>
        /// Service Layout
        /// </summary>
        Service,
        /// <summary>
        /// Professional Layout
        /// </summary>
        Professional,
        /// <summary>
        /// TimeBilling Layout
        /// </summary>
        TimeBilling
    }

    /// <summary>
    /// Printer Form Template Type
    /// </summary>
    public enum FormTemplateType
    {
        /// <summary>
        /// Sale (Invoice, Order, Quote)
        /// </summary>
        Sale,
        /// <summary>
        /// Purchases (Bill, Order, Quote)
        /// </summary>
        Purchase,
        /// <summary>
        /// Payslip
        /// </summary>
        Payslip
    }
}
