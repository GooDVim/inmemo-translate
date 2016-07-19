using System.Collections.Generic;
using System.Threading.Tasks;
using Inmemo.Translate.Models;
using Inmemo.Translate.Services;
using Inmemo.Translate.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Inmemo.Translate.Controllers
{
    [Route("[action]")]
    public class DictionaryController : Controller
    {
        private IDictionary _dictionary;
        public DictionaryController(IDictionary dictionary)
        {
            _dictionary = dictionary;
        }
        public async Task<IActionResult> Lookup(LookupInput input)
        {
            var result = await _dictionary.LookupAsync(input);
            return Json(result);
        }
    }
}
