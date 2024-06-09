using Dictionary.Classes;
using System.Collections.Generic;

namespace Dic.Classes
{
    public class Word
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int DictionaryId { get; set; }
        public virtual Dictionary Dictionary { get; set; }
        public virtual List<Translate> Translates { get; set; } = new List<Translate>();
    }
}
