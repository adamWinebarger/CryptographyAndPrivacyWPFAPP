using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptography_and_Privacy_WPF_App
{

    //Rotor object for building a virtual enigma machine
    public class Rotor
    {

        public string name { get; protected set; }

        protected int[] forwardWiring, backwardWiring;
        public int rotorPosition { get; protected set; }

        protected int notchPosition, ringSetting;

        public Rotor(string name, string encoding, int rotorPosition, int notchPosition, int ringSetting)
        {
            this.name = name;
            forwardWiring = decodeWiring(encoding);
            backwardWiring = inverseWiring(forwardWiring);
            this.rotorPosition = rotorPosition;
            this.notchPosition = notchPosition;
            this.ringSetting = ringSetting;
        }

        public static Rotor Create(int num, int pos, int setting)
        {
            switch (num)
            {
                case 1:
                    return new Rotor("I", "EKMFLGDQVZNTOWYHXUSPAIBRCJ", pos, 16, setting);
                case 2:
                    return new Rotor("II", "AJDKSIRUXBLHWTMCQGZNPYFVOE", pos, 4, setting);
                case 3:
                    return new Rotor("III", "BDFHJLCPRTXVZNYEIWGAKMUSQO", pos, 21, setting);
                case 4:
                    return new Rotor("IV", "ESOVPZJAYQUIRHXLNFTGKDCMWB", pos, 9, setting);
                case 5:
                    return new Rotor("V", "VZBRGITYUPSDNHLXAWMJQOFECK", pos, 25, setting);
                case 6:
                    return new Rotor("VI", "JPGVOUMFYQBENHZRDKASXLICTW", pos, 0, setting); 
                case 7:
                    return new Rotor("VII", "NZJHGRCXMYSWBOUFAIVLPEKQDT", pos, 0, setting);
                case 8:
                    return new Rotor("VIII", "FKQHTLXOCBJSPDZRAMEWNIUYGV", pos, 0, setting);
                default:
                    return new Rotor("Identity","ABCDEFGHIJKLMNOPQRSTUVWXYZ", pos, 0, setting);
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

        protected int[] inverseWiring(int[] wiring)
        {
            int[] inverse = new int[wiring.Length];
            for (int i = 0; i < wiring.Length; i++)
            {
                int forward = wiring[i];
                inverse[forward] = i;
            }
            return inverse;
        }

        protected int encipher(int k, int pos, int ring, int[] map)
        {
            int shift = pos - ring;
            return (map[k + shift + 26] % 26 - shift + 26) % 26;
        }

        public int forward(int c)
        {
            return encipher(c, rotorPosition, ringSetting, forwardWiring);
        }

        public int backward(int c)
        {
            return encipher(c, rotorPosition, ringSetting, backwardWiring);
        }

        public bool isNotch()
        {
            if (name.StartsWith("VI") && name.EndsWith("I"))
                return rotorPosition == 12 || rotorPosition == 25;

            return notchPosition == rotorPosition;
        }

        public void turnover()
        {
            rotorPosition = (rotorPosition + 1) % 26;
        }
    }
}
