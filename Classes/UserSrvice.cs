using Dic.Classes;
using System;
using System.Linq;
using static System.Collections.Specialized.BitVector32;

namespace Dictionary.Classes
{
    internal class UserSrvice : IUserService
    {
        public void ChoiceFunction()
        {
            Console.WriteLine();
            Console.WriteLine("\t*** My Dictionary ***");
            Console.WriteLine();
            ShowDictionaries();
            Console.WriteLine();
            Console.WriteLine("\tchoose an action:");
            Console.WriteLine("\t1. Create new dictionary");
            Console.WriteLine("\t2. remove the dictionary");
            Console.WriteLine("\t3. add word in dictionary");
            Console.WriteLine("\t4. remove word from dictionary");
            Console.WriteLine("\t5. add translate to word");
            Console.WriteLine("\t6. remove translate from word");
            Console.WriteLine("\t7. find the word in dictionary");
            Console.WriteLine("\t8. to leave 'My Dictionary'.");
            Console.WriteLine();
        }

        public string GetUserNumberDictionary()
        {
            return Console.ReadLine();
        }

        public string GetUserWord()
        {
            return Console.ReadLine();
        }

        public string GetUserTranslate()
        {
            return Console.ReadLine();
        }

        public string ActionsChoice()
        {
            return Console.ReadLine();
        }
        public void Action()
        {
            ChoiceFunction();
            DictionaryService service = new DictionaryService();
            string action;
            do
            {
                action = ActionsChoice();
                switch (action)
                {
                    case "1":
                        Console.Write("\r\tEnter the name of the dictionary you want to create: ");
                        string name = Console.ReadLine();
                        service.AddDictionary(name);
                        break;
                    case "2":
                        Console.WriteLine("\r\tEnter the name of the dictionary you want to remove. ");
                        string numDictionary = GetUserNumberDictionary();
                        string name1 = GetDictionariesName(numDictionary);
                        service.RemoveDictionary(name1);
                        break;
                    case "3":
                        Console.Write("\r\tEnter the number of the dictionary: ");
                        string num = GetUserNumberDictionary();
                        string nameDictionary = GetDictionariesName(num);
                        Console.Write("\r\tEnter the word you want to add: ");
                        string word = GetUserWord();
                        Console.Write("\r\tEnter the translate: ");
                        string trans = GetUserTranslate();
                        service.AddWord(nameDictionary, word, trans);
                        break;
                    case "4":
                        Console.Write("\r\tEnter the number of the dictionary: ");
                        string num1 = GetUserNumberDictionary();
                        string nameDictionary1 = GetDictionariesName(num1);
                        Console.Write("\r\tEnter the word you want to remove ");
                        string word1 = GetUserWord();
                        service.RemoveWord(nameDictionary1, word1);
                        break;
                    case "5":
                        Console.Write("\r\tEnter the number of the dictionary: ");
                        string num2 = GetUserNumberDictionary();
                        string nameDictionary2 = GetDictionariesName(num2);
                        Console.Write("\r\tEnter the word:");
                        string word2 = GetUserWord();
                        Console.Write("\r\tEnter the translate: ");
                        string trans2 = GetUserTranslate();
                        service.AddTranslate(nameDictionary2, word2, trans2);
                        break;
                    case "6":
                        Console.Write("\r\tEnter the number of the dictionary: ");
                        string num3 = GetUserNumberDictionary();
                        string nameDictionary3 = GetDictionariesName(num3);
                        Console.Write("\r\tEnter the word: ");
                        string word3 = GetUserWord();
                        Console.Write("\r\tEnter the translate: ");
                        string trans3 = GetUserTranslate();
                        service.RemoveTranslate(nameDictionary3, word3, trans3);
                        break;
                    case "7":
                        Console.Write("\r\tEnter the number of the dictionary: ");
                        string num4 = GetUserNumberDictionary();
                        string nameDictionary4 = GetDictionariesName(num4);
                        Console.Write("\r\tEnter the word: ");
                        string word4 = GetUserWord();
                        service.FindWord(nameDictionary4, word4);
                        break;
                    default:
                        Console.Write("Invalid action. Please try again.");
                        break;
                }
            } while (action != "8");
        }


        public void ShowDictionaries()
        {
            using (DictionariesContext dc = new DictionariesContext())
            {
                int count = 1;
                var dictionaries = dc.Dictionaries.ToList();
                foreach (var dictionary in dictionaries)
                {
                    Console.WriteLine($"\t\t{count}. {dictionary.Name}");
                    count++;
                }
            }
        }

        public string GetDictionariesName(string numberDictionary)
        {
            using (DictionariesContext dc = new DictionariesContext())
            {
                var names = dc.Dictionaries.Select(d => d.Name).ToList();

                if (!int.TryParse(numberDictionary, out int parsedNumber))
                {
                    throw new ArgumentException("Invalid number format.");
                }

                if (parsedNumber <= 0 || parsedNumber > names.Count)
                {
                    throw new ArgumentOutOfRangeException($"The number {numberDictionary} does not correspond to any dictionary.");
                }

                return names[parsedNumber-1];
            }
        }


    }
}
