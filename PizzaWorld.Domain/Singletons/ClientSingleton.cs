using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using PizzaWorld.Domain.Models;

namespace PizzaWorld.Domain.Singletons
{

    public class ClientSingleton
    {
        private const string _path = @"./pizzaworld.xml"; //Field - @ means take the / literally. Dont convert /s into a space, /t into a tab, etc. --literal operator
        private static ClientSingleton _instance;
        public static ClientSingleton Instance 
        { 
            get
            {
                if(_instance == null)
                {
                    _instance = new ClientSingleton();
                }

                return _instance;
            }
        }

        public List<Store> Stores { get; set; }

        private ClientSingleton() 
        {
            Load();
        }

        public void MakeStore()
        {
            Stores.Add(new Store());
            Save();
        }

        // public bool TryParse2(string y, out int x) //this is what tryparse does behind the scenes
        // {
        //     x = 0;

        //     try
        //     {
        //         x = int.Parse(y);

        //         return true;
        //     }
        //     catch
        //     {
        //         return false;
        //     }
        // }

        public Store SelectStore()
        {
            int.TryParse(Console.ReadLine(), out int input);  //parsing because int and string are value types

            //Stores.FirstOrDefault(s => s == input); //unique property, customer entered the right value.

            return Stores.ElementAtOrDefault(input); //will throw an exception if empty

            //var selection = Stores[input]; //would throw an exception if empty

        }

        private void Save()
        {
            var file = new StreamWriter(_path);
            var xml = new XmlSerializer(typeof(List<Store>));

            xml.Serialize(file, Stores);
        }

        private void Load()
        {
            if(File.Exists(_path))
            {
                var xml = new XmlSerializer(typeof(List<Store>));

                var file = new StreamReader(_path);

                //Stores = (List<Store>)xml.Deserialize(file); //exception if cannot convert
                Stores = xml.Deserialize(file) as List<Store>; //null if cannont convert
            }
            else
            {
                Stores = new List<Store>();
            }
            
        }
    }
}

