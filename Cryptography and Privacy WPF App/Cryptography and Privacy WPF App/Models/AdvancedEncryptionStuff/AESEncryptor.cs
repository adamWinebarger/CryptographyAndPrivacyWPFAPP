using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;
using System.Windows;

namespace Cryptography_and_Privacy_WPF_App
{
    class AESEncryptor
    {
        //private byte[] bytes2Write = { 69, 74, 66, 65, 69, 83 };
    

        public AESEncryptor()
        {

        }

        //This way of doing it is a bit different from how I'd originally did it.
        //But this is more focused on strings in local memory vs. files with the other 
        //methods
        public string encrypt2ByteArray(string pt, byte[] key)
        {

            //Null-check catchment
            if (pt.Equals(null) || pt.Length <= 0)
                throw new ArgumentNullException("plaintext");
            if (key == null || key.Length <= 0)
                throw new ArgumentNullException("Key");

            byte[] enc;

            //Create an object of type AES
            using (SymmetricAlgorithm cipher = Aes.Create())
            {
                cipher.Key = key;
                //cipher.IV = bytes2Write;

                //Building the encrypter
                var encryptor = cipher.CreateEncryptor(cipher.Key, cipher.IV);

                //Now we need to creat a stream for encryption
                using (MemoryStream ms = new MemoryStream()) {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                    using (StreamWriter writer = new StreamWriter(cs)) {

                        //this monstrosity writes the data to the stream for us
                        writer.Write(pt);
                    }

                    enc = ms.ToArray();

                }
                
            }

            MessageBox.Show(Encoding.UTF8.GetString(enc));
            return Encoding.UTF8.GetString(enc);
        }

        public string decryptString(string cipherText, string key)
        {
            //Null-check catchment
            if (cipherText.Equals(null) || cipherText.Length <= 0)
                throw new ArgumentNullException("plaintext");
            if (key == null || key.Length <= 0)
                throw new ArgumentNullException("Key");

            byte[] ct = Encoding.UTF8.GetBytes(cipherText),
                realKey = Encoding.UTF8.GetBytes(key);

            //declare/initialize the string we'll use to store the plaintext
            string pt = "";

            //Create AES object
            using (SymmetricAlgorithm aes = Aes.Create())
            {
                aes.Key = realKey;
                //aes.IV = bytes2Write;

                var decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                //create stream for decryption
                using (MemoryStream msD = new MemoryStream(ct))
                using (CryptoStream csd = new CryptoStream(msD, decryptor, CryptoStreamMode.Read))
                using (StreamReader srd = new StreamReader(csd))
                {
                    //Read decrypted bytes and place them into a string
                    pt = srd.ReadToEnd();
                }
            }

            return pt;
        }

        //Encryption method from the BAARS program. 
        //That way if we want to let people mess with encrypting/decrypting their own textfiles,
        //Then... that'd actually be pretty cool, huh?
        public void EncryptFile(string filePath, byte[] key)
        {
            string tempFileName = Path.GetTempFileName();

            using (SymmetricAlgorithm cipher = Aes.Create())
            using (FileStream fileStream = File.OpenRead(filePath))
            using (FileStream tempFile = File.Create(tempFileName))
            {
                cipher.Key = key;
                //aes.IV will be automatically populated with secure random value
                byte[] iv = cipher.IV;

                //write marker header to identify how to read the file in the future
                tempFile.WriteByte(69);
                tempFile.WriteByte(74);
                tempFile.WriteByte(66);
                tempFile.WriteByte(65);
                tempFile.WriteByte(69);
                tempFile.WriteByte(83);

                tempFile.Write(iv, 0, iv.Length);

                using (var cryptoStream = new CryptoStream(tempFile, cipher.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    fileStream.CopyTo(cryptoStream);
                }
            }

            File.Delete(filePath);
            File.Move(tempFileName, filePath);

        }

        public string[] DecryptFile(string filepath, byte[] key)
        {

            try
            {
                string tempFileName = Path.GetTempFileName();

                using (SymmetricAlgorithm cipher = Aes.Create())
                using (FileStream fileStream = File.OpenRead(filepath))
                using (FileStream tempFile = File.Create(tempFileName))
                {
                    cipher.Key = key;
                    byte[] iv = new byte[cipher.BlockSize / 8];
                    byte[] headerBytes = new byte[6];
                    int remain = headerBytes.Length;

                    while (remain != 0)
                    {
                        int read = fileStream.Read(headerBytes, headerBytes.Length - remain, remain);

                        if (read == 0)
                            throw new EndOfStreamException();

                        remain -= read;

                    }

                    if (headerBytes[0] != 69 || headerBytes[1] != 74 || headerBytes[2] != 66 ||
                        headerBytes[3] != 65 || headerBytes[4] != 69 || headerBytes[5] != 83)
                        throw new InvalidOperationException();

                    remain = iv.Length;

                    while (remain != 0)
                    {
                        int read = fileStream.Read(iv, iv.Length - remain, remain);

                        if (read == 0)
                            throw new EndOfStreamException();

                        remain -= read;
                    }

                    cipher.IV = iv;

                    using (var cryptoStream = new CryptoStream(tempFile, cipher.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        fileStream.CopyTo(cryptoStream);
                    }
                }

                //File.Delete(filepath);
                //File.Move(tempFileName, filepath);
                string[] lines = File.ReadAllLines(tempFileName);
                File.Delete(tempFileName);
                return lines;
            }
            catch
            {
                return null;
            }
        }

    }
}
