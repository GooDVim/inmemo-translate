using Inmemo.Translate.Models;

namespace Inmemo.Translate.ViewModels
{
    public class LookupViewModel
    {
        public string Word { get; set; }
        public PartOfSpeech POS { get; set; }
        public string Lang { get; set; }
    }
}