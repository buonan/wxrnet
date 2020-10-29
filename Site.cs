using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace WxrNet
{
    [Serializable]
    public class Site
    {
        [XmlElement("title", typeof(string))]
        public string Title { get; set; }

        [XmlElement("description", typeof(string))]
        public string Description { get; set; }

        [XmlElement("pubDate", typeof(DateTime))]
        public DateTime PubDate { get; set; }

        [XmlElement("language", typeof(string))]
        public string Language { get; set; }

        [XmlElement("generator", typeof(string))]
        public string Generator { get; set; }

        [XmlElement("wxr_version", Namespace = "http://wordpress.org/export/1.0/", Type = typeof(string))]
        public string Version { get; set; }

        [XmlElement("author", Namespace = "http://wordpress.org/export/1.0/", Type = typeof(Author))]
        public List<Author> Authors { get; set; }

        [XmlElement("category", Namespace = "http://wordpress.org/export/1.0/", Type = typeof(CategoryTerm))]
        public List<CategoryTerm> Categories { get; set; }

        [XmlElement("item", typeof(Post))]
        public List<Post> Posts { get; set; }

         [XmlIgnore]
        public string FileFullPath = "export-" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + ".xml";
    }
}