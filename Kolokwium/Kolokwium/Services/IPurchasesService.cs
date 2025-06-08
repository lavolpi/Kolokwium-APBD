using Kolokwium.DTO;

namespace Kolokwium.Services;

public interface IPurchasesService
{
    
    Task<List<ClientPurchaseDTO>> GetPurchases(int id);
}