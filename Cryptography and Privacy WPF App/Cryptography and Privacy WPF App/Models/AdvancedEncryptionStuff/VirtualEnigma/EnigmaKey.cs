using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptography_and_Privacy_WPF_App
{
    struct EnigmaKey
    {
        public int[] rotors, indicators, rings;
        public string plugBoard;

        public EnigmaKey(int[] rotors, int[] indicators, int[] rings, string plugBoard)
        {
            this.rotors = rotors == null ? new int[] { 1, 2, 3 } : rotors;
            this.indicators = indicators == null ? new int[] { 0, 0, 0 } : indicators;
            this.rings = rings == null ? new int[] { 0, 0, 0 } : rings;
            this.plugBoard = plugBoard == null ? "" : plugBoard;
        }

        public EnigmaKey(EnigmaKey key)
        {
            this.rotors = key.rotors == null ? new int[] { 1,2,3 } : new int[] { key.rotors[0], key.rotors[1], key.rotors[2] };
            this.indicators = key.indicators == null ? new int[] { 0, 0, 0 } : key.indicators;
            this.rings = key.rings == null ? new int[] { 0, 0, 0 } : key.rings;
            this.plugBoard = key.plugBoard == null ? "" : key.plugBoard;
        }
    }
}
