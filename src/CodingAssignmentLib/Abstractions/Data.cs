using System.Text.Json.Serialization;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace CodingAssignmentLib.Abstractions;

public struct Data : IXmlSerializable
{
    [JsonConstructor] //Adding this attribute to let JSON serializer know which constructor to be use instead of using the default deserializer options
    public Data(string key, string value)
    {
        Key = key;
        Value = value;
    }

    public string Key { get; }

    public string Value { get; }

    public XmlSchema? GetSchema()
    {
        throw new NotImplementedException();
    }

    public void ReadXml(XmlReader reader)
    {
        reader.MoveToContent();
        var _data = reader.GetAttribute("Data");
        var isEmptyElement = reader.IsEmptyElement;
        reader.ReadStartElement();
        if (!isEmptyElement) // (1)
        {
            this = new Data(reader.ReadElementString("Key"), reader.ReadElementString("Value"));
            reader.ReadEndElement();
        }
    }

    public void WriteXml(XmlWriter writer)
    {
        throw new NotImplementedException();
    }
}