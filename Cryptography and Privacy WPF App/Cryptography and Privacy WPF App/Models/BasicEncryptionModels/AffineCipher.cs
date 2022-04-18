using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Cryptography_and_Privacy_WPF_App
{
    class AffineCipher
    {

        private int a, b;
        private Regex onlyLetters = new Regex(@"^[a-zA-Z]");

        public AffineCipher(int a, int b)
        {
            this.a = a;
            this.b = b;
        }

        public string encryptMessage(string msg)
        {
            string cipher = "";
            char[] charArray = msg.ToCharArray();

            foreach (char c in charArray)
            {
                if (Char.IsUpper(c))
                    cipher += (char)(((a * (c - 'A') + b) % 26) + 'A');
                else if (Char.IsLower(c))
                    cipher += (char)(((a * (c - 'a') + b) % 26) + 'a');
                else
                    cipher += c;
            }

            return cipher;
        }

        public string decryptMessage(string cipher)
        {
            string pt = "";
            char[] cArray = cipher.ToCharArray();

            int aInverse = 0;
            int flag = 0;

            //need to find the multiplicative inverse of a in the group of ints mod n
            for (int i = 0; i < 26; i++)
            {
                flag = (a * i) % 26;

                //check if (a*i)%26 = 1
                //if this is true, then i is the multiplicative inverse of 1
                if (flag == 1)
                    aInverse = i;
            }

            foreach (char c in cArray)
            {
                //Now we apply the formula aInverse * (x - b) % m and add 'A' or 'a' to bring it into the range of the ASCII alphabet
                if (Char.IsUpper(c))
                    pt += (char)(((aInverse * (c + 'A' - b)) % 26) + 'A');
                else if (Char.IsLower(c))
                    pt += (char)(((aInverse * (c + 'a' - b)) % 26) + 'a');
                else
                    pt += c;
            }

            return pt;
        }

        void changeAB(int a, int b)
        {
            this.a = a;
            this.b = b;
        }
    }
}
