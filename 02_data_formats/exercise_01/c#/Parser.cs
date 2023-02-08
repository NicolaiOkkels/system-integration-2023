using System;
using System.IO;
using System.Text.Json;
using System.Xml.Linq;
using YamlDotNet.Serialization;
using CsvHelper;

class FileParser
{
    public void ParseFile(string filePath)
    {
        string fileType = Path.GetExtension(filePath);

        switch (fileType)
        {
            case ".txt":
            case ".xml":
            case ".yaml":
            case ".yml":
            case ".json":
            case ".csv":
                ParseFileWithStreamReader(filePath, fileType);
                break;
            default:
                Console.WriteLine("file format not supported");
                break;
        }
    }

    private void ParseFileWithStreamReader(string file, string fileType)
    {
        using var reader = new StreamReader(file);
        string fileContent = reader.ReadToEnd();

        switch (fileType)
        {
            case ".txt":
                Console.WriteLine(fileContent);
                break;
            case ".xml":
                XDocument doc = XDocument.Parse(fileContent);
                Console.WriteLine(doc.ToString());
                break;
            case ".yaml":
                var deserializer = new DeserializerBuilder().Build();
                object obj = deserializer.Deserialize(fileContent);
                Console.WriteLine(obj);
                break;
            case ".json":
                JsonDocument doc = JsonDocument.Parse(fileContent);
                Console.WriteLine(doc.ToString());
                break;
            case ".csv":
                using var csv = new CsvReader(reader);
                while (csv.Read())
                {
                    for (int i = 0; i < csv.Context.HeaderRecord.Length; i++)
                    {
                        Console.WriteLine(csv.Context.HeaderRecord[i] + ": " + csv[i]);
                    }
                    Console.WriteLine();
                }
                break;
        }
    }
}