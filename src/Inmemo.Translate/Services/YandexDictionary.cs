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
        YandexOptions _yandexOptions;
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
            var result = new LookupOutput
            {
                Translations = obj.def.Where(d => string.Compare(d.pos, input.PartOfSpeech.ToString(), true) == 0).SelectMany(d => d.tr.Select(t=>t.text)).ToList()
            };
            return result;
        }
    }
}
