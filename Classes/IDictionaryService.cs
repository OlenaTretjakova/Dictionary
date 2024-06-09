namespace Dic.Classes
{
    public interface IDictionaryService
    {
        void AddDictionary(string name);
        void RemoveDictionary(string name);
        void AddWord(string word, string translate, string dicName);
        void RemoveWord(string dictionary, string word);
        void AddTranslate(string wordTranslate, string word, string dicName);
        void RemoveTranslate(string dictionaryName, string word, string wordTranslate);
        void FindWord(string dictionaryName, string word);

    }
}
