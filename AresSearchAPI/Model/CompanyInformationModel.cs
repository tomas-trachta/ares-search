using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AresSearchAPI.Model
{
    public class CompanyInformationModel
    {
        public int Id { get; set; }
        [JsonPropertyName("ico")]
        public string? CIN { get; set; }
        [JsonPropertyName("obchodniJmeno")]
        public string? BusinessName { get; set; }
        [JsonPropertyName("sidlo")]
        public HeadquartersModel? Headquarters { get; set; }
        [JsonPropertyName("datumVzniku")]
        public string? CreationDate { get; set; }
        [JsonPropertyName("dic")]
        public string? VatId { get; set; }
        [JsonPropertyName("adresaDorucovaci")]
        public MailingAddressModel? MailingAddress { get; set; }
    }
}
