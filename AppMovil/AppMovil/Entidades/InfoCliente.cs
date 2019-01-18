using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace AppMovil.Entidades
{
    public class InfoCliente
    {
        [JsonProperty(PropertyName = "NombreCliente")]
        public string NombreCliente { get; set; }
        [JsonProperty(PropertyName = "Institucion")]
        public string Institucion { get; set; }
        [JsonProperty(PropertyName = "NumCreditos")]
        public int NumCreditos { get; set; }
        [JsonProperty(PropertyName = "NumAhorros")]
        public int NumAhorros { get; set; }
        [JsonProperty(PropertyName = "NumInversiones")]
        public int NumInversiones { get; set; }
        [JsonProperty(PropertyName = "Afiliacion")]
        public DateTime Afiliacion { get; set; }
        [JsonProperty(PropertyName = "Fidelidad")]
        public int Fidelidad { get; set; }
        [JsonProperty(PropertyName = "CatSugef")]
        public string CatSugef { get; set; }
        [JsonProperty(PropertyName = "Cph")]
        public int Cph { get; set; }
        [JsonProperty(PropertyName = "Cpc")]
        public int Cpc { get; set; }
        
    }
}
