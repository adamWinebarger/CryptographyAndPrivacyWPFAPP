using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptography_and_Privacy_WPF_App
{
    class ColumnarTransposition2
    {
        public ColumnarTransposition2()
        {

        }

        private int[] getShiftIndexes(string key)
        {
            int len = key.Length;
            int[] indexes = new int[len];

            var sortedKey = new List<KeyValuePair<int, char>>();

            for (int i = 0; i < len; i++)
                sortedKey.Add(new KeyValuePair<int, char>(i, key[i]));

            sortedKey.Sort( delegate (KeyValuePair<int, char> p1, KeyValuePair<int, char> p2) {
                    return p1.Value.CompareTo(p2.Value);
            });

            for (int j = 0; j < len; j++)
                indexes[sortedKey[j].Key] = j;

            return indexes;
        }

        public string encrypt(string text, string key)
        {
            text = (text.Length % key.Length == 0) ? text : text.PadRight
                (text.Length  - (text.Length % key.Length) + key.Length, '_'); //This gives us some additional padding if need be

            string output = "";
            int totalChars = text.Length,
                columns = key.Length,
                rows = (int)Math.Ceiling((double)totalChars / columns);

            char[,] rowChars = new char[rows, columns],
                columnChars = new char[columns, rows],
                sortedChars = new char[columns, rows];

            int currentRow, currentCol, i, j;
            int[] shiftIndexes = getShiftIndexes(key);

            for (i = 0; i < totalChars; i++)
            {
                currentRow = i / columns;
                currentCol = i % columns;
                rowChars[currentRow, currentCol] = text[i];
            }

            
            for (i = 0; i < rows; i++)
                for (j = 0; j < columns; j++)
                    columnChars[j, i] = rowChars[i, j];

            
            for (i = 0; i < columns; i++)
                for (j = 0; j < rows; j++)
                    sortedChars[shiftIndexes[i], j] = columnChars[i, j];

            for (i = 0; i < totalChars; i++)
            {
                currentRow = i / rows;
                currentCol = i % rows;
                output += sortedChars[currentRow, currentCol];
            }

            return output;

        }

        public string decrypt(string text, string key)
        {
            string output = "";

            int totalChars = text.Length,
                totalColums = (int)Math.Ceiling((double)totalChars / key.Length),
                totalRows = key.Length;

            char[,] rowChars = new char[totalRows, totalColums],
                 colChars = new char[totalColums, totalRows],
                 unsorted = new char[totalColums, totalRows];

            int currentRow, currentCol, i, j;
            int[] shiftIndex = getShiftIndexes(key);

            //Basically just a backwards implementation of encrypt now
            for (i = 0; i < totalChars; i++)
            {
                currentRow = i / totalColums;
                currentCol = i % totalColums;
                rowChars[currentRow, currentCol] = text[i];
            }

            for (i = 0; i < totalRows; i++)
                for (j = 0; j < totalColums; j++)
                    colChars[j, i] = rowChars[i, j];

            for (i = 0; i < totalColums; i++)
                for (j = 0; j < totalRows; j++)
                    unsorted[i, j] = colChars[i, shiftIndex[j]];

            for (i = 0; i < totalChars; i++)
            {
                currentRow = i / totalRows;
                currentCol = i % totalRows;
                output += unsorted[currentRow, currentCol];
            }

            return output;
        }

    }
}
