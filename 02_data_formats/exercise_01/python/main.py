import file_parser

f = file_parser.Parser()

f.parse_file("../files/me.txt")
f.parse_file("../files/me.json")
f.parse_file("../files/me.xml")
f.parse_file("../files/me.csv")
f.parse_file("../files/me.yaml")