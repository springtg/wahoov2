using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace HL7Source
{
    public class Message
    {
        public const string MessageTableMappingName = "MSG";
        public const string MessageIdMappingName = "MessageId";
        public const string MessageValueMappingName = "Value";
        public static string GetMessageById(string messageId)
        {
            try
            {
                //1.Loading message file
                DataSet ds = new DataSet();
                ds.ReadXml(AppDomain.CurrentDomain.BaseDirectory + "\\Resource\\Message.xml");
                //2.Get message by ID
                DataRow[] msgs = ds.Tables[Message.MessageTableMappingName].Select(MessageIdMappingName + "='" + messageId + "'");
                //3.Read message content if found
                if (msgs.Length > 0)
                {
                    //3.2. Create message structure and return
                    if (msgs[0][MessageValueMappingName] != System.DBNull.Value)
                    {
                        return msgs[0][MessageValueMappingName].ToString();
                    }
                    else
                    {
                        return "";
                    }
                }
                else
                {
                    //3.1. If message is not defined yet then return null
                    return "";
                }
            }
            catch
            {
                //4.Exception handling
                throw;
            }
        }
    }
}

