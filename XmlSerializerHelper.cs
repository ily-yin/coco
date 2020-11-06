using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Server.Helper
{
    public static class XmlSerializerHelper
    {
        /// <summary>
        /// 实体转xml
        /// </summary>
        /// <typeparam name="T">实体</typeparam>
        /// <param name="obj">实体</param>
        /// <param name="settings">编码格式设置</param>
        /// <param name="spaces">命令空间 例：	sc:ShoppingCartAttachment</param>
        /// <returns></returns>
        public static string XmlSerialize<T>(T obj, XmlWriterSettings settings, XmlSerializerNamespaces spaces)
        {
            try
            {
                using (StringWriter sw = new StringWriter())
                {
                    Type t = obj.GetType();

                    XmlWriter xmlWriter = XmlWriter.Create(sw, settings);

                    XmlSerializer serializer = new XmlSerializer(obj.GetType());

                    serializer.Serialize(xmlWriter, obj, spaces);
                    sw.Close();
                    return sw.ToString();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        /// <summary>
        /// xml转实体
        /// </summary>
        /// <typeparam name="T">实体</typeparam>
        /// <param name="strXML">xml字符串</param>
        /// <returns></returns>

        public static T DESerializer<T>(string strXML) where T : class
        {
            try
            {
                using (StringReader sr = new StringReader(strXML))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(T));
                    return serializer.Deserialize(sr) as T;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }

}
