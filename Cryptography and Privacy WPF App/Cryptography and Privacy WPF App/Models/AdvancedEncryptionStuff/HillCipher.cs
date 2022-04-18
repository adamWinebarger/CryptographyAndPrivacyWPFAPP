using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptography_and_Privacy_WPF_App
{
    class HillCipher
    {
        private string key;
        private int[,] keyMatrix;

        public HillCipher()
        {

        }

        //Keymatrix generator
        private void gener8KeyMatrix(string key, int[,] keyMatrix)
        {
            int k = 0;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    keyMatrix[i, j] = (key[k]) % 65;
                    k++;
                }
            }
        }

        private void encrypt(int[,] cipherMatrix, int[,] keyMatrix, int[,] msgVector)
        {
            int x, i, j;

            for (i = 0; i < 3; i++)
            {
                for (j = 0; j < 1; j++)
                {
                    cipherMatrix[i, j] = 0;

                    for (x = 0; x < 3; x++)
                        cipherMatrix[i, j] += keyMatrix[i, x] * msgVector[x, j];

                    cipherMatrix[i, j] = cipherMatrix[i, j] % 26;
                }
            }
        }

        public string hillCipher(string message, string key)
        {

            //gets key matrix from key stiring
            int[,] keyMatrix = new int[3, 3];
            gener8KeyMatrix(key, keyMatrix);

            int[,] messageVector = new int[3, 3];

            //generate vector
            for (int i = 0; i < 3; i++)
                messageVector[i, 0] = (message[i]) % 65;

            int[,] cipherMatrix = new int[3, 1];

            //Following function generates the encrypted vector
            encrypt(cipherMatrix, keyMatrix, messageVector);

            string ct = "";

            for (int i = 0; i < 3; i++)
                ct += (char)(cipherMatrix[i, 0] + 65);

            return ct;
        }

    }
}
