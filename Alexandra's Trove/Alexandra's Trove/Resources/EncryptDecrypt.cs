using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Alexandra_s_Trove.Resources
{
    internal class EncryptDecrypt
    {
        

        public static string Encrypt(string toEncrypt)
        {

            string hash = "Alexandra";
            string encryptedToReturn = "";
            byte[] data = UTF8Encoding.UTF8.GetBytes(toEncrypt);
            using (MD5CryptoServiceProvider MD5 = new MD5CryptoServiceProvider())
            {
                byte[] keys = MD5.ComputeHash(UTF32Encoding.UTF8.GetBytes(hash));
                using (TripleDESCryptoServiceProvider triple = new TripleDESCryptoServiceProvider() {Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7})
                {
                    ICryptoTransform transform = triple.CreateEncryptor();
                    byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                    string encrypted = Convert.ToBase64String(results);
                    encryptedToReturn = encrypted;
                }

            }
            return encryptedToReturn;

        }

        public static string Decrypt(string toDecrypt)
        {
            string hash = "Alexandra";
            string decryptedToReturn = "";
            byte[] data = Convert.FromBase64String(toDecrypt);
            using (MD5CryptoServiceProvider MD5 = new MD5CryptoServiceProvider())
            {
                byte[] keys = MD5.ComputeHash(UTF32Encoding.UTF8.GetBytes(hash));
                using (TripleDESCryptoServiceProvider triple = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                {
                    ICryptoTransform transform = triple.CreateDecryptor();
                    byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                    string decrypted = UTF8Encoding.UTF8.GetString(results);
                    decryptedToReturn = decrypted;
                }

            }
            return decryptedToReturn;
        }



    }
}
