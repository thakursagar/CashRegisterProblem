using CashRegisterProblem.Common.Interfaces;
using CashRegisterProblem.Common.Utilities;
using CashRegisterProblem.Data.Core.US;
using System.Collections.Generic;

namespace CashRegisterProblem.Common.CashRegisterClients
{
    /// <summary>
    /// CashRegisterClientUS
    /// </summary>
    /// <seealso cref="CashRegisterProblem.Common.Interfaces.ICashRegisterClient" />
    public sealed class CashRegisterClientUS : ICashRegisterClient
    {
        /// <summary>
        /// Processes the input file and calculate change.
        /// </summary>
        /// <param name="inputPath">The input path.</param>
        /// <param name="outputPath">The output path.</param>
        public void ProcessInputFileAndCalculateChange(
            string inputPath,
            string outputPath)
        {
            // Process Input
            var purchases = FileUtility.ProcessInputFile(inputPath);
            var owedAmounts = new List<string>();
            foreach (var purchase in purchases)
            {
                owedAmounts.Add(USChangeCalculator.GetChangeOwed(purchase));
            }
            // Write Output
            FileUtility.WriteOutput(outputPath, owedAmounts);
        }
    }
}
