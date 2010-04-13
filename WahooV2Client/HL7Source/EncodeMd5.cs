using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;

namespace HL7Source
{
    public class EncodeMd5
    {
        public static string EncodeString(string strEncode)
        {
            strEncode = strEncode.ToUpper();
            //Declarations
            Byte[] originalBytes;
            Byte[] encodedBytes;
            MD5 md5;

            //Instantiate MD5CryptoServiceProvider, get bytes for original password and compute hash (encoded password)
            md5 = new MD5CryptoServiceProvider();
            originalBytes = ASCIIEncoding.Default.GetBytes(strEncode);
            encodedBytes = md5.ComputeHash(originalBytes);

            //Convert encoded bytes back to a 'readable' string
            return BitConverter.ToString(encodedBytes);
        }
    }
}
