using Dic.Classes;
using Dictionary.Classes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Dic
{
    internal class Program
    {
        static void Main(string[] args)
        {
          //using(DictionariesContext dc = new DictionariesContext())
          //{
          //   var w = dc.Translates.First(s => s.Text == "Beautiful" && s.WordId == 2);
          //    dc.Translates.Remove(w);
          //    dc.SaveChanges();
          //}
            //DictionaryService service = new DictionaryService();
            //service.AddDictionary("English-Ukrainian");
            //service.AddDictionary("Українсько-Німецкий");
            //service.AddDictionary("Українсько-Англійський");
            // 
            // 
            //service.AddWord("українсько-англійський","червоний", "red");
            //service.AddWord("English-Ukrainian", "red", "червоний");
            //service.AddTranslate("українсько-англійський", "гарний", "pretty");
            //service.RemoveDictionary("English-Ukrainian");
            //service.RemoveWord("українсько-англійський", "гарний");
            //UserSrvice userSrvice1 = new UserSrvice();
            //userSrvice1.ShowDictionaries();
            //userSrvice1.ChoiceFunction();
            //service.FindWord("українсько-англійський", "червоний")
            UserSrvice user = new UserSrvice();
            user.Action();

            Console.ReadLine();
        }
    }
}
