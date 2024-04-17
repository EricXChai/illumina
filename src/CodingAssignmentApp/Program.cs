// See https://aka.ms/new-console-template for more information

using System.IO.Abstractions;
using CodingAssignmentLib;
using CodingAssignmentLib.Abstractions;

Console.WriteLine("Coding Assignment!");

do
{
    Console.WriteLine("\n---------------------------------------\n");
    Console.WriteLine("Choose an option from the following list:");
    Console.WriteLine("\t1 - Display");
    Console.WriteLine("\t2 - Search");
    Console.WriteLine("\t3 - Exit");

    switch (Console.ReadLine())
    {
        case "1":
            Display();
            break;
        case "2":
            Search();
            break;
        case "3":
            return;
        default:
            return;
    }
} while (true);


void Display()
{
    Console.WriteLine("Enter the name of the file to display its content:");

    var fileName = Console.ReadLine()!;
    var fileUtility = new FileUtility(new FileSystem());
    var dataList = Enumerable.Empty<Data>();

    //Convert to swith case
    //if (fileUtility.GetExtension(fileName) == ".csv")
    //{
    //    dataList = new CsvContentParser().Parse(fileUtility.GetContent(fileName));
    //}
    try
    {
        var fileExtension = fileUtility.GetExtension(fileName);
        switch (fileExtension)
        {
            case ".csv":
                dataList = new CsvContentParser().Parse(fileUtility.GetContent(fileName));
                break;

            case ".json":
                dataList = new JsonContentParser().Parse(fileUtility.GetContent(fileName));
                break;

            case ".xml":
                dataList = new XmlContentParser().Parse(fileUtility.GetContent(fileName));
                break;

            default:
                Console.WriteLine($"Invalid file format.");
                break;
        }

        Console.WriteLine("Data:");

        foreach (var data in dataList)
        {
            Console.WriteLine($"Key:{data.Key} Value:{data.Value}");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}

void Search()
{
    Console.WriteLine("Enter the key to search.");

    try
    {
        var directoryPath = ".\\data";
        var searchKeyWord = Console.ReadLine();
        var isFoundDataList = new ContentSearcher().Search(directoryPath, searchKeyWord);

        foreach (var data in isFoundDataList)
        {
            Console.WriteLine($"Key:{data.Data.Key} Value:{data.Data.Value} FileName:{data.FilePath}");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}