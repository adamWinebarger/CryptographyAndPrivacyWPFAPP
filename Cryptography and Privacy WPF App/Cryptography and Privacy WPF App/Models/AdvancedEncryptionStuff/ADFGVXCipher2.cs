using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Cryptography_and_Privacy_WPF_App
{
    class ADFGVXCipher2
    {
        //Letters t be transmitted in morse-code
        private char[] morse = { 'A', 'D', 'F', 'G', 'V', 'X' };

        private string key = "";

        //empty grid
        private char[,] grid;

        //original (unsorted) columns
        private Column[] col,
            newCols; //columns sorted by their headers

        private List<char> table = new List<char>();

        public ADFGVXCipher2(string key)
        {
            //Fill an arrayList with all characters to put into gri
            List<char> table = new List<char>();

            for (char c = 'A'; c <= 'Z'; c++)
                table.Add(c);
            for (char d = '0'; d <= '9'; d++)
                table.Add(d);

            //Create rng to randomly extract char from arraylist
            Random rand = new Random();

            grid = new char[morse.Length, morse.Length]; //creates 6x6 grid

            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    //generate random number between 0 and the listSize
                    int index = rand.Next(table.Count);

                    //remove char at that index and store it in grid
                    grid[i, j] = table[index];
                    table.RemoveAt(index);
                }
            }

            setKey(key);
            
        }

        public void setKey(string key)
        {
            //catchment for null key
            if (key == null)
                return;

            //remove any duplicates
            this.key = removeDuplicates(key);
            int len = key.Length;

            //Now we can build columns with the chars of the key as header
            col = new Column[len];
            newCols = new Column[len];

            for (int i = 0; i < len; i++)
            {
                //original
                col[i] = new Column(key[i]);

                //also makes sense to load newCols here
                newCols[i] = col[i];
            }

            Array.Sort(newCols);
            
        }

        public string encode(string pt)
        {
            //MessageBox.Show(pt);
            
            char[] digit = process(pt, true);

            if (digit.Length == 0)
                return "";

           // MessageBox.Show(charArray2String(digit));

            //prep columns (multiply by 2 for the 2 coded letters per char in the original msg)
            prepColumns(digit.Length * 2);

            //find coords of each char in original message and add it row by row to each column
            int k = 0;

            foreach (char c in digit)
            {
                Point p = findPoS(c);

                //Add two letters
                col[k++].add(morse[p.x]);

                //wrap around at the end of the columns
                k %= col.Length;

                col[k++].add(morse[p.y]);
                k %= col.Length;
            }
            //MessageBox.Show("firsr 4each loop passed");

            StringBuilder sb = new StringBuilder(pt.Length * 2);

            foreach (Column c in newCols)
                sb.Append(charArray2String(c.letters)); //This... might not work

            //MessageBox.Show(sb.ToString());
            //return full coded string with spaces in between each pair
            digit = sb.ToString().ToCharArray();

            sb = new StringBuilder(digit.Length + (digit.Length / 2));

            //The first two digits need to be done outside of the loop in order to stay in bounds
            sb.Append(digit[0]);
            sb.Append(digit[1]);

            //then every other pair can be appended using a for loop (because we need those spaces)... well, maybe not "need", but...
            for (int i = 2; i < digit.Length; i += 2)
            {
                sb.Append(' ');
                sb.Append(digit[i]);
                sb.Append(digit[i + 1]);
            }

            //MessageBox.Show(sb.ToString());
            return sb.ToString();
            
        } //Holy fuck

        //Now it's time for decode... fml
        public string decode(string ct)
        {
            //MessageBox.Show(ct);
            char[] digit = process(ct, false);
            //MessageBox.Show(charArray2String(digit));

            if (digit.Length == 0)
                return "";

            //prepare the column
            prepColumns(digit.Length);

            //copy coded message from each sorted column
            int k = 0;

            foreach (Column c in newCols)
            {
                int size2 = c.getSize(); //gives us number of chars in column
                for (int i = 0; i < size2; i++)
                    c.add(ct[k++]); //append digit and increment k
            }

            StringBuilder sb = new StringBuilder(ct.Length);
            int size = col[0].getSize();

            //scan all rows
            for (int row = 0; row < size; row++)
            {
                //scan for a given row in all columns
                foreach (Column c in col)
                {
                    //if column has less rows, there's no need to keep going
                    if (row >= c.getSize())
                        break;

                    sb.Append(c.getChar(row));
                }
            }

            //make charARray from sb
            digit = sb.ToString().ToCharArray();

            //use another char array to store decoded string
            char[] dCode = new char[digit.Length / 2];

            //pass through string 2 chars at a time to find the equivelent on the grid
            for (int i = 0; i < digit.Length; i += 2)
            {
                //find x coord in grid
                int x = 0;
                for (; x < morse.Length; x++)
                    if (digit[i] == morse[x])
                        break;

                int y = 0;
                for (; y < morse.Length; y++)
                    if (digit[i + 1] == morse[y])
                        break;

                //assign value from the grid
                dCode[i / 2] = grid[x, y];
            }

            return new string (dCode);
        }

        private char[] process(string str, bool encoding)
        {
            //MessageBox.Show(str);
            if (str.Equals("") || str.Equals(null))
                return new char[0];

            if (key.Length == 0)
                return new char[0];

            string sb = ""; ;
            //MessageBox.Show(sb.ToString());

            char[] dgt = str.ToUpper().ToCharArray();

            //MessageBox.Show(str);
            foreach (char c in dgt)
            {
                if (encoding)
                {
                    //if encoding is a letter or digit, add it
                    if ((c >= 'A' && c <= 'Z') || (c >= '0' && c <= '9'))
                        sb += c;
                }
                else
                {
                    //when decoding only the morse letters are permitted
                    foreach (char m in morse)
                    {
                        //if letter contains morse letter
                        if (m == c)
                        {
                            sb += c;
                            break; //no need to continue loop past this point
                        }
                    }
                }
            }

            //MessageBox.Show( "After first foreach loop: "  + sb.ToString());
            //now digits is just the valid chars
            dgt = sb.ToCharArray();

            if (dgt.Length <= 0)
                return dgt;

            //when decoding, the number must be even
            if (!encoding)
                if (dgt.Length % 2 != 0)
                    return new char[0];

            return dgt;
        }

        private void prepColumns(int len)
        {
            //calculate number of chars per column
            int perCol = len / col.Length;

            //make array of this length
            int[] nb = new int[col.Length];

            for (int i = 0; i < col.Length; i++)
                nb[i] = perCol;

            int remainder = len - (col.Length * perCol);
            for (int j = 0; j < remainder; j++)
                nb[j]++;

            //can now set the size of each column object
            for (int k = 0; k < col.Length; k++)
                col[k].setSize(nb[k]);
        }

        private string removeDuplicates(string input)
        {
            string output = "";

            foreach (char c in input)
            {
                if (!output.Contains(c))
                    output += c;
            }
            return output;
        }

        Point findPoS(char c)
        {
            for (int x = 0; x < 6; x++)
                for (int y = 0; y < 6; y++)
                    //returns a point if we find a hit in our grid
                    if (c == grid[x, y])
                        return new Point(x, y);

            throw new Exception("character not found in grid");
        }

        private string charArray2String(char[] c)
        {
            string output = "";

            foreach (char c1 in c)
                output += c1;
            return output;
        }

        private class Column : IComparable<Column>
        {

            //letters ADFGVX at the head of the column
            private char header;

            //letters in a given column
            public char[] letters { get; private set; }

            //used when we combine digits in letters array
            private int index;

            public Column(char header)
            {
                this.header = header;
            }

            //used to set the number of elements in column
            public void setSize(int size)
            {
                //build array to recieve all elements
                letters = new char[size];

                //here we'll initialize index at 0 to avoid possible null-ptr exceptions
                index = 0;
            }

            public int getSize()
            {
                return letters.Length;
            }

            public void add(char c)
            {
                letters[index++] = c;
            }

            public char getChar(int at)
            {
                return letters[at];
            } 

            //return letters in column as string
            public string toString()
            {
                return new string(letters);
            }

            public int CompareTo(Column other)
            {
                return this.header - other.header;
            }
        }

        private struct Point
        {
            public int x, y;

            public Point(int x, int y)
            {
                this.x = x;
                this.y = y;
            }

        }
    }

    
}
