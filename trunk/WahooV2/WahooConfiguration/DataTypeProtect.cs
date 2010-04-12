using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace WahooConfiguration
{
    public class DataTypeProtect
    {
        public static int ProtectInt32(object data)
        {
            return ProtectInt32(data, -1);
        }

        public static object ProtectDataType(object data, Type type, object defaultValue)
        {
            return ProtectDataType(data, type, defaultValue, System.Globalization.CultureInfo.CurrentCulture);
        }

        public static object ProtectDataType(object data, Type type, object defaultValue, IFormatProvider provider)
        {
            if (data == null)
                return defaultValue;
            try
            {
                return Convert.ChangeType(data, type, provider);
            }
            catch
            {
                return defaultValue;
            }
        }

        public static string ProtectString(object data)
        {
            return ProtectDataType(data, typeof(string), string.Empty).ToString();
        }

        public static int ProtectInt32(object data, int defaultValue)
        {
            return (int)ProtectDataType(data, typeof(int), defaultValue);
        }

        public static long ProtectInt64(object data, long defaultValue)
        {
            return (long)ProtectDataType(data, typeof(long), defaultValue);
        }

        public static bool ProtectBoolean(object data, bool defaultValue)
        {
            return (bool)ProtectDataType(data, typeof(bool), defaultValue);
        }

        public static double ProtectDouble(object data, double defaultValue)
        {
            return (double)ProtectDataType(data, typeof(double), defaultValue);
        }

        public static decimal? ProtectDecimal(object data, decimal? defaultValue)
        {
            return (decimal?)ProtectDataType(data, typeof(decimal), defaultValue);
        }

        public static decimal ProtectDecimal(object data, decimal defaultValue)
        {
            return (decimal)ProtectDataType(data, typeof(decimal), defaultValue);
        }


        public static DateTime ProtectDateTime(object data, string format, DateTime defaultValue)
        {
            try
            {
                return DateTime.ParseExact(data.ToString(), format, System.Globalization.CultureInfo.CurrentCulture);
            }
            catch
            {
                return defaultValue;
            }
        }

        public static DateTime ProtectDateTime(object data, DateTime defaultValue)
        {
            return (DateTime)ProtectDataType(data, typeof(DateTime), defaultValue);
        }

        public static DateTime ProtectDateTime(DateTime baseDateTime, TimeSpan offset)
        {
            DateTime dt = baseDateTime;
            dt = dt.AddMilliseconds(offset.TotalMilliseconds);

            return dt;
        }

        public static byte ProtectByte(object data, byte defaultValue)
        {
            return (byte)ProtectDataType(data, typeof(byte), defaultValue);
        }

        private static bool IsEmpty(object data)
        {
            if (data == null || data == DBNull.Value)
                return true;
            if (data.ToString().Length <= 0)
                return true;
            return false;
        }

        public static bool IsEmpty(params object[] data)
        {
            foreach (object var in data)
                if (!IsEmpty(var))
                    return false;
            return true;
        }

        public static bool IsNotEmpty(params object[] data)
        {
            foreach (object var in data)
                if (IsEmpty(var))
                    return false;
            return true;
        }

        public static bool ValidateString(string str, string expression)
        {
            Regex reg = new Regex(expression);
            Match m = reg.Match(str);
            return m.Value == str;
        }

        public static string FormatData(object data, string format)
        {
            if (data == null) return string.Empty;
            if (data is IFormattable)
                return ((IFormattable)data).ToString(format, null);
            else
                return data.ToString();
        }

        public static string ShortenLongString(string inputString, int MaxLength, bool insertThreeDots)
        {
            if (insertThreeDots)
                MaxLength -= 3;

            if (inputString.Length <= MaxLength)
                return inputString;

            string[] tmp = ShortenLongString(inputString, MaxLength, 0);
            return tmp[0] + (insertThreeDots ? "..." : "");
        }

        public static string[] ShortenLongString(string inputString, int LeftLength, int RightLength)
        {
            string[] arrRes = new string[2];

            LeftLength = Math.Min(LeftLength, inputString.Length);
            RightLength = Math.Min(RightLength, inputString.Length - LeftLength);

            arrRes[0] = inputString.Substring(0, LeftLength);
            if (LeftLength > 0)
            {
                if (inputString[LeftLength] != ' ' && inputString[LeftLength] != '\n')
                {
                    int TrueIndex = Math.Max(inputString.LastIndexOf(" ", LeftLength), inputString.LastIndexOf("\n", LeftLength));
                    if (TrueIndex > 0)
                        arrRes[0] = inputString.Substring(0, TrueIndex);
                }
                inputString = inputString.Remove(0, arrRes[0].Length);
            }

            arrRes[1] = inputString.Remove(0, inputString.Length - RightLength);
            if (RightLength > 0)
            {
                int BeginIndex = inputString.Length - RightLength;
                if (inputString[BeginIndex - 1] != ' ' && inputString[BeginIndex - 1] != '\n')
                {
                    int TrueIndex = Math.Max(inputString.LastIndexOf(" ", BeginIndex), inputString.IndexOf("\n", BeginIndex));
                    if (TrueIndex > 0)
                        arrRes[1] = inputString.Remove(0, TrueIndex);
                }
            }

            return arrRes;
        }

        public static string WrapText(string inputText, int lineLength)
        {
            string[] texts = inputText.Split(new char[] { '\n' });
            StringBuilder bld = new StringBuilder();
            foreach (string text in texts)
            {
                string tmp = text;
                while (tmp.Length > 0)
                {
                    string shorten = ShortenLongString(tmp, lineLength, false);
                    bld.Append(shorten + "\n");
                    tmp = tmp.Remove(0, shorten.Length);
                }
            }

            return bld.ToString();
        }
        public int ConvertDBValueToInt32(object value)
        {
            return (DBNull.Value != value) ? Convert.ToInt32(value) : 0;
        }
    }
}
