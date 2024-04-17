using CodingAssignmentLib.Abstractions;
using System.IO.Abstractions;

namespace CodingAssignmentLib;

public class ContentSearcher
{
    public List<SearchResult> Search(string directoryPath, string keyWord)
    {
        var fileUtility = new FileUtility(new FileSystem());
        List<SearchResult> isFoundDataList = new();

        //Getting paths for all the files which residing in the folder and its subfolder then filter them with only the file extension which wanted.
        var allFilePaths = Directory.GetFiles(directoryPath, "*.*", SearchOption.AllDirectories)
                .Where(file => file.ToLower().EndsWith(".csv")
                || file.ToLower().EndsWith(".json")
                || file.ToLower().EndsWith(".xml"));

        foreach (var filePath in allFilePaths)
        {
            var tempDataList = Enumerable.Empty<Data>();
            var fileExtension = fileUtility.GetExtension(filePath);
            switch (fileExtension)
            {
                case ".csv":
                    tempDataList = new CsvContentParser().Parse(fileUtility.GetContent(filePath));
                    isFoundDataList = isFoundDataList.Concat(tempDataList
                            .Where(s => s.Key.ToLower() == keyWord.ToLower())
                                .Select(f => new SearchResult(filePath, f)).ToList()).ToList();
                    break;

                case ".json":
                    tempDataList = new JsonContentParser().Parse(fileUtility.GetContent(filePath));
                    isFoundDataList = isFoundDataList.Concat(tempDataList
                            .Where(s => s.Key.ToLower() == keyWord.ToLower())
                                .Select(f => new SearchResult(filePath, f)).ToList()).ToList();
                    break;

                case ".xml":
                    tempDataList = new XmlContentParser().Parse(fileUtility.GetContent(filePath));
                    isFoundDataList = isFoundDataList.Concat(tempDataList
                            .Where(s => s.Key.ToLower() == keyWord.ToLower())
                                .Select(f => new SearchResult(filePath, f)).ToList()).ToList();
                    break;

                default:
                    //Console.WriteLine($"Invalid file format.");
                    break;
            }
        }

        return isFoundDataList;
    }

}
