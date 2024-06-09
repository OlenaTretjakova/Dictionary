using Dic.Classes;

namespace Dictionary.Classes
{
    public class Translate
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int WordId { get; set; }
        public virtual Word Word { get; set; }
    }
}
