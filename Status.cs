using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace WxrNet
{
    public struct Status : IXmlSerializable
    {
        private string _value;

        public Status(string value)
        {
            _value = value;
        }

        private string Value
        {
            get
            {
                return _value;
            }
        }

        public XmlSchema GetSchema() { return null; }

        public void ReadXml(XmlReader reader)
        {
            _value = (reader.ReadElementContentAsString());
        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteString(Value);
        }

        public static implicit operator string(Status value) => value.Value;
        public static implicit operator Status(string value) => new Status(value);
    }
}