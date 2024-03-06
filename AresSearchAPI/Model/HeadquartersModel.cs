using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AresSearchAPI.Model
{
    public class HeadquartersModel
    {
        public int Id { get; set; }
        [JsonPropertyName("kodStatu")]
        public string? StateCode { get; set; }
        [JsonPropertyName("nazevStatu")]
        public string? StateName { get; set; }
        [JsonPropertyName("kodKraje")]
        public int RegionCode { get; set; }
        [JsonPropertyName("nazevKraje")]
        public string? RegionName { set; get; }
        [JsonPropertyName("kodOkresu")]
        public int DistrictCode { get; set; }
        [JsonPropertyName("kodObce")]
        public int TownCode { get; set; }
        [JsonPropertyName("nazevObce")]
        public string? TownName { set; get; }
        [JsonPropertyName("kodMestskehoObvodu")]
        public int CityDistrictCode { get; set; }
        [JsonPropertyName("nazevMestskehoObvodu")]
        public string? CityDistrictName { get; set; }
        [JsonPropertyName("kodMestskeCastiObvodu")]
        public int CityDistrictPartCode { get; set; }
        [JsonPropertyName("kodUlice")]
        public int StreetCode { get; set; }
        [JsonPropertyName("nazevMestskeCastiObvodu")]
        public string? CityDistrictPartName { set; get; }
        [JsonPropertyName("nazevUlice")]
        public string? StreetName { set; get; }
        [JsonPropertyName("cisloDomovni")]
        public int HouseNumber { get; set; }
        [JsonPropertyName("kodCastiObce")]
        public int TownPartCode { get; set; }
        [JsonPropertyName("cisloOrientacni")]
        public int ReferenceNumber { get; set; }
        [JsonPropertyName("nazevCastiObce")]
        public string? TownPartName { set; get; }
        [JsonPropertyName("kodAdresnihoMista")]
        public int AddressLocationCode { get; set; }
        [JsonPropertyName("psc")]
        public int ZipCode { get; set; }
        [JsonPropertyName("textovaAdresa")]
        public string? TextAddress { get; set; }
    }
}
