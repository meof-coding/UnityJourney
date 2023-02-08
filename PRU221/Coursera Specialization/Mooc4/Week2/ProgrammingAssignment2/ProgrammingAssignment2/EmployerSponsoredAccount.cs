using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingAssignment2
{
    /// <summary>
    /// An employer-sponsored account
    /// </summary>
    class EmployerSponsoredAccount : MutualFund
    {
        public EmployerSponsoredAccount(float deposit) : base(deposit)
        {
            balance = deposit;
        }
        #region Contructor


        #endregion

        #region Public methods
        public override void AddMoney(float amount)
        {
            //doubles the money
            amount *= 2;
            base.AddMoney(amount);
        }
        /// <summary>
        /// Provides balance with account type caption
        /// </summary>
        /// <returns>balance with caption</returns>
        public override string ToString()
        {
            return "Employer-Sponsored Account Balance: " + balance;
        }

        #endregion
    }
}
