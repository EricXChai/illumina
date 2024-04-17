using CodingAssignmentLib.Abstractions;
using System.Text.Json;

namespace CodingAssignmentLib;

public class JsonContentParser : IContentParser
{
    public IEnumerable<Data> Parse(string? content)
    {
        var customOptions = new JsonSerializerOptions(JsonSerializerDefaults.Web);
        var result = JsonSerializer.Deserialize<List<Data>>(content, customOptions);

        return result;
    }
}