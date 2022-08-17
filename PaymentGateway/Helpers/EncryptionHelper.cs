using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.OpenSsl;
using Org.BouncyCastle.Security;
using System.Security.Cryptography;
using System.Text;

namespace PaymentGateway.Helpers
{

    public interface IEncryptionHelper
    {
        string Encrypt(string text);
        string Decrypt(string encrypted);
        string GetEncryptionKey();
    }
    public class EncryptionHelper : IEncryptionHelper
    {
        #region Service Initilization
        private string key = "b14ca5898a4e4142aace2ea2143a2410";
        #endregion
        public EncryptionHelper()
        {
            
        }

        /// <summary>
        /// Encrypt data using AES Algo
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public string Encrypt(string text)
        {
            byte[] iv = new byte[16];
            byte[] array;
            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = iv;
                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter streamWriter = new StreamWriter((Stream)cryptoStream))
                        {
                            streamWriter.Write(text);
                        }
                        array = memoryStream.ToArray();
                    }
                }
            }
            return Convert.ToBase64String(array);
            
        }
        /// <summary>
        /// Decrypt Text using AES
        /// </summary>
        /// <param name="encrypted"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public string Decrypt(string cipherText)
        {

        byte[] iv = new byte[16];
        byte[] buffer = Convert.FromBase64String(cipherText);
        using (Aes aes = Aes.Create())
        {
            aes.Key = Encoding.UTF8.GetBytes(key);//I have already defined "Key" in the above EncryptString function
            aes.IV = iv;
            ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
            using (MemoryStream memoryStream = new MemoryStream(buffer))
            {
                using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, decryptor, CryptoStreamMode.Read))
                {
                    using (StreamReader streamReader = new StreamReader((Stream)cryptoStream))
                    {
                        return streamReader.ReadToEnd();
                    }
                }
            }
        }
    }

        /// <summary>
        /// Return Encryption key
        /// </summary>
        /// <returns></returns>
        public string GetEncryptionKey()
        {
            return key;
        }

        #region Helper Methods

        #endregion
    }
}
