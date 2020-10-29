using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace WxrNet
{
    [Serializable]
    public class Category
    {
        [XmlAttributeAttribute("domain")]
        public string Domain;

        [XmlAttributeAttribute("nicename")]
        public string Nicename { get; set; }

        [XmlIgnore]
        public string Content { get; set; }
        
        [XmlText]
        public XmlNode[] CDataContent
        {
            get
            {
                var dummy = new XmlDocument();
                return new XmlNode[] { dummy.CreateCDataSection(Content) };
            }
            set
            {
                if (value == null) {
                    Content = null;
                    return;
                }

                if (value.Length != 1) {
                    throw new InvalidOperationException(
                        String.Format(
                            "Invalid array length {0}", value.Length));
                }

                Content = value[0].Value;
            }
        }
    }
}