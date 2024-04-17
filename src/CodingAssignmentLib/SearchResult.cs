using CodingAssignmentLib.Abstractions;

namespace CodingAssignmentLib;

public class SearchResult
{
    public SearchResult(string filePath, Data data)
    {
        FilePath = filePath;
        Data = data;
    }

    public string FilePath { get; }
    public Data Data { get; }
}
