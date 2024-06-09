using Dictionary.Classes;
using System;
using System.Linq;

namespace Dic.Classes
{
    public class DictionaryService : IDictionaryService
    {
        public void AddDictionary(string name)
        {
            using (DictionariesContext db = new DictionariesContext())
            {
                if (!db.Dictionaries.Any(dictionary => dictionary.Name == name))
                {
                    Dictionary dictionary = new Dictionary();
                    dictionary.Name = name;

                    db.Dictionaries.Add(dictionary);
                    db.SaveChanges();

                    Console.WriteLine($"\tThe '{name}' dictionary has been created.");
                }
                else
                {
                    Console.WriteLine($"\tThe '{name}' dictionary already exists.");
                }
            }

        }

        public void AddTranslate(string dicName, string word, string wordTranslate)
        {
            using (DictionariesContext db = new DictionariesContext())
            {
                var searchDic = db.Dictionaries.FirstOrDefault(d => d.Name == dicName);
                if (searchDic == null)
                {
                    Console.WriteLine($"\tThe dictionary '{dicName}' was not found.");
                    return;
                }

                var searchWord = db.Words.FirstOrDefault(w => w.Text == word && w.DictionaryId == searchDic.Id);
                if (searchWord == null)
                {
                    Console.WriteLine($"\tThe word '{word}' was not found in dictionary '{dicName}'.");
                    return;
                }

                if (db.Translates.Any(t => t.Text == wordTranslate && t.WordId == searchWord.Id))
                {
                    Console.WriteLine($"\tThe word-translate '{wordTranslate}' already exists.");
                    return;
                }

                Translate insertTrans = new Translate
                {
                    Text = wordTranslate,
                    WordId = searchWord.Id
                };
                db.Translates.Add(insertTrans);
                db.SaveChanges();
                Console.WriteLine($"\tThe word-translate '{wordTranslate}' was added to word '{word}'.");
            }
        }

        public void AddWord(string dicName, string word, string translate)
        {
            using (DictionariesContext db = new DictionariesContext())
            {
                var dic = db.Dictionaries
                .Include("Words")
                .FirstOrDefault(d => d.Name == dicName);
                if (dic == null)
                    if (dic == null)
                    {
                        Console.WriteLine($"\tThe dictionary '{dicName}' was not found.");
                        return;
                    }

                if (db.Words.Any(w => w.Text == word && w.DictionaryId == dic.Id))
                {
                    Console.WriteLine($"\tThe word '{word}' already exists.");
                    return;
                }

                Word wordNew = new Word
                {
                    Text = word,
                    DictionaryId = dic.Id,
                };
                db.Words.Add(wordNew);
                db.SaveChanges();

                AddTranslate(dicName, word, translate);

                Console.WriteLine($"\tThe word '{word}' with translate '{translate}' was added to dictionary '{dicName}'.");
            }
        }

        public void RemoveDictionary(string name)
        {
            using (DictionariesContext dc = new DictionariesContext())
            {
                Dictionary searchDicToRemove = dc.Dictionaries
                                      .Where(d => d.Name == name)
                                      .FirstOrDefault();

                if (searchDicToRemove != null)
                {
                    dc.Dictionaries.Remove(searchDicToRemove);
                    dc.SaveChanges();

                    var searchWordsToRemove = dc.Words.Where(w => w.DictionaryId == searchDicToRemove.Id);

                    if (searchWordsToRemove != null)
                    {
                        foreach (var wordToRemove in searchWordsToRemove)
                        {
                            dc.Words.Remove(wordToRemove);
                            dc.SaveChanges();

                            var searchTrans = dc.Translates.Where(t => t.WordId == wordToRemove.Id);
                            foreach (var translation in searchTrans)
                            {
                                dc.Translates.Remove(translation);
                                dc.SaveChanges();
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine($"\tThe dictionary with name '{name}'does not exist.");
                    return;
                }

                Console.WriteLine($"\tThe dictionary '{name}' has been removed.");
                return;
            }
        }

        public void RemoveTranslate(string dictionaryName, string word, string wordTranslate)
        {
            using (DictionariesContext dc = new DictionariesContext())
            {
                var givenDictionary = dc.Dictionaries.FirstOrDefault(d => d.Name == dictionaryName);
                if (givenDictionary == null)
                {
                    Console.WriteLine($"\tThe dictionary with name '{dictionaryName}' was not found.");
                    return;
                }

                var givenWord = dc.Words.FirstOrDefault(w => w.Text == word && w.DictionaryId == givenDictionary.Id);
                if (givenWord == null)
                {
                    Console.WriteLine($"The word '{word}' was not found in the dictionary '{dictionaryName}'.");
                    return;
                }

                var givenTranslate = dc.Translates.FirstOrDefault(t => t.Text == wordTranslate && t.WordId == givenWord.Id);
                if (givenTranslate == null)
                {
                    Console.WriteLine($"\tThe translate '{wordTranslate}' of the word '{word} was not found in the dictionary with name '{dictionaryName}'.");
                    return;
                }

                dc.Translates.Remove(givenTranslate);
                dc.SaveChanges();

                Console.WriteLine($"\tThe translate '{wordTranslate}' of the word '{word}' was removed in the dictionary with name '{dictionaryName}'.");
                return;
            }

        }

        public void RemoveWord(string dictionaryName, string word)
        {
            using (DictionariesContext dc = new DictionariesContext())
            {
                var givenDictionary = dc.Dictionaries.FirstOrDefault(d => d.Name == dictionaryName);
                if (givenDictionary == null)
                {
                    Console.WriteLine($"\tThe dictionary with name '{dictionaryName}' was not found.");
                    return;
                }

                var givenWord = dc.Words.FirstOrDefault(w => w.Text == word && w.DictionaryId == givenDictionary.Id);
                if (givenWord == null)
                {
                    Console.WriteLine($"The word '{word} was not found in the dictionary with name '{dictionaryName}'.");
                    return;
                }

                dc.Words.Remove(givenWord);
                dc.SaveChanges();

                var translatesCurrentWord = dc.Translates.Where(t => t.WordId == givenWord.Id).ToList();
                foreach (var translate in translatesCurrentWord)
                {
                    dc.Translates.Remove(translate);
                    dc.SaveChanges();
                }
                Console.WriteLine($"\tThe word '{word}' and its translation was removed from dictionary '{dictionaryName}'.");
            }
        }
        public void FindWord(string dictionaryName, string word)
        {
            using(DictionariesContext dc = new DictionariesContext())
            {
                var searchDictionary = dc.Dictionaries.FirstOrDefault(t => t.Name == dictionaryName);
                if(searchDictionary == null)
                {
                    Console.WriteLine($"\tThe dictionary with name '{dictionaryName}' was not found.");
                    return;
                }

                var searchWord = dc.Words.FirstOrDefault(w => w.Text == word && w.DictionaryId == searchDictionary.Id);
                if (searchWord == null)
                {
                    Console.WriteLine($"\tThe word '{word}' was not found in the dictionary with name '{dictionaryName}'.");
                    return;
                }
                var searchTranslations = dc.Translates.Where(t => t.WordId == searchWord.Id).Select(t => t.Text).ToList();

                string translations = string.Join(", ", searchTranslations);
                Console.WriteLine($"\t{searchWord.Text} : {translations}. ");

            }

            
        }

        
    }
}
