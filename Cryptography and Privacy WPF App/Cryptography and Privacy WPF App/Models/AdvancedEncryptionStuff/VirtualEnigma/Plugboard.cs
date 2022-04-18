using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptography_and_Privacy_WPF_App
{
    class Plugboard
    {
        private int[] wiring;

        public Plugboard(string conn)
        {
            wiring = decodePlugboard(conn);
        }

        public int[] decodePlugboard(string plugboard)
        {
            if (plugboard == null || plugboard.Equals(""))
                return identityPlugBoard();

            string[] pairings = plugboard.Split("[^a-zA-Z]");

            HashSet<int> pluggedChars = new HashSet<int>();
            int[] mapping = identityPlugBoard();

            //Validate and create map
            foreach (string pair in pairings)
            {
                if (pair.Length != 2)
                    return identityPlugBoard();

                int c1 = pair[0] - 65, c2 = pair[1] - 65;

                if (pluggedChars.Contains(c1) || pluggedChars.Contains(c2))
                    return identityPlugBoard();

                pluggedChars.Add(c1);
                pluggedChars.Add(c2);

                mapping[c1] = c2;
                mapping[c2] = c1;
            }

            return mapping;
        }

        private int[] identityPlugBoard()
        {
            int[] mapping = new int[26];
            for (int i = 0; i < 26; i++)
                mapping[i] = i;
            return mapping;
        }

        public int forward(int c)
        {
            return wiring[c];
        }

        public HashSet<int> getUnpluggedChars(string plugboard)
        {
            var unpluggedChars = new HashSet<int>();
            for (int i = 0; i < 26; i++)
                unpluggedChars.Add(i);

            if (plugboard.Equals(""))
                return unpluggedChars;

            string[] pairings = plugboard.Split("[^a-zA-Z]");

            //validation phase
            foreach (string pair in pairings)
            {
                int c1 = pair[0] - 65, c2 = pair[1] - 65;

                unpluggedChars.Remove(c1);
                unpluggedChars.Remove(c2);
            }

            return unpluggedChars;
        }

    }
}
