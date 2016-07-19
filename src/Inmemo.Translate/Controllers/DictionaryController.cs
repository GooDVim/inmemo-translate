using System.Collections.Generic;
using Inmemo.Translate.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Inmemo.Translate.Controllers
{
    [Route("[action]")]
    public class DictionaryController : Controller
    {
        public IActionResult Lookup(LookupViewModel input)
        {
            var example = new List<string> { "время", "час", "эпоха" };
            return Json(example);
        }
    }
}
