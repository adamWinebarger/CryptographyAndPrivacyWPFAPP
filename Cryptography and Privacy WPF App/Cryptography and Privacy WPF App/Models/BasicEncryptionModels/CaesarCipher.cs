using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptography_and_Privacy_WPF_App
{
    class CaesarCipher
    {

        public string encrypt(string text, int s = 0)
        {

            string result = "";

            for (int i = 0; i < text.Length; i++)
            {
                if (char.IsUpper(text[i]))
                {
                    char c = (char)(((int)text[i] + s - 65) % 26 + 65);
                    result += c;
                }
                else if (char.IsLower(text[i]))
                {
                    char c = (char)(((int)text[i] + s - 97) % 26 + 97);
                    result += c;
                }
                else
                    result += text[i];
            }

            return result;
        }

    }
}
