using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AresSearchAPI.Model
{
    public class MailingAddressModel
    {
        public int Id { get; set; }
        [JsonPropertyName("radekAdresy1")]
        public string? AddressLine1 { get; set; }
        [JsonPropertyName("radekAdresy2")]
        public string? AddressLine2 { get; set; }
        [JsonPropertyName("radekAdresy3")]
        public string? AddressLine3 { get; set; }
    }
}
