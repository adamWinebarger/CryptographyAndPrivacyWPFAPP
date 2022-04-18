using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptography_and_Privacy_WPF_App
{
    class AtbashCipher
    {

        

        public AtbashCipher()
        {

        }

        public string encrypt(string message)
        {
            string cipher = "";

            foreach (char c in message)
            {
                if (char.IsUpper(c))
                {
                    char d = (char)(((25 - (c - 'A')) % 26) + 'A');
                    cipher += d;
                }
                else if (char.IsLower(c))
                {
                    char d = (char)(((25 - (c - 'a')) % 26) + 'a');
                    cipher += d;
                }
                else
                    cipher += c;
            }

            return cipher;
        }

    }
}
