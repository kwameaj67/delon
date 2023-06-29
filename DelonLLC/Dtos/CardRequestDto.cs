using DelonLLC.Model;
using System.ComponentModel.DataAnnotations;

namespace DelonLLC.Dtos
{
    public class CardRequestDto
    {
        public Guid id { get; set; }
        [Required]
        public Guid customer_id { get; set; }
        public string? status { get; set; }
        [Required]
        public string? card_type { get; set; }
        public string? card_number { get; set; } = null;
        public string? card_description { get; set; } = null;
        public string? card_holder { get; set; } = null;
        public int? security_code { get; set; }
        public string? expiry_date { get; set; } = null;
        public string? mobile_network { get; set; }
        public string? mobile_number { get; set; }
        public string? bank_name { get; set; } = null;
        public string country { get; set; }
        public DateTimeOffset? created_at { get; set; }
        public DateTimeOffset? updated_at { get; set; }
    }
}
