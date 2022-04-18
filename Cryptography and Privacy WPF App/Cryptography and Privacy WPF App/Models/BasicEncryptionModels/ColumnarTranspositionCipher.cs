using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Cryptography_and_Privacy_WPF_App
{
    class ColumnarTranspositionCipher
    {
        private Dictionary<int, int> keyMap;

        public ColumnarTranspositionCipher()
        {
   
        }

        //Function to set permutation order into keyMap
        public void setPermutationOrder(string key)
        {
            keyMap = new Dictionary<int, int>();

            for (int i = 0; i < key.Length; i++)
            {
                keyMap[key[i]] = i;
            }
        }

        //Encryption function
        public string encrypt(string msg, string key)
        {
            int row, col, j;

            string cipher = "";

            //Calculate colemns of the matrix
            col = key.Length;

            //calculate the max row of the matrix
            row = msg.Length / col;

            if (msg.Length % col == 0)
                row++;

            char[,] matrix = new char[col, row];

            for (int i = 0, k = 0; i < row; i++)
            {
                

                for (j = 0; j < col; )
                {
                    //MessageBox.Show(k.ToString());

                    if (k == msg.Length - 1)
                    {
                        /* Add padding character _*/
                        matrix[i, j] = '_';
                        j++;
                    }

                    if (k < msg.Length && (K.onlyUppersRegex.IsMatch(msg[k].ToString().ToUpper()) || msg[k] == ' '))
                    {
                        /*Adding only space and alphabet into the matrix*/
                        matrix[i, j] = msg[k];
                        j++;
                    }
                    k++;
                }
            }

            foreach (KeyValuePair<int, int> ii in keyMap)
            {
                j = ii.Value;

                //get cipher text from matrix columnwise using permuted key
                for (int i = 0; i < row; i++)
                {
                    if (K.onlyUppersRegex.IsMatch(matrix[i, j].ToString().ToUpper()) || matrix[i, j] == ' ' || matrix[i, j] == '_')
                        cipher += matrix[i, j];
                }
            }

            return cipher;
        }

        //Decryption method
        public string decrypt(string cipher, string key)
        {

            //Calculate row and column for cipher matrix
            int col = key.Length;

            int row = cipher.Length / col;
            char[,] cipherMatrix = new char[row, col];

            //Add characters into the matrix column-wise
            for (int j = 0, m = 0; j < col; j++)
                for (int i = 0; i < row; i++)
                    cipherMatrix[i, j] = cipher[m++];

            //Update the order of the key for decryption
            int index = 0;

            foreach (KeyValuePair<int, int> ii in keyMap)
            {
                keyMap[ii.Key] = index++;
            }

            //Arrange the matrix column-wise according to permutation order by adding into new matrix
            char[,] decipher = new char[row, col];

            int k = 0;
            for (int m = 0, j; m < key.Length; k++)
            {
                j = keyMap[key[m++]];
                for (int i = 0; i < row; i++)
                    decipher[i, k] = cipherMatrix[i, j];

            }

            //getting the message using matrix
            string msg = "";

            for (int i = 0; i < row; i++)
                for (int j = 0; k < col; k++)
                    if (decipher[i, j] != '_')
                        msg += decipher[i, j];

            return msg;

        }

    }
}
