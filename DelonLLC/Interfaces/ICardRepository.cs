using DelonLLC.Dtos;
using DelonLLC.Model;

namespace DelonLLC.Interfaces
{
    public interface ICardRepository
    {
        Task<CardRequestDto> CreateCustomerCard(CardRequestDto request);

        Task<CardRequestDto?> GetCustomerCard(Guid cardId);

        Task<IEnumerable<CardRequestDto>> GetAllCards();

        Task<bool> CheckIfCardHolderExists(string card_holder);

        Task<bool> CheckIfCardNumberExists(string card_number);

        Task<bool> CheckIfMobileNumberExists(string mobile_number);
    }
}
