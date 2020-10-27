namespace CashRegisterProblem.Common.Interfaces
{
    public interface ICashRegisterClient
    {
        void ProcessInputFileAndCalculateChange(
            string inputPath,
            string outputPath);
    }
}
