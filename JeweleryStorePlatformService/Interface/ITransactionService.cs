using JeweleryStorePlatformBusinessObject.Transaction;

namespace JeweleryStorePlatformService.Interface;

public interface ITransactionService
{
    public Task<Transaction?> GetLatestTransactionByOrderId(int userId, int orderId);
    public Task<Transaction> GetTransactionById(int id);
}