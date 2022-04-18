using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptography_and_Privacy_WPF_App
{
    class Vigener
    {
        public Vigener()
        {

        }


        //This function generates the key in a cyclic manner until its length is equal to the original text
        public string generateKey(String str, String key)
        {
            int x = str.Length;

            for (int i = 0; ; i++)
            {
                if (x == i)
                    i = 0;
                if (key.Length == str.Length)
                    break;
                key += key[i];
            }

            return key;

        }

        //Function returns encrypted text generated with the help of the key
        public string cipherText(String str, String key)
        {

            string cipherText = "";

            for (int i = 0; i < str.Length; i++)
            {

                //Convert in range 0-25
                int x = (str[i] + key[i]) % 26;

                //Convert to ASCII value of char
                x += 'A';

                cipherText += (char)x;
            }

            return cipherText;
        }

        //Function to decrypt the encrypted text; which should display the original
        public string originalText(String cipherText, String key)
        {
            string originalText = "";

            for (int i = 0; i < cipherText.Length && i < key.Length; i++)
            {

                //convert to range 0-25
                int x = (cipherText[i] - key[i] + 26) % 26;

                //Convert to ASCII
                x += 'A';
                originalText += (char)x;
            }

            return originalText;
        }
    }
}
