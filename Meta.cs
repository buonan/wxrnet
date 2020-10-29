using System;
using System.Globalization;
using System.Xml;
using System.Xml.Serialization;

namespace WxrNet
{
    [Serializable]
    public class Meta
    {
        [XmlElement("meta_key")]
        public string Key { get; set; }

        [XmlElement("meta_value")]
        public XmlCDataSection Value { get; set; }
    }
}