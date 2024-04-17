using CodingAssignmentLib.Abstractions;
using System.Xml.Serialization;

namespace CodingAssignmentLib;

public class XmlContentParser : IContentParser
{
    public IEnumerable<Data> Parse(string content)
    {
        List<Data> result = new();

        using (var reader = new StringReader(content))
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(List<Data>),
                new XmlRootAttribute("Datas"));
            result = (List<Data>)deserializer.Deserialize(reader);
        }

        return result;
    }
}
