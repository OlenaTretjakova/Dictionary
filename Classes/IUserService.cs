namespace Dictionary.Classes
{
    public interface IUserService
    {
        void ChoiceFunction();
        void ShowDictionaries();
        string GetDictionariesName(string numberDictionary);
        string GetUserNumberDictionary();
        string ActionsChoice();
        string GetUserWord();
        string GetUserTranslate();

    }

}
