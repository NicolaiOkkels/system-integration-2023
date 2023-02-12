using System;
using FileParser;

namespace FileParser
{
    public class Program
    {
        static void Main(string[] args)
        {
            Parser parser = new Parser();

            parser.ParseFile("../files/me.txt");
            parser.ParseFile("../files/me.json");
            parser.ParseFile("../files/me.yaml");
            parser.ParseFile("../files/me.xml"); 
            parser.ParseFile("../files/me.csv"); //TODO: fix
        }
    }
}