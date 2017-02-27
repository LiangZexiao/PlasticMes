using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Admin.DBUtility
{
    public class Cryption
    {
        /// <summary>
        /// 加密方法
        /// </summary>
        /// <param name="strText">加密字串</param>
        /// <param name="strEncrKey">加密密钥</param>
        /// <returns></returns>
        public String Encrypt(String strText, String strEncrKey)
        {
            Byte[] byKey = { };
            Byte[] IV = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };
            try
            {
                byKey = System.Text.Encoding.UTF8.GetBytes(strEncrKey.Substring(0, 8));
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                Byte[] inputByteArray = Encoding.UTF8.GetBytes(strText);
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(byKey, IV), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                return Convert.ToBase64String(ms.ToArray());
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        /// <summary>
        /// 解密方法
        /// </summary>
        /// <param name="strText">解密字串</param>
        /// <param name="strDecrKey">解密密钥</param>
        /// <returns></returns>
        public String Decrypt(String strText, String strDecrKey)
        {
            Byte[] byKey = { };
            Byte[] IV = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };
            Byte[] inputByteArray = new byte[strText.Length];
            try
            {
                byKey = System.Text.Encoding.UTF8.GetBytes(strDecrKey.Substring(0, 8));
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                inputByteArray = Convert.FromBase64String(strText);
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(byKey, IV), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                System.Text.Encoding encoding = System.Text.Encoding.UTF8;
                return encoding.GetString(ms.ToArray());
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }



        private void SelectAppSetString()
        {
            Hashtable ht = new Hashtable();
            ht.Add("one", "The");
            ht.Add("two", "quick");
            ht.Add("three", "brown");
            ht.Add("four", "fox");

            Console.WriteLine("The Hashtable contains the following:");
            PrintKeysAndValues(ht); 
        }



        public static void PrintKeysAndValues(Hashtable myHT) 
        { 
            foreach (string s in myHT.Keys)
                Console.WriteLine(s);

            Console.WriteLine(" -KEY- -VALUE-");
            foreach (DictionaryEntry de in myHT)
            Console.WriteLine(" {0}: {1}", de.Key, de.Value); 

            Console.WriteLine(); 
        }



    }
}
