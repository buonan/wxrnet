using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace WxrNet
{
    public static class WxrSerializer
    {
        private static readonly XmlSerializer _serializer;
        private static readonly XmlSerializerNamespaces _xmlNamespaces;

        static WxrSerializer()
        {
            var serializer = new XmlSerializer(typeof(Wxr));
            var xmlNamespaces = new XmlSerializerNamespaces();
            xmlNamespaces.Add("content", "http://purl.org/rss/1.0/modules/content/");
            xmlNamespaces.Add("dc", "http://purl.org/dc/elements/1.1/");
            xmlNamespaces.Add("dsq", "http://www.disqus.com/");
            xmlNamespaces.Add("wp", "http://wordpress.org/export/1.0/");
            xmlNamespaces.Add("excerpt", "http://wordpress.org/export/1.0/excerpt/");
            xmlNamespaces.Add("wfw", "http://wellformedweb.org/CommentAPI/");

            _serializer = serializer;
            _xmlNamespaces = xmlNamespaces;
        }

        public static void Serialize(Wxr site) =>
            Serialize(site, new XmlWriterSettings { Indent = true, Encoding = Encoding.UTF8 });

        public static void Serialize(Wxr site, XmlWriterSettings settings)
        {
            var fileName = site.Site.FileFullPath;

            if (site == null) throw new ArgumentNullException(nameof(site));
            if (settings == null) throw new ArgumentNullException(nameof(settings));

            using (var writer = XmlWriter.Create(fileName, settings)) {
                _serializer.Serialize(writer, site, _xmlNamespaces);
            }

            return;
        }
    }
}