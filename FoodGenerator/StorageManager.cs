﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodGenerator
{
    public class StorageManager
    {
        private static Storage storage;
        const string storagePath = "storage.xml";

        public static Storage getStorage()
        {
            if (storage == null)
            {
                init();
            }

            if(storage == null)
            {
                throw new System.InvalidOperationException("Storage cant be iniialized");
            }

            return storage;
        }

        private static void init()
        {
          
                System.Xml.Serialization.XmlSerializer reader =
       new System.Xml.Serialization.XmlSerializer(typeof(Storage));
                System.IO.StreamReader file = new System.IO.StreamReader(storagePath);
                StorageManager.storage = (Storage)reader.Deserialize(file);
                file.Close();
          
        }

        private static void createAndInit()
        {
            save();
            System.Xml.Serialization.XmlSerializer reader =
 new System.Xml.Serialization.XmlSerializer(typeof(Storage));
            System.IO.StreamReader file = new System.IO.StreamReader(storagePath);
            StorageManager.storage = (Storage)reader.Deserialize(file);
            file.Close();

        }
        public static void save()
        {

            System.Xml.Serialization.XmlSerializer writer =
                new System.Xml.Serialization.XmlSerializer(typeof(Storage));


            System.IO.FileStream file = System.IO.File.Create(storagePath);
            Storage saveStorage;
            if (storage == null)
            {
                saveStorage = new Storage();
            }
            else
            {
                saveStorage = storage;
            }

            writer.Serialize(file, saveStorage);
            file.Close();
        }



    }

}


