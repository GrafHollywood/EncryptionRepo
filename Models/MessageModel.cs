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
        private string key;
        public string Key
        {
            get { return key; }
            set { key = value.ToUpper(); }
        }
        public string Message { get; set; }
        public string Path { get; set; }

        private string GetRepeatKey()
        {
            int k = 0;
            string repeatKey = string.Empty;
            for (int i = 0; i < Message.Length; i++)
            {
                if (alphabet.Contains(Message.ToUpper()[i]))
                {
                    repeatKey += Key[k];
                    k++;
                    if (k == Key.Length)
                        k = 0;
                }
                else
                    repeatKey += Message[i];
            }
            return repeatKey;
        }
        private void Vigenere(bool isEncrypt)
        {
            string keyRepeat = GetRepeatKey();
            string result = string.Empty;

            for (int i = 0; i < Message.Length; i++)
            {
                int letterId = alphabet.IndexOf(Message.ToUpper()[i]);
                int keyId = alphabet.IndexOf(keyRepeat[i]);
                if (letterId < 0)
                {
                    result += Message[i];
                }
                else
                {
                    char letter = alphabet[(alphabet.Length + letterId + (isEncrypt ? 1 : -1) * keyId) % alphabet.Length];
                    result += char.IsUpper(Message[i]) ? letter.ToString() : letter.ToString().ToLower();
                }
            }
            Message = result;
        }
        public void VigenereEncrypt() => Vigenere(true);
        public void VigenereDecrypt() => Vigenere(false);
    }
}
