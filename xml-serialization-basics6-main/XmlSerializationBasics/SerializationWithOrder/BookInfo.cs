using System.Xml.Serialization;

namespace XmlSerializationBasics.SerializationWithOrder
{
    [XmlRoot(ElementName = "book", Namespace = "http://contoso.com/book")]
    public class BookInfo
    {
        [XmlElement(ElementName = "book-title", Order = 1)]
        public string? Title { get; set; }

        [XmlElement(ElementName = "book-price", Order = 5)]
        public decimal Price { get; set; }

        [XmlElement(ElementName = "book-genre", Order = 4)]
        public string? Genre { get; set; }

        [XmlElement(ElementName = "book-isbn", Order = 3)]
        public string? Isbn { get; set; }

        [XmlElement(ElementName = "book-publication-date", Order = 2)]
        public string? PublicationDate { get; set; }
    }
}
