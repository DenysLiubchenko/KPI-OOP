using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using Lab3.Model;

namespace Lab3
{
    internal class Serializer
    {
        public static void Serialize(string fileName, object o)
        {
            string jsonString = JsonSerializer.Serialize(o);
            File.WriteAllText(fileName, jsonString);
        }
        public static DataBase Deserialize(string fileName)
        {
            string jsonString = File.ReadAllText(fileName);
            try
            {
                var tObject = JsonSerializer.Deserialize<DataBase>(jsonString);
                return tObject;
            }
            catch { return new DataBase(); }
        }
    }
}
