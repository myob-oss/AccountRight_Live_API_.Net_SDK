using System.Collections.Generic;

namespace MYOB.AccountRight.SDK.Contracts.Version2.PayrollCategory
{
    /// <summary>
    /// Describes the Entitlement PayrollCategory
    /// </summary>
    public class PayrollCategoryEntitlement : PayrollCategory
    {
        /// <summary>
        /// Print details on the pay advice
        /// </summary>
        public bool PrintOnPayAdvice { get; set; }

        /// <summary>
        /// Entitlements earned can carry into the next fianacial year
        /// </summary>
        public bool CarryEntitlementOverToNextYear { get; set; }

        /// <summary>
        /// Details on how the entitlements are calculated
        /// </summary>
        public PayrollCategoryEntitlementCalculationBasis CalculationBasis { get; set; }

        /// <summary>
        /// Related <see cref="PayrollCategoryWage"/>
        /// </summary>
        public IEnumerable<PayrollCategoryLink> LinkedPayrollCategoryWages { get; set; }

        /// <summary>
        /// Exempt this <see cref="PayrollCategory"/> from deduction and tax calculations 
        /// </summary>
        public IEnumerable<PayrollCategoryLink> Exemptions { get; set; }
    }
}