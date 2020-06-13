using Newtonsoft.Json;

namespace YandexTranslator.JsonClasses
{
    class TextTranslate
    {
        [JsonProperty("code")]
        public int Code { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("text")]
        public string[] Text { get; set; }
    }
}
