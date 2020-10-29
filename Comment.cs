using System;
using System.Globalization;
using System.Xml;
using System.Xml.Serialization;

namespace WxrNet
{
    [Serializable]
    public class Comment
    {
        private const string DateTimeFormat = "yyyy-MM-dd HH:mm:ss";

        [XmlElement("comment_id")]
        public string Id { get; set; }

        [XmlElement("comment_alter_id")]
        public string AlterId { get; set; }

        // For internal reference
        [XmlElement(ElementName = "external_id")]
        public string ExternalId { get; set; }

        [XmlElement("comment_parent")]
        public string ParentId { get; set; }

        // For internal reference
        [XmlElement(ElementName = "external_parent_id")]
        public string ExternalParentId { get; set; }

        // For internal reference
        [XmlElement(ElementName = "external_reply_level")]
        public int ExternalReplyLevel { get; set; }

        [XmlElement("comment_content")]
        public XmlCDataSection Content { get; set; }

        [XmlElement("comment_author")]
        public XmlCDataSection AuthorFullName { get; set; }

        [XmlElement("comment_author_email")]
        public string AuthorEmail { get; set; }

        [XmlElement("comment_author_url")]
        public string AuthorUrl { get; set; }

        [XmlElement("comment_author_IP")]
        public string IpAddress { get; set; }

        [XmlIgnore]
        public DateTime CommentDateInGmt { get; set; }

        [XmlElement(ElementName = "comment_date", Namespace = "http://wordpress.org/export/1.0/")]
        public string CommentDateInString
        {
            get
            {
                return CommentDateInGmt.ToString(DateTimeFormat);
            }

            set
            {
                CommentDateInGmt = DateTime.ParseExact(value, DateTimeFormat, CultureInfo.InvariantCulture);
            }
        }

        [XmlElement("comment_date_gmt")]
        public string CommentDateInGmtString
        {
            get
            {
                return CommentDateInGmt.ToString(DateTimeFormat);
            }

            set
            {
                CommentDateInGmt = DateTime.ParseExact(value, DateTimeFormat, CultureInfo.InvariantCulture);
            }
        }

        [XmlElement("comment_approved")]
        public ZeroOne IsApproved { get; set; }

        [XmlElement(ElementName = "status", Namespace = "http://wordpress.org/export/1.0/")]
        public Status Status { get; set; }
    }
}