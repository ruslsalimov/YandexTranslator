using Newtonsoft.Json;

namespace YandexTranslator.JsonClasses
{
    class SourceLanguage
    {
        [JsonProperty("code")]
        public long Code { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }
    }
}
