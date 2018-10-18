// developer mortaza ghahremani
// email: mortaza.ghahremani@gmail.com
// produced in august 2014
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace ISE.Framework.Utility.Utils
{
    
    public static class Encryption    
    {
        private const string MyKey = "iseiseise";

        private static string AlgorithmName = "TripleDES";

        private static Rfc2898DeriveBytes GetKey()
        {                        
            byte[] salt =StrToByteArray("01234567");
            var key = new Rfc2898DeriveBytes(MyKey, salt);            
            return key;
        }
        private static Rfc2898DeriveBytes GetKey(string key)
        {
            byte[] salt = StrToByteArray("01234567");
            var rkey = new Rfc2898DeriveBytes(key, salt);
            return rkey;
        }
        public static byte[] StrToByteArray(string str)
        {
            System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();
            return encoding.GetBytes(str);
        }
        public static string EncryptData(string ClearData)
        {
            // Convert string ClearData to byte array
            byte[] ClearData_byte_Array = Encoding.UTF8.GetBytes(ClearData);

            // Now Create The Algorithm
            SymmetricAlgorithm Algorithm = SymmetricAlgorithm.Create(AlgorithmName);
            Algorithm.Key = GetKey().GetBytes(Algorithm.KeySize / 8);

            // Encrypt information
            MemoryStream Target = new MemoryStream();

            // Append IV
            Algorithm.GenerateIV();
            Target.Write(Algorithm.IV, 0, Algorithm.IV.Length);

            // Encrypt Clear Data
            CryptoStream cs = new CryptoStream(Target, Algorithm.CreateEncryptor(), CryptoStreamMode.Write);
            cs.Write(ClearData_byte_Array, 0, ClearData_byte_Array.Length);
            cs.FlushFinalBlock();

            // Output
            byte[] Target_byte_Array = Target.ToArray();
            string Target_string = Convert.ToBase64String(Target_byte_Array);
            return Target_string;
        }

        public static string DecryptData(string EncryptedData)
        {
            byte[] EncryptedData_byte_Array = Convert.FromBase64String(EncryptedData);

            // Now Create The Algorithm
            SymmetricAlgorithm Algorithm = SymmetricAlgorithm.Create(AlgorithmName);
            Algorithm.Key = Algorithm.Key = GetKey().GetBytes(Algorithm.KeySize / 8);

            // Decrypt information
            MemoryStream Target = new MemoryStream();

            // Read IV
            int ReadPos = 0;
            byte[] IV = new byte[Algorithm.IV.Length];
            Array.Copy(EncryptedData_byte_Array, IV, IV.Length);
            Algorithm.IV = IV;
            ReadPos += Algorithm.IV.Length;

            // Decrypt Encrypted Data
            CryptoStream cs = new CryptoStream(Target, Algorithm.CreateDecryptor(), CryptoStreamMode.Write);
            cs.Write(EncryptedData_byte_Array, ReadPos, EncryptedData_byte_Array.Length - ReadPos);
            cs.FlushFinalBlock();

            // Output
            byte[] Target_byte_Array = Target.ToArray();
            string Target_string = Encoding.UTF8.GetString(Target_byte_Array);
            return Target_string;
        }
        public static string EncryptData(string ClearData,string key)
        {
            // Convert string ClearData to byte array
            byte[] ClearData_byte_Array = Encoding.UTF8.GetBytes(ClearData);

            // Now Create The Algorithm
            SymmetricAlgorithm Algorithm = SymmetricAlgorithm.Create(AlgorithmName);
            Algorithm.Key = GetKey(key).GetBytes(Algorithm.KeySize / 8);
            
            // Encrypt information
            MemoryStream Target = new MemoryStream();

            // Append IV
            Algorithm.GenerateIV();
            Target.Write(Algorithm.IV, 0, Algorithm.IV.Length);

            // Encrypt Clear Data
            CryptoStream cs = new CryptoStream(Target, Algorithm.CreateEncryptor(), CryptoStreamMode.Write);
            cs.Write(ClearData_byte_Array, 0, ClearData_byte_Array.Length);
            cs.FlushFinalBlock();

            // Output
            byte[] Target_byte_Array = Target.ToArray();
            string Target_string = Convert.ToBase64String(Target_byte_Array);
            return Target_string;
        }

        public static string DecryptData(string EncryptedData, string key)
        {
            byte[] EncryptedData_byte_Array = Convert.FromBase64String(EncryptedData);

            // Now Create The Algorithm
            SymmetricAlgorithm Algorithm = SymmetricAlgorithm.Create(AlgorithmName);
            Algorithm.Key = Algorithm.Key = GetKey(key).GetBytes(Algorithm.KeySize / 8);

            // Decrypt information
            MemoryStream Target = new MemoryStream();

            // Read IV
            int ReadPos = 0;
            byte[] IV = new byte[Algorithm.IV.Length];
            Array.Copy(EncryptedData_byte_Array, IV, IV.Length);
            Algorithm.IV = IV;
            ReadPos += Algorithm.IV.Length;

            // Decrypt Encrypted Data
            CryptoStream cs = new CryptoStream(Target, Algorithm.CreateDecryptor(), CryptoStreamMode.Write);
            cs.Write(EncryptedData_byte_Array, ReadPos, EncryptedData_byte_Array.Length - ReadPos);
            cs.FlushFinalBlock();

            // Output
            byte[] Target_byte_Array = Target.ToArray();
            string Target_string = Encoding.UTF8.GetString(Target_byte_Array);
            return Target_string;
        }

     
           
            private static byte[] IV = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xab, 0xcd, 0xef };
            public static string DecryptUrl(string stringToDecrypt, string Key)
            {
                byte[] inputByteArray = new byte[stringToDecrypt.Length + 1];
                try
                {
                    byte[] key = System.Text.Encoding.UTF8.GetBytes(Key);
                    DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                    inputByteArray = Convert.FromBase64String(stringToDecrypt);
                    MemoryStream ms = new MemoryStream();
                    CryptoStream cs = new CryptoStream(ms,
                      des.CreateDecryptor(key, IV), CryptoStreamMode.Write);
                    cs.Write(inputByteArray, 0, inputByteArray.Length);
                    cs.FlushFinalBlock();
                    System.Text.Encoding encoding = System.Text.Encoding.UTF8;
                    return encoding.GetString(ms.ToArray());
                }
                catch (Exception e)
                {
                    return e.Message;
                }
            }

            public static string EncryptUrl(string stringToEncrypt, string Key)
            {
                try
                {
                    byte[] key = System.Text.Encoding.UTF8.GetBytes(Key);
                    DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                    byte[] inputByteArray = Encoding.UTF8.GetBytes(stringToEncrypt);
                    MemoryStream ms = new MemoryStream();
                    CryptoStream cs = new CryptoStream(ms,
                      des.CreateEncryptor(key, IV), CryptoStreamMode.Write);
                    cs.Write(inputByteArray, 0, inputByteArray.Length);
                    cs.FlushFinalBlock();
                    return Convert.ToBase64String(ms.ToArray());
                }
                catch (Exception e)
                {
                    return e.Message;
                }
            }
     

    }
}
