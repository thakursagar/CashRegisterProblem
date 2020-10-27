using CashRegisterProblem.Data.Core.US;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegisterProblem.Data.Core
{
    /// <summary>
    /// Purchase
    /// </summary>
    public sealed class Purchase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Purchase"/> class.
        /// </summary>
        /// <param name="owed">The owed.</param>
        /// <param name="paid">The paid.</param>
        public Purchase(
            decimal owed,
            decimal paid)
        {
            Owed = owed;
            Paid = paid;
        }

        /// <summary>
        /// Gets the owed.
        /// </summary>
        /// <value>
        /// The owed.
        /// </value>
        public decimal Owed { get; }
        /// <summary>
        /// Gets the paid.
        /// </summary>
        /// <value>
        /// The paid.
        /// </value>
        public decimal Paid { get; }
    }
}
