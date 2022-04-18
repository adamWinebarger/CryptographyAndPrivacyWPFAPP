using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;

namespace Cryptography_and_Privacy_WPF_App
{
    static class K
    {

        /*Regex's*/
        public readonly static Regex onlyUppersRegex = new Regex("[^A-Z]"),
            onlyNumbersRegex = new Regex("^[0-9]+$");


        /*String constants*/

        //Things for the Vigenere window that might get used for other things
        public const string VigenerTextError = "Woah there pardner! Looks like you forgot to input a " +
            "message into the message text entry. Why don't you mosey on over there and take care " +
            "of that for me. Make sure that your message only contains letters (no numbers no punctuation)",

            VigenereKeyError = "Wot in Tarnation? You forgot to enter yourself a key on that there key line.";

        //Key error for the railfence window
        public const string railFenceKeyError = "Invalid input detected for the key entry. Please use only numbers" +
            " for your key input.";

        //General errors I guess
        public const string badNegativeNumberError = "It would appear that you put some value into the key textbox that, while a number, is not a valid number for this operation. Please try something greater than or equal to 2";

        //Errors; general
        public const string unknownError1 = "I don't know what you did to recieve this message. " +
            "But please don't do it again",

            emptyClipBoard = "It would appear that there is nothing in your clipboard to copy";


        /* Strings for file and  directory paths*/

        //little blurbs
        public const string blurbsDir = "Blurbs\\";

        public const string basicsBlurbsDir = blurbsDir + "BasicsBlurbs\\";

        public const string historyDir = blurbsDir + "HistoryBlurbs\\";

        public const string littleBlurbsDir = blurbsDir + "LittleBlurbs\\";

        public const string basicTextsDir = "BasicTexts\\";

        //Images/assets
        public const string assetsDir = "Assets\\";

        public const string imagesDir = @"\Assets\Images\";

        public const string basicImages = imagesDir + "BasicsImages\\";

        //Centralized method for reading from a file because I'm tired of writing one out.
        public static string readFromFile(string input)
        {
            string output = "";

            if (File.Exists(input))
            {
                output += File.ReadAllText(input);
            }
            return output; 

        }

    }
}
