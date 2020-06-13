using System;
using System.IO;
using System.Net;
using System.Linq;
using Newtonsoft.Json;
using System.Collections.Generic;
using YandexTranslator.JsonClasses;

namespace YandexTranslator
{
    public class Translator
    {
        private string url;
        public Translator(string key)
        {
            AppCache.Key = key;
        }
  
        public string TranslateText(string text, string langToTranslate)
        {
            url = string.Format(AppCache.UrlTranslate, AppCache.Key, text, langToTranslate);
            TextTranslate translate = GetObjectFromAPI<TextTranslate>(url);

            if (translate.Code.Equals(200))
                return translate.Text.FirstOrDefault();
            else
                throw new Exception($"Status code: {translate.Code}");
        }

        public Dictionary<string, string> GetLangs(string language = "en")
        {
            url = string.Format(AppCache.UrlGetAvailableLanguages, AppCache.Key, language);
            SupportedLanguages supportedLanguages = GetObjectFromAPI<SupportedLanguages>(url);
            return supportedLanguages.Langs;
        }

        public string GetSrcLang(string text)
        {
            url = string.Format(AppCache.UrlDetectSourceLanguage, AppCache.Key, text);
            SourceLanguage translate = GetObjectFromAPI<SourceLanguage>(url);

            if (translate.Code.Equals(200))
                return translate.Lang;
            else
                throw new Exception($"Status code: {translate.Code}");
        }
        public string GetSrcLang(string text, string language)
        {
            Dictionary<string, string> langs = GetLangs(language);
            return langs[GetSrcLang(text)];
        }

        private T GetObjectFromAPI<T>(string url)
        {
            string json;
            T resultClass;
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                httpWebRequest.ContentType = "text/json"; httpWebRequest.Method = "POST";

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    json = streamReader.ReadToEnd();
                }
                resultClass = JsonConvert.DeserializeObject<T>(json);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return resultClass;
        }
    }



}
