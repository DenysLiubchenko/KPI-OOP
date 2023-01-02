using System.Text.Json;
using Lab3.Model;

namespace Lab3
{
    internal class Serializer
    {
        public void Serialize(string fileName, object objectToSerialize)
        {
            File.WriteAllText(fileName, JsonSerializer.Serialize(objectToSerialize));
        }
        public DataBase Deserialize(string fileName)
        {
            string jsonString = File.ReadAllText(fileName);
            try
            {
                return JsonSerializer.Deserialize<DataBase>(jsonString);
            }
            catch { return new DataBase(); }
        }
    }
}
