from fastapi import FastAPI
import file_parser

app = FastAPI()
parser = file_parser.Parser()

@app.get("/")
def read_root():
    return {"Test": "Server"}

@app.get("/xml")
def read_xml():
    parser.parse_file("./02_data_formats/exercise_01/files/me.xml")
    return {}

@app.get("/csv")
def read_csv():
    parser.parse_file("./02_data_formats/exercise_01/files/me.csv")
    return {}

@app.get("/yaml")
def read_yaml():
    parser.parse_file("./02_data_formats/exercise_01/files/me.yaml")
    return {}

@app.get("/txt")
def read_txt():
    parser.parse_file("./02_data_formats/exercise_01/files/me.txt")
    return {}

@app.get("/json")
def read_json():
    parser.parse_file("./02_data_formats/exercise_01/files/me.json")
    return {}

#File types: XML, CSV, YAML, TXT, JSON.