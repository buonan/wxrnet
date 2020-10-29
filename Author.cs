using System;
using System.Globalization;
using System.Xml;
using System.Xml.Serialization;

namespace WxrNet
{
    [Serializable]
    public class Author
    {
        [XmlElement("author_id")]
        public string Id { get; set; }

        [XmlElement("author_login")]
        public string Login { get; set; }

        [XmlElement("author_email")]
        public string Email { get; set; }

        [XmlElement("author_display_name")]
        public XmlCDataSection DisplayName { get; set; }

        [XmlElement("author_first_name")]
        public XmlCDataSection Firstname { get; set; }

        [XmlElement("author_last_name")]
        public XmlCDataSection Lastname { get; set; }
    }
}