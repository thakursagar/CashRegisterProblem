using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegisterProblem.Data.Core.US
{
    /// <summary>
    /// USChangeCalculator
    /// </summary>
    public class USChangeCalculator
    {
        /// <summary>
        /// Gets the change owed.
        /// </summary>
        /// <param name="purchase">The purchase.</param>
        /// <returns></returns>
        public static string GetChangeOwed(Purchase purchase)
        {
            // Check if less amount was paid than owed
            if (purchase.Paid < purchase.Owed)
            {
                return $"The customer owes an additional {purchase.Owed - purchase.Paid} dollars";
            }
            else
            {
                var owedAmount = (int)(purchase.Owed * 100);
                var owedChange = ((int)(purchase.Paid * 100)) - owedAmount;
                // Get Currency Denominations for this location
                var currencyDenominations = GetCurrencyDenominations();
                return CheckRandomTwistAndGetChangeOwed(
                    owedChange,
                    owedAmount,
                    currencyDenominations);
            }
        }

        /// <summary>
        /// Gets the currency denominations.
        /// </summary>
        /// <returns></returns>
        private static IReadOnlyList<int> GetCurrencyDenominations()
        {
            return new List<int> { 100, 25, 10, 5, 1 };
        }

        /// <summary>
        /// Checks the random twist and get change owed.
        /// </summary>
        /// <param name="owedChange">The owed change.</param>
        /// <param name="owedAmount">The owed amount.</param>
        /// <param name="currencyDenominations">The currency denominations.</param>
        /// <returns></returns>
        private static string CheckRandomTwistAndGetChangeOwed(
            int owedChange,
            int owedAmount,
            IReadOnlyList<int> currencyDenominations)
        {
            // Can add new divisors here or change the divisor
            return owedAmount % 3 == 0
                ? PerformDivisibleBy3RandomTwist(
                    owedChange,
                    currencyDenominations)
                : GetChangedOwedWithoutRandomTwist(owedChange);
        }

        /// <summary>
        /// Gets the changed owed without random twist.
        /// </summary>
        /// <param name="owedChange">The owed change.</param>
        /// <returns></returns>
        private static string GetChangedOwedWithoutRandomTwist(int owedChange)
        {
            int dollars = owedChange / 100;
            int quarters = (owedChange % 100) / 25;
            int dimes = (owedChange % 100 % 25) / 10;
            int nickels = (owedChange % 100 % 25 % 10) / 5;
            int pennies = (owedChange % 100 % 25 % 10 % 5) / 1;
            return GetDisplayText(
                dollars,
                quarters,
                dimes,
                nickels,
                pennies);
        }

        /// <summary>
        /// Gets the display text.
        /// </summary>
        /// <param name="dollars">The dollars.</param>
        /// <param name="quarters">The quarters.</param>
        /// <param name="dimes">The dimes.</param>
        /// <param name="nickels">The nickels.</param>
        /// <param name="pennies">The pennies.</param>
        /// <returns></returns>
        private static string GetDisplayText(
            int dollars,
            int quarters,
            int dimes,
            int nickels,
            int pennies)
        {
            StringBuilder displayText = new StringBuilder();

            if (dollars > 0)
            {
                displayText.Append(dollars);
                if (dollars == 1)
                    displayText.Append(" dollar");
                else displayText.Append(" dollars");
            }

            if (quarters > 0)
            {
                if (dollars > 0)
                    displayText.Append(",");
                displayText.Append(quarters);
                if (quarters == 1)
                    displayText.Append(" quarter");
                else displayText.Append(" quarters");
            }

            if (dimes > 0)
            {
                if (quarters > 0 || dollars > 0)
                    displayText.Append(",");
                displayText.Append(dimes);
                if (dimes == 1)
                    displayText.Append(" dime");
                else displayText.Append(" dimes");
            }

            if (nickels > 0)
            {
                if (dimes > 0 || quarters > 0 || dollars > 0)
                    displayText.Append(",");
                displayText.Append(nickels);
                if (nickels == 1)
                    displayText.Append(" nickel");
                else displayText.Append(" nickels");
            }

            if (pennies > 0)
            {
                if (nickels > 0 || dimes > 0 || quarters > 0 || dollars > 0)
                    displayText.Append(",");
                displayText.Append(pennies);
                if (pennies == 1)
                    displayText.Append(" penny");
                else displayText.Append(" pennies");
            }

            string stringToReturn = displayText.ToString();
            return string.IsNullOrWhiteSpace(stringToReturn) ? "No change owed" : stringToReturn;
        }

        /// <summary>
        /// Performs the divisible by3 random twist.
        /// </summary>
        /// <param name="owedChange">The owed change.</param>
        /// <param name="currencyDenominations">The currency denominations.</param>
        /// <returns></returns>
        private static string PerformDivisibleBy3RandomTwist(
            int owedChange,
            IReadOnlyList<int> currencyDenominations)
        {
            int dollars = 0;
            int quarters = 0;
            int dimes = 0;
            int nickels = 0;
            int pennies = 0;
            Random randomNumberGenerator = new Random();
            while (owedChange > 0)
            {
                var randomNumber = currencyDenominations[randomNumberGenerator.Next(0, currencyDenominations.Count)];
                if (randomNumber < owedChange)
                {
                    switch (randomNumber)
                    {
                        case 100:
                            dollars += owedChange / 100;
                            owedChange -= (owedChange / 100 * 100);
                            break;
                        case 25:
                            quarters += owedChange / 25;
                            owedChange -= (owedChange / 25 * 25);
                            break;
                        case 10:
                            dimes += owedChange / 10;
                            owedChange -= (owedChange / 10 * 10);
                            break;
                        case 5:
                            nickels += owedChange / 5;
                            owedChange -= (owedChange / 5 * 5);
                            break;
                        case 1:
                            pennies += owedChange / 1;
                            owedChange -= (owedChange / 1 * 1);
                            break;
                    }
                }
            }
            return GetDisplayText(
                dollars,
                quarters,
                dimes,
                nickels,
                pennies);
        }
    }
}