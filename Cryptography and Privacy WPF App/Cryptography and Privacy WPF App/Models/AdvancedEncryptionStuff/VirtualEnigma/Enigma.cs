using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptography_and_Privacy_WPF_App
{
    class Enigma
    {
        public Rotor leftRotor, middleRotor, rightRotor;

        public Reflector reflector;

        public Plugboard plugboard;

        public Enigma(int[] rotorNums, string reflector, int[] rotorPOS, int[] ringSettings, string plugBoardCON)
        {
            leftRotor = Rotor.Create(rotorNums[0], rotorPOS[0], ringSettings[0]);
            middleRotor = Rotor.Create(rotorNums[1], rotorPOS[1], ringSettings[1]);
            rightRotor = Rotor.Create(rotorNums[2], rotorPOS[2], ringSettings[2]);

            this.reflector = Reflector.Create(reflector);
            plugboard = new Plugboard(plugBoardCON);
        }

        public Enigma(EnigmaKey key)
        {
            
        }

    }
}
