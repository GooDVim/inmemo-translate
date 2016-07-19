namespace Inmemo.Translate.Models
{
    public class LookupInput
    {
        public string Word { get; set; }
        public PartOfSpeech PartOfSpeech { get; set; }
        public string TranslationDirection { get; set; }
    }
}
