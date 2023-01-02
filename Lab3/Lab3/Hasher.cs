using System.Text;
using XSystem.Security.Cryptography;

namespace Lab3
{
    internal class Hasher
    {
        public string CalculateHashCode(string data)
        {
            byte[] tmpData = Encoding.ASCII.GetBytes(data);
            byte[] tmpHash = new MD5CryptoServiceProvider().ComputeHash(tmpData);
            return ByteArrayToString(tmpHash);
        }
        private string ByteArrayToString(byte[] input)
        {
            StringBuilder output = new StringBuilder(input.Length);
            for (int i = 0; i < input.Length - 1; i++)
            {
                output.Append(input[i].ToString("X2"));
            }
            return output.ToString();
        }
    }
}
