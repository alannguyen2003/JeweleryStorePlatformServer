using JeweleryStorePlatformBusinessObject.Transaction;
using JeweleryStorePlatformRepository.Interface;
using JeweleryStorePlatformService.Interface;

namespace JeweleryStorePlatformService;

public class TransactionService : ITransactionService
{
    private readonly ITransactionRepository _transactionRepository;

    public TransactionService(ITransactionRepository transactionRepository)
    {
        _transactionRepository = transactionRepository;
    }

    public async Task<Transaction?> GetLatestTransactionByOrderId(int userId, int orderId)
    {
        return await _transactionRepository.GetLatestTransactionOfUser(userId, orderId);
    }

    public Task<Transaction> GetTransactionById(int id)
    {
        throw new NotImplementedException();
    }
}