using System;
using System.Collections.Generic;
using System.Globalization;
using System.Xml;
using System.Xml.Serialization;

namespace WxrNet
{
    [Serializable]
    public class Post
    {
        private const string DateTimeFormat = "yyyy-MM-dd HH:mm:ss";

        [XmlElement(ElementName = "post_id", Namespace = "http://wordpress.org/export/1.0/")]
        public string Id { get; set; }

        // For internal reference
        [XmlElement(ElementName = "external_id")]
        public string ExternalId { get; set; }

        [XmlElement("category")]
        public Category Category { get; set; }

        // For thumbnail attachments
        [XmlElement(ElementName = "post_name", Namespace = "http://wordpress.org/export/1.0/")]
        public string Name { get; set; }

        [XmlElement("title")]
        public string Title { get; set; }

        [XmlElement("creator", Namespace = "http://purl.org/dc/elements/1.1/")]
        public string Creator { get; set; }

        [XmlElement("link")]
        public string Link { get; set; }

        [XmlElement(ElementName = "post_type", Namespace = "http://wordpress.org/export/1.0/")]
        public string Type { get; set; }

        [XmlIgnore]
        public DateTime PostDateInGmt { get; set; }

        [XmlElement(ElementName = "post_date", Namespace = "http://wordpress.org/export/1.0/")]
        public string CommentDateInString
        {
            get
            {
                return PostDateInGmt.ToString(DateTimeFormat);
            }

            set
            {
                PostDateInGmt = DateTime.ParseExact(value, DateTimeFormat, CultureInfo.InvariantCulture);
            }
        }

        [XmlElement(ElementName = "post_date_gmt", Namespace = "http://wordpress.org/export/1.0/")]
        public string CommentDateInGmtString
        {
            get
            {
                return PostDateInGmt.ToString(DateTimeFormat);
            }

            set
            {
                PostDateInGmt = DateTime.ParseExact(value, DateTimeFormat, CultureInfo.InvariantCulture);
            }
        }


        [XmlElement(ElementName = "encoded", Namespace = "http://purl.org/rss/1.0/modules/content/")]
        public XmlCDataSection Content { get; set; }

        [XmlElement(ElementName = "post_thumbnail", Namespace = "http://wordpress.org/export/1.0/")]
        public string Thumbnail { get; set; }

        [XmlElement(ElementName = "header_video", Namespace = "http://wordpress.org/export/1.0/")]
        public string Video { get; set; }

        [XmlElement(ElementName = "comment_status", Namespace = "http://wordpress.org/export/1.0/")]
        public OpenClosed IsCommentsOpen { get; set; }

        [XmlElement(ElementName = "status", Namespace = "http://wordpress.org/export/1.0/")]
        public Status Status { get; set; }

        [XmlElement(ElementName = "postmeta", Namespace = "http://wordpress.org/export/1.0/")]
        public Meta Meta { get; set; }

        [XmlElement(ElementName = "comment", Namespace = "http://wordpress.org/export/1.0/", Type = typeof(Comment))]
        public List<Comment> Comments { get; set; }

        [XmlElement("attachment_url", Namespace = "http://wordpress.org/export/1.0/")]
        public XmlCDataSection Url { get; set; }
    }
}