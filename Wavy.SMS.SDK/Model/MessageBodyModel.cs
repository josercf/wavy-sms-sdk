using System.Text.Json.Serialization;

namespace Wavy.SMS.SDK.Model
{
    internal struct MessageBodyModel
    {
        public MessageBodyModel(string to, string messgeText)
        {
            if (to.Length == 11)
                To = $"55{to}";
            else
                To = to;
            MessgeText = messgeText;
        }

        [JsonPropertyName("destination")]
        public string To { get; }

        [JsonPropertyName("messageText")]
        public string MessgeText { get; }
    }
}
