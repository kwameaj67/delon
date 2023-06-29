using System.ComponentModel.DataAnnotations;

namespace DelonLLC.Model
{
    public class CardRequest
    {
        public Guid id { get; set; }
        [Required]
        public Guid? customer_id { get; set; }
        public CardStatus status { get; set;}
        [Required]
        public CardType card_type { get; set;}
        public string? card_number { get; set; } = null;
        public string? card_description { get; set; } = null;
        public string? card_holder { get; set; } = null;
        public int? security_code { get; set; } 
        public string? expiry_date { get; set; } = null;
        public MobileNetwork? mobile_network { get; set; }
        public string? mobile_number { get; set; }
        public string? bank_name { get; set; } = null;
        public string country { get; set; }
        public DateTimeOffset? created_at { get; set; }
        public DateTimeOffset? updated_at { get; set; }
    }

    public enum CardType
    {
        bank_card,
        mobile_money
    }

    public enum CardStatus
    {
        active,
        inactive,
        blocked
    }
    public enum MobileNetwork
    {
        mtn,
        vodaphone,
        airtel,
        none,
    }
}
