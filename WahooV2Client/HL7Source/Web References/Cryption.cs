using System;
using System.Collections.Generic;
using System.Text;

namespace HL7Source
{
    public class Cryption
    {
        //This function for encript a string when have string and key
        public static string EncryptString(string strInput, string strKey)
        {
            string kq = "";
            if (strKey.Length > 0 && strInput.Length > 0)
            {
                byte[] key = GetBytes(strKey).Clone() as byte[];
                BlowFish bl = new BlowFish(key);
                byte[] plain = GetBytes(strInput).Clone() as byte[];
                byte[] tmp = FixBytes(plain);
                //Encrypt string
                kq = GetString(bl.Encipher(tmp));
            }
            return kq;
        }

        //This function for encript file source and save to file dest
        public static Boolean EncryptFile(string strSource, string strDest, string strKey)
        {
            if (strKey.Length > 0)
            {
                try
                {
                    byte[] key = GetBytes(strKey).Clone() as byte[];
                    BlowFish bl = new BlowFish(key);
                    //Encrypt file
                    bl.Encipher(strSource, strDest);
                    return true;
                }
                catch (Exception ex)
                {
                    //Common.Log.Write(ex);
                    return false;
                }
            }
            return false;
        }

        //This function for decript a string
        public static string DecryptString(string strInput, string strKey)
        {
            string kq = "";
            if (strKey.Length > 0 && strInput.Length > 0)
            {
                byte[] key = GetBytes(strKey).Clone() as byte[];
                BlowFish bl = new BlowFish(key);
                byte[] plain = GetBytes(strInput).Clone() as byte[];
                //Decrypt string
                kq = GetString(bl.Decipher(plain));
            }
            return kq;
        }

        //This function for decript file source and save to file dest
        public static Boolean DecryptFile(string strSource, string strDest, string strKey)
        {
            if (strKey.Length > 0)
            {
                try
                {
                    byte[] key = GetBytes(strKey).Clone() as byte[];
                    BlowFish bl = new BlowFish(key);
                    //Decrypt file
                    bl.Decipher(strSource, strDest);
                    return true;
                }
                catch (Exception ex)
                {
                    //Common.Log.Write(ex);
                    return false;
                }
            }
            return false;
        }
        //Change string to array bytes
        private static byte[] GetBytes(string s)
        {
            byte[] bs = new byte[s.Length];
            for (int i = 0; i < s.Length; i++)
                bs[i] = (byte)s[i];
            return bs;
        }
        //--- Fix the bytes length to multiple of 8.
        private static byte[] FixBytes(byte[] bs)
        {
            int len = (bs.Length / 8 + 1) * 8;
            byte[] tmp = new byte[len];
            for (int i = 0; i < len; i++)
            {
                if (i < bs.Length) tmp[i] = bs[i];
                else tmp[i] = 0x20;
            }
            return tmp;
        }
        //Change array byte to string
        private static string GetString(byte[] bs)
        {
            string s = "";
            try
            {
                for (int i = 0; i < bs.Length; i++)
                    s += (char)bs[i];
            }
            catch 
            {
                
            }
            
            return s;
        }
    }
}
