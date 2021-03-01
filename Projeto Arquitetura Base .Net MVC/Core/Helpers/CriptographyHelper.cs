using System;
using System.IO;
using System.Configuration;
using System.Web;
using System.Xml;
using System.Text;
using System.Security;
using System.Security.Cryptography;

namespace Core.Helpers
{

    /// <summary>
    /// Class with Criptography Methods
    /// </summary>
    internal class CriptographyHelper
    {

        /// <summary>
        /// Criptography Private Key
        /// </summary>
        private static string PRIVATE_KEY = "14CC7B626792AEB432A19CCE4E4D5DFC91C4B4DA7E886D7773895AE3C1B1E77563DF94DE6D74CB937C1662ECE77B676ED179EFB35F5F19E23B86";

        /// <summary>
        /// Decript Method
        /// </summary>
        /// <param name="input">Input string</param>
        /// <returns>Decripted string</returns>
        internal static string Decript(string input)
        {
            byte[] key = { };
            byte[] model = { 10, 20, 30, 40, 50, 60, 70, 80 };
            byte[] data = new byte[input.Length];
            try
            {
                key = Encoding.UTF8.GetBytes(PRIVATE_KEY.Substring(0, 8));
                DESCryptoServiceProvider service = new DESCryptoServiceProvider();
                data = Convert.FromBase64String(input.Replace(" ", "+"));
                MemoryStream memory = new MemoryStream();
                CryptoStream stream = new CryptoStream(memory, service.CreateDecryptor(key, model), CryptoStreamMode.Write);
                stream.Write(data, 0, data.Length);
                stream.FlushFinalBlock();
                Encoding encoding = Encoding.UTF8;
                return encoding.GetString(memory.ToArray());
            }
            catch
            {
                return (string.Empty);
            }
        }

        /// <summary>
        /// Encript Method
        /// </summary>
        /// <param name="input">Input string</param>
        /// <returns>Encripted string</returns>
        internal static string Encript(string input)
        {
            byte[] key = { };
            byte[] model = { 10, 20, 30, 40, 50, 60, 70, 80 };
            byte[] data;

            try
            {
                key = Encoding.UTF8.GetBytes(PRIVATE_KEY.Substring(0, 8));
                DESCryptoServiceProvider service = new DESCryptoServiceProvider();
                data = Encoding.UTF8.GetBytes(input);
                MemoryStream memory = new MemoryStream();
                CryptoStream stream = new CryptoStream(memory, service.CreateEncryptor(key, model), CryptoStreamMode.Write);
                stream.Write(data, 0, data.Length);
                stream.FlushFinalBlock();
                return Convert.ToBase64String(memory.ToArray());
            }
            catch
            {
                return (string.Empty);
            }
        }
    }
}
