using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Alexandra_s_Trove.Resources
{
    internal class EncryptDecrypt//used to store data safely in the database
    {
        

        public static string Encrypt(string toEncrypt)//function used to encrypt strings
        {

            string hash = "Alexandra";//create hash key
            string encryptedToReturn = "";//will store encrypted string
            byte[] data = UTF8Encoding.UTF8.GetBytes(toEncrypt);//convert string that will be encrypted into bytes
            using (MD5CryptoServiceProvider MD5 = new MD5CryptoServiceProvider())//use MD5CryptoServiceProvider to encrypt
            {
                byte[] keys = MD5.ComputeHash(UTF32Encoding.UTF8.GetBytes(hash));//convert the hash value into bytes
                using (TripleDESCryptoServiceProvider triple = new TripleDESCryptoServiceProvider() {Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7})//create encryption provider for encryption
                {
                    ICryptoTransform transform = triple.CreateEncryptor();//create encryptor
                    byte[] results = transform.TransformFinalBlock(data, 0, data.Length);//encrypt string in bytes format
                    string encrypted = Convert.ToBase64String(results);//change string back to normal formatting
                    encryptedToReturn = encrypted;//store result in string that will be returned
                }

            }
            return encryptedToReturn;//return encrypted string

        }

        public static string Decrypt(string toDecrypt)//function used to decrypt strings
        {
            string hash = "Alexandra";//create hash key - same as above
            string decryptedToReturn = "";//will store decrypted string
            byte[] data = Convert.FromBase64String(toDecrypt);//convert string that will be decrypted into bytes
            using (MD5CryptoServiceProvider MD5 = new MD5CryptoServiceProvider())//use MD5CryptoServiceProvider to decrypt
            {
                byte[] keys = MD5.ComputeHash(UTF32Encoding.UTF8.GetBytes(hash));//convert the hash value into bytes
                using (TripleDESCryptoServiceProvider triple = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })//create dencryption provider for dencryption
                {
                    ICryptoTransform transform = triple.CreateDecryptor();//create dencryptor
                    byte[] results = transform.TransformFinalBlock(data, 0, data.Length);//dencrypt string in bytes format
                    string decrypted = UTF8Encoding.UTF8.GetString(results);//change string back to normal formatting
                    decryptedToReturn = decrypted;//store result in string that will be returned
                }

            }
            return decryptedToReturn;//return dencrypted string
        }



    }
}
