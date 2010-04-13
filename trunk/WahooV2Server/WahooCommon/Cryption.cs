using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Security.Cryptography;
using System.Collections;

namespace WahooCommon
{
    public class Cryption
    {
        /// <summary>
        /// This function for encript a string when have string and key
        /// </summary>
        /// <param name="strInput"></param>
        /// <param name="strKey"></param>
        /// <returns></returns>
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

        /// <summary>
        /// This function for encript file source and save to file dest
        /// </summary>
        /// <param name="strSource"></param>
        /// <param name="strDest"></param>
        /// <param name="strKey"></param>
        /// <returns></returns>
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

        /// <summary>
        /// This function for decript a string
        /// </summary>
        /// <param name="strInput"></param>
        /// <param name="strKey"></param>
        /// <returns></returns>
        public static string DecryptString(string strInput, string strKey)
        {
            string kq = "";
            try
            {
                if (strKey.Length > 0 && strInput.Length > 0)
                {
                    byte[] key = GetBytes(strKey).Clone() as byte[];
                    BlowFish bl = new BlowFish(key);
                    byte[] plain = GetBytes(strInput).Clone() as byte[];
                    //Decrypt string
                    kq = GetString(bl.Decipher(plain));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return kq;
        }

        /// <summary>
        /// This function for decript file source and save to file dest
        /// </summary>
        /// <param name="strSource"></param>
        /// <param name="strDest"></param>
        /// <param name="strKey"></param>
        /// <returns></returns>
        public static Boolean DecryptFile(string strSource, string strDest, string strKey)
        {
            if (!File.Exists(strSource))
            {
                return false;
            }
            if (strKey.Length > 0)
            {
                try
                {
                    byte[] key = GetBytes(strKey).Clone() as byte[];
                    if (!File.Exists(strDest))
                    {
                        File.Create(strDest);
                    }
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
        /// <summary>
        /// Change string to array bytes
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        private static byte[] GetBytes(string s)
        {
            byte[] bs = new byte[s.Length];
            for (int i = 0; i < s.Length; i++)
                bs[i] = (byte)s[i];
            return bs;
        }
        /// <summary>
        /// Fix the bytes length to multiple of 8.
        /// </summary>
        /// <param name="bs"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Change array byte to string
        /// </summary>
        /// <param name="bs"></param>
        /// <returns></returns>
        private static string GetString(byte[] bs)
        {
            string s = "";
            for (int i = 0; i < bs.Length; i++)
                s += (char)bs[i];
            return s;
        }
        /// <summary>
        /// Decrypt file with xml format
        /// </summary>
        /// <param name="sourceFile"></param>
        /// <returns></returns>
        public static Boolean DecryptFileXmlFormat(string sourceFile)
        {
            try
            {
                RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
                StreamReader sr = new StreamReader(sourceFile);
                string data = sr.ReadToEnd();
                if (sr != null)
                {
                    sr.Close();
                }
                int startIndex = data.IndexOf("<BlowfishKey>");
                startIndex += 13;
                int endIndex = data.IndexOf("</BlowfishKey>");
                string strKey = data.Substring(startIndex, endIndex - startIndex);
                byte[] getpassword = Convert.FromBase64String(strKey);

                sr = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + @"\Resource\PrivateKeyFile\privateKey.xml");
                string publicPrivateKeyXML = sr.ReadToEnd();
                rsa.FromXmlString(publicPrivateKeyXML);
                if (sr != null)
                {
                    sr.Close();
                }
                //read ciphertext, decrypt it to plaintext
                byte[] plain = rsa.Decrypt(getpassword, false);
                string blowfishKey = System.Text.Encoding.UTF8.GetString(plain);

                //Delete blowfishKey from source file
                string strDelete = data.Remove(data.IndexOf("<BlowfishKey>"));
                if (File.Exists(sourceFile))
                {
                    File.Delete(sourceFile);
                }
                string strData = Cryption.DecryptString(strDelete, blowfishKey);
                if (strData == "")
                {
                    return false;
                }
                StreamWriter sw = File.AppendText(sourceFile);
                sw.Write(strData);
                if (sw != null)
                {
                    sw.Close();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// Decrypt file with no xml format
        /// </summary>
        /// <param name="sourceFile"></param>
        /// <param name="keyBlowFish"></param>
        /// <returns></returns>
        public static Boolean DecryptFileNoXmlFormat(string sourceFile, string keyBlowFish)
        {
            try
            {
                string tempFile = Path.GetDirectoryName(sourceFile) + "\\" + Path.GetFileNameWithoutExtension(sourceFile) + "_temp" + Path.GetExtension(sourceFile);
                //Create temp file
                StreamWriter sw = File.AppendText(tempFile);
                if (sw != null)
                {
                    sw.Close();
                }
                if (Cryption.DecryptFile(sourceFile, tempFile, keyBlowFish))
                {
                    //Delete source file
                    if (File.Exists(sourceFile))
                    {
                        File.Delete(sourceFile);
                    }
                    //Move file which is decrypted to source file
                    File.Move(tempFile, sourceFile);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// Encrypt folder with RSA and Blowfish
        /// </summary>
        /// <param name="sourceFolder"></param>
        /// <param name="destFolder"></param>
        /// <param name="publicKeyXml"></param>
        /// <param name="blowfishKey"></param>
        /// <returns></returns>
        public static ArrayList EncryptFolderToUpload(string sourceFolder, string destFolder, string keyBlowFish)
        {
            //List of files which is encrypted success
            ArrayList result = new ArrayList();
            try
            {
                if (!Directory.Exists(sourceFolder))
                {
                    return result;
                }
                string[] files = Directory.GetFiles(sourceFolder);
                Boolean haveEncryptFile = false;
                foreach (string fileToEncrypt in files)
                {
                    try
                    {
                        //Encrypt file
                        string tempFile = destFolder + @"\" + Path.GetFileName(fileToEncrypt);
                        if (Cryption.EncryptFile(fileToEncrypt, tempFile, keyBlowFish))
                        {
                            //Delete source file
                            if (File.Exists(fileToEncrypt))
                            {
                                File.Delete(fileToEncrypt);
                            }
                        }
                        haveEncryptFile = true;
                        result.Add(fileToEncrypt);
                    }
                    catch
                    {

                    }
                }
                return result;
            }
            catch
            {
                return result;
            }
        }
    }
}
