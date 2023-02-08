using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        string textFile = "files/me.txt";
        string jsonFile = "files/me.json";
        string yamlFile = "files/me.yaml";
        string xmlFile = "files/me.xml";
        string csvFile = "files/me.csv";

        FileParser parser = new FileParser();

        parser.ParseFile(textFile);
        parser.ParseFile(jsonFile);
        parser.ParseFile(yamlFile);
        parser.ParseFile(xmlFile);
        parser.ParseFile(csvFile);
    }
}