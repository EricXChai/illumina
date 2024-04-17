using CodingAssignmentLib.Abstractions;
using CodingAssignmentLib;
using System.Text.Json;

namespace CodingAssignmentTests;

public class ContentSearcherTests
{
    private ContentSearcher _sut = null!;

    [SetUp]
    public void Setup()
    {
        _sut = new ContentSearcher();
    }

    [Test]
    public void Search_ReturnsData()
    {
        var path = ".\\data";
        var keyWord = "aAaAa";

        var dataList = _sut.Search(path, keyWord).ToList();
        var expected = new List<SearchResult>
        {
            new(".\\data\\data.csv", new Data("aaaaa", "bbbbb"))
        };    

        //Due to comparing complex object, hence applying different approach for the unit test result comparison
        var expectedSerialized = JsonSerializer.Serialize(expected);
        var dataListSerialized = JsonSerializer.Serialize(dataList);

        Assert.That(dataListSerialized, Is.EqualTo(expectedSerialized));
    }
}
