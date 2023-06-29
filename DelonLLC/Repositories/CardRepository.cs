using DelonLLC.Data;
using DelonLLC.Dtos;
using DelonLLC.Functions;
using DelonLLC.Interfaces;
using DelonLLC.Model;
using Microsoft.EntityFrameworkCore;

namespace DelonLLC.Repositories
{
    public class CardRepository : ICardRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly IHelperFunctions _helper;
        public CardRepository(AppDbContext context, IHelperFunctions helperFunctions) 
        { 
            _dbContext = context;
            _helper = helperFunctions;
        }

        public async Task<CardRequestDto> CreateCustomerCard(CardRequestDto request)
        {
            var newCard = new CardRequestDto()
            {
                id = Guid.NewGuid(),
                customer_id = request.customer_id,
                status = request.status,
                card_type = request.card_type,
                card_description = request.card_description,
                card_holder = request.card_holder,
                card_number = request.card_number,
                security_code = request.security_code,
                expiry_date = request.expiry_date,
                bank_name = request.bank_name,
                country = request.country,
                mobile_network = request.mobile_network,
                mobile_number = request.mobile_number,
                created_at = DateTimeOffset.Now,
                updated_at = DateTimeOffset.Now,

            };
            await _dbContext.customer_cards.AddAsync(newCard);
            await _dbContext.SaveChangesAsync();
            return newCard;
        }

        public async Task<IEnumerable<CardRequestDto>> GetAllCards()
        {
            var cards = await _dbContext.customer_cards.AsNoTracking().ToListAsync();
            return cards;
        }

        public async Task<CardRequestDto?> GetCustomerCard(Guid cardId)
        {
            var card = await _dbContext.customer_cards.FindAsync(cardId);

            if (card is null)
            {
                return null;
            }
            return card;
        }

        public async Task<bool> CheckIfCardHolderExists(string card_holder)
        {
            var cards = await GetAllCards();


            var exists = cards.Where(c => c.card_type == _helper.ResolveCardType(CardType.bank_card) && c.card_holder.Trim() == card_holder.Trim());

            if (exists.Any())
            {
                return true;
            }
            return false;
        }

        public async Task<bool> CheckIfCardNumberExists(string card_number)
        {
            var cards = await GetAllCards();

            var exists = cards.Where(c => c.card_type == _helper.ResolveCardType(CardType.bank_card) && c.card_number.Trim() == card_number.Trim());

            if (exists.Any())
            {
                return true;
            }
            return false;
        }

        public async Task<bool> CheckIfMobileNumberExists(string mobile_number)
        {
            var cards = await GetAllCards();

            var exists = cards.Where(c => c.card_type == _helper.ResolveCardType(CardType.mobile_money) && c.mobile_number.Trim() == mobile_number.Trim());

            if (exists.Any())
            {
                return true;
            }
            return false;
        }
    }
}
