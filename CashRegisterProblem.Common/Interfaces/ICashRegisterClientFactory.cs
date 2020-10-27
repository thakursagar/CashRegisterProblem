using CashRegisterProblem.Data.Enums;

namespace CashRegisterProblem.Common.Interfaces
{
    public interface ICashRegisterClientFactory
    {
        ICashRegisterClient GetCashRegisterClientBasedOnLocation(Location location);
    }
}
