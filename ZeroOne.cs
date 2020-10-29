using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace WxrNet
{
    public struct ZeroOne : IXmlSerializable
    {
        private bool? _value;
        private string _stringValue;

        public ZeroOne(bool value)
        {
            _value = value;
            _stringValue = null;
        }

        public ZeroOne(string value)
        {
            _value = null;
            _stringValue = value;
        }

        private bool? Value
        {
            get
            {
                return _value;
            }
        }

        private string StringValue
        {
            get
            {
                return _stringValue;
            }
        }

        public XmlSchema GetSchema() { return null; }

        public void ReadXml(XmlReader reader)
        {
            _value = (reader.ReadElementContentAsString() == "1");
        }

        public void WriteXml(XmlWriter writer)
        {
            if (Value.HasValue) {
                writer.WriteString((Value.HasValue) ? "1" : "0");
            } else {
                writer.WriteCData(StringValue);
            }
        }
    }
}