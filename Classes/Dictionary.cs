using System.Collections.Generic;

namespace Dic.Classes
{
    public class Dictionary
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<Word> Words { get; set; } = new List<Word>();
    }
}
