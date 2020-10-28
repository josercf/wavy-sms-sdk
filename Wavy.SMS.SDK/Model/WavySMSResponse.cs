using System;
using System.Text.Json.Serialization;

namespace Wavy.SMS.SDK.Model
{
    internal struct WavySMSResponse
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }
    }
}
