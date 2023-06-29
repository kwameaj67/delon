using DelonLLC.Dtos;
using DelonLLC.Functions;
using DelonLLC.Interfaces;
using DelonLLC.Model;
using DelonLLC.Responses;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace DelonLLC.Controllers
{
    [ApiController]
    [Route("api/card-requests")]
    public class CustomerCardController : ControllerBase
    {
        private readonly ILogger<CustomerCardController> _logger;
        private readonly ICardRepository _cardRepository;
        private readonly IHelperFunctions _helper;

        public CustomerCardController(ILogger<CustomerCardController> logger, ICardRepository cardRepository, IHelperFunctions helpersFunctions)
        {
            _logger = logger;
            _cardRepository = cardRepository;
            _helper = helpersFunctions;
        }

        // POST /api/card-requests
        [HttpPost]
        [ProducesResponseType(typeof(CardRequestDto),201)]
        [ProducesResponseType(typeof(CardRequestDto), 400)]
        [ProducesResponseType(typeof(CardRequestDto), 404)]
        [ProducesResponseType(typeof(CardRequestDto), 409)]
        [ProducesResponseType(typeof(CardRequestDto), 422)]
        public async Task<ActionResult<CardResponse<CardRequestDto>>> CreateCustomerCard([FromBody] CardRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var response = new CardResponse<CardRequestDto>();
            var newCard = new CardRequestDto();

            var card_type = _helper.ResolveCardType(request.card_type);
            var status = _helper.ResolveCardStatus(request.status);

            if (request.card_type == CardType.bank_card)
            {
                //validate visa card details
                if (!_helper.isCardValid(request.card_number!.Trim())) //check card number validation
                {
                    _logger.LogError($"Card Number: {request.card_number} should start with 4 and should have 16 digits");
                    response.status = HttpStatusCode.UnprocessableEntity;
                    response.message = $"Card Number: {request.card_number} should start with 4 and should have 16 digits";
                    return StatusCode(422, response);
                }

                if (!_helper.isCardSecurityCodeValid(request.security_code))
                {
                    _logger.LogError($"Card Security Code: {request.card_number} should have 3 digits");
                    response.status = HttpStatusCode.UnprocessableEntity;
                    response.message = $"Card Security Code: {request.card_number} should have 4 digits";
                    return StatusCode(422, response);
                }

                if (!_helper.isCardExpiryDateValid(request.expiry_date!.Trim()))
                {
                    _logger.LogError($"Card Expiry Date: {request.card_number} should be in format xx/xx");
                    response.status = HttpStatusCode.UnprocessableEntity;
                    response.message = $"Card Expiry Date: {request.card_number} should be in format xx/xx";
                    return StatusCode(422, response);
                }

                if (await _cardRepository.CheckIfCardHolderExists(request.card_holder.Trim()))
                {
                    _logger.LogError($"Card Holder: {request.card_holder} has an already existing card");
                    response.status = HttpStatusCode.Conflict;
                    response.message = $"Card Holder: {request.card_holder} has an already existing card";
                    return StatusCode(409, response);
                }

                if (await _cardRepository.CheckIfCardNumberExists(request.card_number.Trim()))
                {
                    _logger.LogError($"Card Number: {request.card_holder} is already registered");
                    response.status = HttpStatusCode.Conflict;
                    response.message = $"Card Number: {request.card_holder} is already registered";
                    return StatusCode(409, response);
                }

                newCard.card_description = request.card_description;
                newCard.card_holder = request.card_holder;
                newCard.card_number = request.card_number;
                newCard.card_number = request.card_number;
                newCard.security_code = request.security_code;
                newCard.expiry_date = request.expiry_date;
                newCard.bank_name = request.bank_name;


            }

            //validate mobile money
            if (request.card_type == CardType.mobile_money)
            {
                if (!_helper.IsPhoneValid(request.mobile_number)) //check card number validation
                {
                    _logger.LogError($"Wallet Number: {request.mobile_number} should start with 233 and should have 12 digits");
                    response.status = HttpStatusCode.UnprocessableEntity;
                    response.message = $"Wallet Number: {request.mobile_number} should start with 233 and should have 12 digits";
                    return StatusCode(422, response);
                }
                if (await _cardRepository.CheckIfMobileNumberExists(request.mobile_number))
                {
                    _logger.LogError($"Wallet Number: {request.mobile_number} is already registed/created");
                    response.status = HttpStatusCode.Conflict;
                    response.message = $"Wallet Number: {request.mobile_number} is already registed/created";
                    return StatusCode(409, response);
                }
                newCard.mobile_number = request.mobile_number;
                newCard.mobile_network = _helper.ResolveMobileNetwork(request.mobile_network);

            }
            newCard.status = status;
            newCard.card_type = card_type;
            newCard.customer_id = (Guid)request.customer_id;
            newCard.country = request.country;

            // save card
            var card = await _cardRepository.CreateCustomerCard(newCard);

            response.success = true;
            response.status = HttpStatusCode.Created;
            response.message = $"Customer Card: {card.id} created Successfully";
            response.data = card;

            return StatusCode(201, response);
        }

        [Route("{cardId}")]
        [HttpGet]
        public async Task<ActionResult<CardResponse<CardRequestDto>>> GetCustomerCard(Guid cardId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var response = new CardResponse<CardRequestDto>();
            var result = await _cardRepository.GetCustomerCard(cardId);
            if (result  == null)
            {
                _logger.LogError($"Customer Card with Id: {cardId} not found");
                response.success = false;
                response.status = HttpStatusCode.NotFound;
                response.message = $"Customer Card with Id: {cardId} not found";
                response.data = result;
                return StatusCode(404, response);
            }_logger.LogInformation($"Customer Card: {cardId}");

            response.success = true;
            response.status = HttpStatusCode.OK;
            response.message = $"Customer Card: {cardId}";
            response.data = result;
            return StatusCode(200, response);
        }

        [HttpGet]
        public async Task<ActionResult<CardResponseResult<CardRequestDto>>> GetCustomerCards()
        {
            var results = await _cardRepository.GetAllCards();

            var response = new CardResponseResult<CardRequestDto>()
            {
                success = true,
                status = HttpStatusCode.OK,
                data = results
            };
            return Ok(response);
        }
    }
}