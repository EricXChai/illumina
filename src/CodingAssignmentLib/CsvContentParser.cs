using CodingAssignmentLib.Abstractions;

namespace CodingAssignmentLib;

public class CsvContentParser : IContentParser
{
    public IEnumerable<Data> Parse(string content)
    {
        //Not sure why "Environment.NewLine" is not working for my local. Hence, reimplemented with different parameters for the split.
        //return content.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries).Select(line =>
        //{
        //    var items = line.Split(',', StringSplitOptions.RemoveEmptyEntries);
        //    return new Data(items[0], items[1]);
        //});

        return content.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries).Select(line =>
        {
            var items = line.Split(',', StringSplitOptions.RemoveEmptyEntries);
            return new Data(items[0], items[1]);
        });
    }
}