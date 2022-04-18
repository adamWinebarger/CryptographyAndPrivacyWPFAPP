using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Windows;

namespace Cryptography_and_Privacy_WPF_App
{
    class RSACipher
    {

        public RSACipher()
        {

        }

        public byte[] resEncrypt(byte[] dataToEncrypt, RSAParameters rsaKeyInfo, bool doOAEPPadding)
        {
            try
            {
                byte[] encData;

                //Create new instance of RSA CryptoServiceProvider
                using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
                {

                    //Import the RSA key info (pubkey)
                    encData = rsa.Encrypt(dataToEncrypt, doOAEPPadding);
                }

                return encData;
            }

            //Catch block for if we run into a Cryptographic exception
            catch (CryptographicException e)
            {
                MessageBox.Show(e.Message);
                return null;
            }
        }

        public byte[] rsaDecrypt(byte[] data2Decrypt, RSAParameters rsaKeyInfo, bool doOAEPPadding)
        {
            try
            {
                byte[] decryptedData;

                //create instance of rsaCryptoServiceProvider... again
                using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
                {
                    //Import the RSA key info. This needs to include privKey
                    rsa.ImportParameters(rsaKeyInfo);

                    //Decrype passed byte array amd specify OAEP padding
                    decryptedData = rsa.Decrypt(data2Decrypt, doOAEPPadding);
                }
                return decryptedData;
            } catch (CryptographicException e)
            {
                MessageBox.Show(e.Message);
                return null;
            }
        }

    }
}
