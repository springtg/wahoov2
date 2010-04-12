using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace HL7Source
{
    public class Config
    {
        #region Private Members
        private string m_config_file;
        #endregion

        #region Constant
        public const string ConnectionStringKey = "CONNECTION_STRING";
        #endregion

        /// <summary>
        /// 
        /// </summary>
        public Config(string config)
        {
            this.m_config_file = config;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string ReadSetting(string key)
        {
            try
            {
                XmlDocument doc = this.LoadingConfiguration();
                XmlNode node = doc.SelectSingleNode("//appSettings");
                if (node != null)
                {
                    XmlElement em = (XmlElement)node.SelectSingleNode(string.Format("//add[@key='{0}']", key));
                    return em.GetAttribute("value");
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private XmlDocument LoadingConfiguration()
        {
            try
            {
                XmlDocument doc;
                doc = new XmlDocument();
                doc.Load(this.m_config_file);
                return doc;
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool WriteSetting(string key, string value)
        {
            try
            {
                XmlDocument doc = this.LoadingConfiguration();
                XmlNode node = doc.SelectSingleNode("//appSettings");
                if (node != null)
                {
                    XmlElement em = (XmlElement)node.SelectSingleNode(string.Format("//add[@key='{0}']", key));
                    if (em != null)
                    {
                        em.SetAttribute("value", value);
                    }
                    else
                    {
                        em = doc.CreateElement("add");
                        em.SetAttribute("key", key);
                        em.SetAttribute("value", value);
                        node.AppendChild(em);
                    }
                    doc.Save(this.m_config_file);
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
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool RemoveSetting(string key)
        {
            try
            {
                XmlDocument doc = this.LoadingConfiguration();
                XmlNode node = doc.SelectSingleNode("//appSettings");
                if (node != null)
                {
                    XmlNode cnode = node.SelectSingleNode(string.Format("//add[@key='{0}']", key));
                    if (cnode != null)
                    {
                        node.RemoveChild(cnode);
                        doc.Save(this.m_config_file);
                        return true;
                    }
                    else
                        return false;
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
    }
}
