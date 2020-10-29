using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace WxrNet
{
    [Serializable]
    public class CategoryTerm
    {
        [XmlElement("term_id")]
        public int Id;

        [XmlElement("category_nicename")]
        public string Nicename;

        [XmlElement("category_parent")]
        public string Parent { get; set; }

        [XmlElement("cat_name")]
        public XmlCDataSection Name { get; set; }
    }
}