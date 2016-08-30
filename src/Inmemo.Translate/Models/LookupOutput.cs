using System.Collections.Generic;

namespace Inmemo.Translate.Models
{
    public class LookupOutput
    {
        public bool PartOfSpeechIsFound { get; set; }
        public List<Translation> Translations { get; set; }
    }
}