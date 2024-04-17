using CodingAssignmentLib.Abstractions;
using CodingAssignmentLib;

namespace CodingAssignmentTests;

public class JsonContentParserTests
{
    private JsonContentParser _sut = null!;

    [SetUp]
    public void Setup()
    {
        _sut = new JsonContentParser();
    }

    [Test]
    public void Parse_ReturnsData()
    {
        var content = $"[{{\"Key\": \"a\",\"Value\": \"b\"}},{{\"Key\": \"c\",\"Value\": \"d\"}}]";
        var dataList = _sut.Parse(content).ToList();
        CollectionAssert.AreEqual(new List<Data>
        {
            new("a", "b"),
            new("c", "d")
        }, dataList);
    }
}
