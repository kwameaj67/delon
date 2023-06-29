using DelonLLC.Model;
using System.Text.RegularExpressions;

namespace DelonLLC.Functions
{
    public interface IHelperFunctions
    {
        bool isCardValid(string card_number);
        bool isCardSecurityCodeValid(int? security_code);
        bool isCardExpiryDateValid(string card_expiry_date);
        bool IsPhoneValid(string phone_number);
        CardStatus ResolveCardStatus(string userStatus);
        string ResolveCardStatus(CardStatus status);
        CardType ResolveCardType(string type);
        string ResolveCardType(CardType type);
        string ResolveMobileNetwork(MobileNetwork? network);

    }
    public class HelperFunctions:IHelperFunctions
    {
        public CardStatus ResolveCardStatus(string userStatus)
        {
            switch (userStatus.ToLower())
            {
                case "inactive":
                    return CardStatus.inactive;
                case "active":
                    return CardStatus.active;
                case "blocked":
                    return CardStatus.blocked;
                default:
                    return CardStatus.inactive;
            }
        }
        public string ResolveCardStatus(CardStatus status)
        {
            switch (status)
            {
                case CardStatus.active:
                    return "active";
                case CardStatus.inactive:
                    return "inactive";
                case CardStatus.blocked:
                    return "blocked";
                default:
                    return "active";
            }
        }

        public CardType ResolveCardType(string type)
        {
            switch (type.ToLower())
            {
                case "bank_card":
                    return CardType.bank_card;
                case "mobile_money":
                    return CardType.mobile_money;
                default:
                    return CardType.mobile_money;
            }
        }

        public string ResolveCardType(CardType type)
        {
            switch (type)
            {
                case CardType.bank_card:
                    return "bank_card";
                case CardType.mobile_money:
                    return "mobile_money";
                default:
                    throw new Exception("Unknown type");
            }
        }

        public string ResolveMobileNetwork(MobileNetwork? network)
        {
            switch (network)
            {
                case MobileNetwork.mtn:
                    return "mtn";
                case MobileNetwork.airtel:
                    return "airtel";
                case MobileNetwork.vodaphone:
                    return "vodaphone";
                default:
                    throw new Exception("Unknown network");
            }
        }

        public bool isCardValid(string card_number)
        {
            Regex rgx = new Regex(@"^4[0-9]{15}$"); //visa card number pattern(starts with 4 and has 16 digits)
            var isValid = rgx.IsMatch(card_number);
            return isValid;
        }

        public bool isCardSecurityCodeValid(int? security_code)
        {
            Regex rgx = new Regex(@"[0-9]{3}$"); //code pattern(has 3 digits)
            var isValid = rgx.IsMatch(security_code.ToString());
            return isValid;
        }

        public bool IsPhoneValid(string phone_number)
        {
            Regex rgx = new Regex(@"^\d{12}$");
            var isValid = rgx.IsMatch(phone_number);
            return isValid;
        }

        public bool isCardExpiryDateValid(string card_expiry_date)
        {
            Regex rgx = new Regex(@"^\d{2}\/\d{2}$");
            var isValid = rgx.IsMatch(card_expiry_date);
            return isValid;
        }
    }
}
