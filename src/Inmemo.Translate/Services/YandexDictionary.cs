using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Inmemo.Translate.Models;
using Inmemo.Translate.Options;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Inmemo.Translate.Services
{
    public class YandexDictionary : IDictionary
    {
        private readonly YandexOptions _yandexOptions;

        public YandexDictionary(IOptions<YandexOptions> yandexOptions)
        {
            _yandexOptions = yandexOptions.Value;
        }

        public async Task<LookupOutput> LookupAsync(LookupInput input)
        {
            var client = new HttpClient();
            var url = $"https://dictionary.yandex.net/api/v1/dicservice.json/lookup?key={_yandexOptions.YandexApiKey}&lang={input.TranslationDirection}&text={input.Word}";
            var response = await client.GetAsync(url);
            var jsonString = await response.Content.ReadAsStringAsync();
            var obj = JsonConvert.DeserializeObject<YandexLookupOutput>(jsonString);
            var partOfSpeechIsFound = true;
            List<Translation> translations =
                obj.def.Where(d => string.Compare(d.pos, input.PartOfSpeech.ToString(), StringComparison.OrdinalIgnoreCase) == 0)
                    .SelectMany(d => d.tr.Select(t => new Translation {Word = t.text, PartOfSpeech = t.pos})).ToList();
            if (translations.Count == 0)
            {
                partOfSpeechIsFound = false;
                translations = obj.def.SelectMany(d => d.tr.Select(t => new Translation {Word = t.text, PartOfSpeech = t.pos})).ToList();
            }
            return new LookupOutput
                   {
                       PartOfSpeechIsFound = partOfSpeechIsFound,
                       Translations = translations
                   };
        }
    }
}
