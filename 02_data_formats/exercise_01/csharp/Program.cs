using System;
using FileParser;

namespace FileParser
{
    public class Program
    {
        static void Main(string[] args)
        {
            Parser parser = new Parser();

            parser.ParseFile("../files/me.txt"); // works
            parser.ParseFile("../files/me.json"); // works
            //parser.ParseFile("../files/me.yaml"); //TODO: fix
            parser.ParseFile("../files/me.xml"); // works
            parser.ParseFile("../files/me.csv"); // fix
        }
    }
}