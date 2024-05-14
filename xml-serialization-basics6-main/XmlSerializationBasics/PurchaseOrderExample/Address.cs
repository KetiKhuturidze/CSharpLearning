using System.Xml.Serialization;

namespace XmlSerializationBasics.PurchaseOrderExample
{
    public class Address
    {
        [XmlAttribute("name")]
        public string? Name { get; set; }

        [XmlElement("ship-to-city")]
        public string? City { get; set; }

        [XmlElement("ship-to-line1")]
        public string? Line1 { get; set; }

        [XmlAttribute("ship-to-state")]
        public string? State { get; set; }

        [XmlAttribute("zip")]
        public string? Zip { get; set; }
    }
}
