namespace YandexTranslator
{
    static class AppCache
    {
        /* 
         * Free API key from https://translate.yandex.com/developers/keys
         */
        public static string Key { get; set; }
        /*
         * Gets a list of translation directions supported by the service.
         * 
         * Request example:
         * https://translate.yandex.net/api/v1.5/tr.json/getLangs?key=ApiKey&ui={en}
         * 
         * Response example:
         * {
         *      "dirs": [
         *          "ru-en",
         *          "ru-pl",
         *          "ru-hu",
         *          ...
         *      ],
         *     "langs": {
         *          "ru": "Russian",
         *          "en": "English",
         *          "pl": "Polish",
         *          ...
         *      }
         *  } 
         */
        public static string UrlGetAvailableLanguages { get; } 
            = "https://translate.yandex.net/api/v1.5/tr.json/getLangs?key={0}&ui={1}";
        /*
         * Detects the language of the specified text.
         * 
         * Request example:
         * https://translate.yandex.net/api/v1.5/tr.json/detect?key=ApiKey&text=Hello world
         * 
         * Response example:
         * {
         *     "code": 200,
         *     "lang": "en"
         *  } 
         */
        public static string UrlDetectSourceLanguage { get; } 
            = "https://translate.yandex.net/api/v1.5/tr.json/detect?key={0}&text={1}";
        /*
         * Translates text to the specified language.
         * 
         * Request example:
         * https://translate.yandex.net/api/v1.5/tr.json/translate?key=ApiKey&text=Hello World&lang=ru
         * 
         * Response example: 
         * {
         *      "code": 200,
         *      "lang": "en-ru",
         *      "text": [
         *          "Привет Мир"
         *      ]
         *  }
         *  
         */
        public static string UrlTranslate { get; } 
            = "https://translate.yandex.net/api/v1.5/tr.json/translate?key={0}&text={1}&lang={2}";
    }
}
