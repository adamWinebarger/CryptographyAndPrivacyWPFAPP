using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptography_and_Privacy_WPF_App
{
    class RailFenceCipher
    {

        public RailFenceCipher()
        {

        }

        //Encryption function
        public string encrypt(string text, int key)
        {

            //first we have to create our matrix to encipher the plaintext
            //key = rows, text.Length = columns

            char[,] rail = new char[key, text.Length];


            //Now we need to fill the rail matrix to distinguish filled spaces and blank ones
            for (int i = 0; i < key; i++)
                for (int j = 0; j < text.Length; j++)
                    rail[i, j] = '\n';

            //find direction
            bool down = false;
            int row = 0, col = 0;

            for (int i = 0; i <text.Length; i++)
            {
                //check direction of flow
                //reverse direction if we've just filled top or bottom rail

                if (row == 0 || row == key - 1)
                    down = !down;

                //fill corresponding alphabet
                rail[row, col++] = text[i];

                //find next row using direction flag
                if (down)
                    row++;
                else
                    row--;
            }

            //now we can construct the cipher using the rail matrix
            string result = "";

            for (int i = 0; i < key; i++)
                for (int j = 0; j < text.Length; j++)
                    if (rail[i, j] != '\n')
                        result += rail[i, j];

            return result;
        }

        //Decryption function. This one would recieve cipher text and key and 
        //output the original text
        public string decrypt(string cipher, int key)
        {

            //create the matrix to encipher/decipher
            char[,] rail = new char[key, cipher.Length];

            for (int i = 0; i < key; i++)
                for (int j = 0; j < cipher.Length; j++)
                    rail[i, j] = '\n';

            //used to find direction
            bool down = false;
            int row = 0, col = 0;

            //Mark the places with *
            for (int i = 0; i < cipher.Length; i++)
            {

                //check the direction of the flow
                if (row == 0)
                    down = true;
                if (row == key - 1)
                    down = false;

                //place the marker
                rail[row, col++] = '*';

                //find the next row using direction flag
                if (down)
                    row++;
                else
                    row--;
            }

            //Now we can construct the filled matrix
            int index = 0;

            for (int i = 0; i < key; i++)
                for (int j = 0; j < cipher.Length; j++)
                    if (rail[i, j] == '*' && index < cipher.Length)
                        rail[i, j] = cipher[index++];

            //now read the matrix in a zig-zag manner to reconstruct plaintext
            string result = "";

            row = 0; col = 0;

            for (int i = 0; i < cipher.Length; i++)
            {

                //check the direction of the flow
                if (row == 0)
                    down = true;
                if (row == key - 1)
                    down = false;

                //Place the marker
                if (rail[row, col] != '*')
                    result += rail[row, col++];

                //find the next row using the direction flag
                if (down)
                    row++;
                else
                    row--;
            }

            return result;

        }

    }
}
