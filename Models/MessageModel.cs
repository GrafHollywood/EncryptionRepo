using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace WebEncryption.Models
{
    public class MessageModel
    {
        private const string alphabet = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
        /*private string key;
        public string Key
        {
            get { return key; }
            set { key = value.ToUpper(); }
        }
        public string Message { get; set; }
        public string Path { get; set; }*/

        private static string GetRepeatKey(string key, string message)
        {
            int k = 0;
            string repeatKey = string.Empty;
            for (int i = 0; i < message.Length; i++)
            {
                if (alphabet.Contains(message.ToUpper()[i]))
                {
                    repeatKey += key[k];
                    k++;
                    if (k == key.Length)
                        k = 0;
                }
                else
                    repeatKey += message[i];
            }
            return repeatKey;
        }
        private static string Vigenere(string message, string key, bool isEncrypt)
        {
            key = key.ToUpper();
            string keyRepeat = GetRepeatKey(key, message);
            string result = string.Empty;

            for (int i = 0; i < message.Length; i++)
            {
                int letterId = alphabet.IndexOf(message.ToUpper()[i]);
                int keyId = alphabet.IndexOf(keyRepeat[i]);
                if (letterId < 0)
                {
                    result += message[i];
                }
                else
                {
                    char letter = alphabet[(alphabet.Length + letterId + (isEncrypt ? 1 : -1) * keyId) % alphabet.Length];
                    result += char.IsUpper(message[i]) ? letter.ToString() : letter.ToString().ToLower();
                }
            }
            return result;
        }
        private static List<string> Caesar(string message, bool isEncrypt)
        {
            List<string> result = new List<string>();
            for (int i = 0; i < alphabet.Length; i++)
            {
                result.Add(string.Empty);
                for (int j = 0; j < message.Length; j++)
                {
                    int letterId = alphabet.IndexOf(message.ToUpper()[j]);
                    if (letterId < 0)
                    {
                        result[i] += message[j];
                    }
                    else
                    {
                        char letter = alphabet[(alphabet.Length + letterId + (isEncrypt ? 1 : -1) * i) % alphabet.Length];
                        result[i] += char.IsUpper(message[j]) ? letter.ToString() : letter.ToString().ToLower();
                    }
                }
            }
            return result;
        }
        public static string VigenereEncrypt(string message, string key) => Vigenere(message, key, true);
        public static string VigenereDecrypt(string message, string key) => Vigenere(message, key, false);
        public static List<string> CaesarEncrypt(string message) => Caesar(message, true);
        public static List<string> CaesarDecrypt(string message) => Caesar(message, false);

    }
}
