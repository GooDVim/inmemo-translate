using System.Collections.Generic;

namespace Inmemo.Translate.Models
{
    public class Head
    {
    }

    public class Syn
    {
        public string text { get; set; }
        public string pos { get; set; }
        public string gen { get; set; }
    }

    public class Mean
    {
        public string text { get; set; }
    }

    public class Tr2
    {
        public string text { get; set; }
    }

    public class Ex
    {
        public string text { get; set; }
        public List<Tr2> tr { get; set; }
    }

    public class Tr
    {
        public string text { get; set; }
        public string pos { get; set; }
        public string gen { get; set; }
        public List<Syn> syn { get; set; }
        public List<Mean> mean { get; set; }
        public List<Ex> ex { get; set; }
        public string asp { get; set; }
    }

    public class Def
    {
        public string text { get; set; }
        public string pos { get; set; }
        public string ts { get; set; }
        public List<Tr> tr { get; set; }
    }

    public class YandexLookupOutput
    {
        public Head head { get; set; }
        public List<Def> def { get; set; }
    }

}