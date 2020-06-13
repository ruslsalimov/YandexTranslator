using Newtonsoft.Json;
using System.Collections.Generic;

namespace YandexTranslator.JsonClasses
{
    class SupportedLanguages
    {
        [JsonProperty("dirs")]
        public string[] Dirs { get; set; }

        [JsonProperty("langs")]
        public Dictionary<string, string> Langs { get; set; }
    }
}
