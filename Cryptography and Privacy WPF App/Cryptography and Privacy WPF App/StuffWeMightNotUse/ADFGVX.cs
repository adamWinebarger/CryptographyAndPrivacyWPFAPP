using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptography_and_Privacy_WPF_App
{
    class ADFGVX
    {

       

        string[] defaultTable = { "abcdef", "ghijkl", "mnopqr", "stuvwx", "yz0123", "456789" };

        public ADFGVX()
        {

        }


        public void cipher(string s)
        {

            int row, col;

            //Convert each char to encrypted code
            for (int i = 0; i < s.Length; i++)
            {

                //Find row of table
                row = (int)Math.Floor((s[i] - 'a') / 5.0) + 1;

                //find column
                col = ((s[i] - 'a') % 5) + 1;

                //if character is k
                if (s[i] == 'k')
                {
                    row -= 1;
                    col = 5 - col + 1;
                }

                //if char is greater that j
                else if (s[i] >= 'j')
                {
                    if (col == 1)
                    {
                        col = 6;
                        row -= 1;
                    }

                    col -= 1;
                }
                Console.WriteLine(row + " " + col);
            }
            Console.WriteLine("");
        }
    }
}
