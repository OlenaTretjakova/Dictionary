using Dictionary.Classes;
using System.Data.Entity;

namespace Dic.Classes
{
    public class DictionariesContext : DbContext
    {
        public DictionariesContext() : base("MyDictionaryDb"){ }
        public DbSet<Word> Words { get; set; }
        public DbSet<Dictionary> Dictionaries { get; set; }
        public DbSet<Translate> Translates { get; set; }

    }
}
