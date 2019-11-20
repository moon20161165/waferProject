using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace WOMS
{
    class AES256_PW
    {
        public static string EncryptString(string InputText)
        {
            string EncryptedData = "";
            try
            {
                RijndaelManaged RijndaelCipher = new RijndaelManaged();

                byte[] PlainText = Encoding.UTF8.GetBytes(InputText);
                byte[] Salt = Encoding.UTF8.GetBytes("20703SJGOW".Length.ToString());

                PasswordDeriveBytes SecretKey = new PasswordDeriveBytes("20703SJGOW", Salt);
                ICryptoTransform Encryptor = RijndaelCipher.CreateEncryptor(SecretKey.GetBytes(32), SecretKey.GetBytes(16));
                MemoryStream memoryStream = new MemoryStream();
                CryptoStream cryptoStream = new CryptoStream(memoryStream, Encryptor, CryptoStreamMode.Write);
                cryptoStream.Write(PlainText, 0, PlainText.Length);

                cryptoStream.FlushFinalBlock();

                byte[] CipherBytes = memoryStream.ToArray();

                memoryStream.Close();
                cryptoStream.Close();

                EncryptedData = Convert.ToBase64String(CipherBytes);
            }
            catch
            {
                Console.WriteLine("Encrypt error");
            }
            return EncryptedData;
        }
        public static string DecryptString(string InputText)
        {
            string DecryptedData = "";
            try
            {
                RijndaelManaged RijndaelCipher = new RijndaelManaged();
                byte[] EncryptedData = Convert.FromBase64String(InputText);
                byte[] Salt = Encoding.UTF8.GetBytes("20703SJGOW".Length.ToString());
                PasswordDeriveBytes SecretKey = new PasswordDeriveBytes("20703SJGOW", Salt);
                ICryptoTransform Decrytor = RijndaelCipher.CreateDecryptor(SecretKey.GetBytes(32), SecretKey.GetBytes(16));
                MemoryStream memoryStream = new MemoryStream(EncryptedData);
                CryptoStream cryptoStream = new CryptoStream(memoryStream, Decrytor, CryptoStreamMode.Read);
                byte[] PlainText = new byte[EncryptedData.Length];
                int DecryptedCount = cryptoStream.Read(PlainText, 0, PlainText.Length);
                memoryStream.Close();
                cryptoStream.Close();

                DecryptedData = Encoding.UTF8.GetString(PlainText, 0, DecryptedCount);
            }
            catch
            {
                Console.WriteLine("Decrypt error");
            }
            return DecryptedData;
        }
    }
}
