using System;
using System.Globalization;
using System.Xml;
using System.Xml.Serialization;

namespace WxrNet
{
    [Serializable]
    public class Attachment
    {
        [XmlElement("type", Namespace = "http://wordpress.org/export/1.0/")]
        public string Type { get; set; }

        [XmlElement("attachment_url", Namespace = "http://wordpress.org/export/1.0/")]
        public XmlCDataSection Url { get; set; }

        [XmlElement(ElementName = "status", Namespace = "http://wordpress.org/export/1.0/")]
        public Status Status { get; set; }
    }
}