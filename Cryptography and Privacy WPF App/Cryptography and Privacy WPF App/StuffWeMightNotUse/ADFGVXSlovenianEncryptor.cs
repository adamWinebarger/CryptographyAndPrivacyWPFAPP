using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptography_and_Privacy_WPF_App
{
    class ADFGVXSlovenianEncryptor
    {

        private string alphabet = "ABCČDEFGHIJKLMNOPRSŠTUVZŽ".ToLower();
        private string numbers = "0123456789";
        private string adfgvx = "adfgvx".ToUpper();
        

        public ADFGVXSlovenianEncryptor()
        {

        }

        string encrypt(string input)
        {
            string encrypted = "";
            input = cleanText(input);

            // Dictionary<string, char> square = generateSquare(keytext.text);


            return "";
        }

        private string cleanText(string text)
        {
            string cleanText = "";

            for (int i = 0; i < text.Length; i++)
            {
                if (alphabet.IndexOf(text[i]) > -1 || numbers.IndexOf(text[i]) > -1)
                    cleanText += text[i];
            }

            return cleanText;
        }

        private Dictionary<char, string> generateSquare(string text)
        {
            Dictionary<char, string> dict = new Dictionary<char, string>();
            string selectedChars = text.Substring(0, 6);
            string addedChars = "";
            int charsCounter = 0;
            int numCounter = 0;
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    if (charsCounter < 6)
                    {
                        if (addedChars.IndexOf(selectedChars[charsCounter]) > -1)
                        {
                            dict.Add(selectedChars[charsCounter], (adfgvx[i].ToString() + adfgvx[j].ToString()));
                            addedChars = addedChars + selectedChars[charsCounter];
                        }
                        else
                        {
                            j--;
                        }
                        charsCounter++;
                    }
                    else
                    {
                        if (j % 2 > 0 && numCounter < 10)
                        {
                            dict.Add(numbers[numCounter], (adfgvx[i].ToString() + adfgvx[j].ToString()));
                            addedChars = addedChars + numbers[numCounter];
                            numCounter++;
                        }
                        else
                        {
                            for (int k = 0; k < alphabet.Length; k++)
                            {
                                if (addedChars.IndexOf(alphabet[k]) < 0)
                                {
                                    dict.Add(alphabet[k], (adfgvx[i].ToString() + adfgvx[j].ToString()));
                                    addedChars = addedChars + alphabet[k];
                                    break;
                                }
                            }
                        }
                    }

                }
            }
            return dict;
        }
    }
}
