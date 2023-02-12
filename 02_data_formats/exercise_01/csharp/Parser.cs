using System;
using System.Text.Json;
using System.Xml.Linq;
using YamlDotNet.Serialization;
using CsvHelper;
using System.Globalization;
using Newtonsoft.Json;

namespace FileParser
{
    public class Parser
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
                    Console.WriteLine("file type: " + fileType + " not supported");
                    break;
            }
        }

        private void ParseFileWithStreamReader(string filePath, string fileType)
        {
            string fileContent;

            using (var reader = new StreamReader(filePath))
            {
                fileContent = reader.ReadToEnd();
                var person = new Person();

                switch (fileType)
                {
                    case ".txt":
                        Console.WriteLine(fileContent);
                        break;
                    case ".xml":
                        var doc = XDocument.Parse(fileContent);
                        Console.WriteLine(doc.ToString());
                        break;
                    case ".yaml":
                        var deserializer = new DeserializerBuilder().Build();
                        var result = deserializer.Deserialize<Person>(fileContent);
                        var h = result.Hobbies;

                        if (result.Hobbies != null)
                        {
                            Console.WriteLine($"{result.Name}, {result.Age} and have the hobbies: {String.Join(", ", result.Hobbies)}");
                        }
                        else
                        {
                            Console.WriteLine($"{result.Name}, {result.Age} and have no hobbies.");
                        }
                        break;
                    case ".json":
                        dynamic? parsedJson = JsonConvert.DeserializeObject(fileContent);

                        person.Name = parsedJson?.name;
                        person.Age = parsedJson?.age;

                        string? s = parsedJson?.hobby;
                        string[]? hobbies = s?.Split(",");

                        var list = new List<string>();
                        if (hobbies != null)
                            foreach (string hobby in hobbies)
                            {
                                list.Add(hobby);
                            }

                        person.Hobbies = list.ToArray();

                        Console.WriteLine(person.ToString());
                        break;
                    case ".csv":
                        using (var sr = new StreamReader(filePath))
                        {
                            using (var csv = new CsvReader(sr, CultureInfo.InvariantCulture))
                            {
                                csv.Context.RegisterClassMap<PersonClassMap>();
                                var records = csv.GetRecords<Person>().ToList();

                                foreach (var p in records)
                                {
                                    Console.WriteLine($"Name: {p.Name}, Age: {p.Age} and the hobbies:{String.Join(",", p.Hobbies)}");
                                }
                            }
                        }
                        break;
                }
            }
        }
    }
}
