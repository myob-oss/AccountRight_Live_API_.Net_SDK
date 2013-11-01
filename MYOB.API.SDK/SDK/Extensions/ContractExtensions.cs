using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYOB.AccountRight.SDK.Contracts.Version2.GeneralLedger;

namespace MYOB.AccountRight.SDK.Extensions
{
    /// <summary>
    /// Extension methods that are related to the <see cref="MYOB.AccountRight.SDK.Contracts"/> namespace.
    /// </summary>
    public static class ContractExtensions
    {
        /// <summary>
        /// Used to get the prefix number for a classification that is ued to make the first part of an Account DisplayID
        /// </summary>
        /// <param name="classification"></param>
        /// <returns>The prefix nuber for the account</returns>
        public static int GetDisplayIdPrefix(this Classification classification)
        {
            switch (classification)
            {
                case Classification.Liability:
                    return 2;
                case Classification.Equity:
                    return 3;
                case Classification.Income:
                    return 4;
                case Classification.CostOfSales:
                    return 5;
                case Classification.Expense:
                    return 6;
                case Classification.OtherIncome:
                    return 8;
                case Classification.OtherExpense:
                    return 9;
                default:
                case Classification.Asset:
                    return 1;
            }
        }
    }
}
