using CashRegisterProblem.Common.CashRegisterClients;
using CashRegisterProblem.Common.Interfaces;
using CashRegisterProblem.Data.Enums;
using System;

namespace CashRegisterProblem.Common.Factories
{
    /// <summary>
    /// CashRegisterClientFactory
    /// </summary>
    /// <seealso cref="CashRegisterProblem.Common.Interfaces.ICashRegisterClientFactory" />
    public sealed class CashRegisterClientFactory : ICashRegisterClientFactory
    {
        /// <summary>
        /// Gets the cash register client based on location.
        /// </summary>
        /// <param name="location">The location.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException">Cash Register for Location France is not implemented.</exception>
        /// <exception cref="NotSupportedException">Input not valid.</exception>
        public ICashRegisterClient GetCashRegisterClientBasedOnLocation(Location location)
        {
            switch (location)
            {
                case Location.US:
                    return new CashRegisterClientUS();
                case Location.France:
                    throw new NotImplementedException("Cash Register for Location France is not implemented.");
                default:
                    throw new NotSupportedException("Input not valid.");
            }
        }
    }
}
