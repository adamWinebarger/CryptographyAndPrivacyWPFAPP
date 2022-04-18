using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptography_and_Privacy_WPF_App
{
    class Reflector
    {
        public int[] forwardWiring { get; protected set; }

        public Reflector(string encoding)
        {
            forwardWiring = decodeWiring(encoding);
        }

        public static Reflector Create(string name)
        {
            switch (name)
            {
                case "B":
                    return new Reflector("YRUHQSLDPXNGOKMIEBFZCWVJAT");
                case "C":
                    return new Reflector("FVPJIAOYEDRZXWGCTKUQSBNMHL");
                default:
                    return new Reflector("ZYXWVUTSRQPONMLKJIHGFEDCBA");
            }
        }

        protected int[] decodeWiring(string encoding)
        {
            char[] cWire = encoding.ToCharArray();
            int[] wiring = new int[cWire.Length];
            for (int i = 0; i < cWire.Length; i++)
                wiring[i] = cWire[i] - 65;
            return wiring;
        }
    }
}
