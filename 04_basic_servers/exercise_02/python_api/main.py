from fastapi import FastAPI

app = FastAPI()

@app.get("/")
def read_root():
    return {"Test": "Server"}

@app.get("")
def read_xml():
    return {}

@app.get("")
def read_csv():
    return {}

@app.get("")
def read_yaml():
    return {}

@app.get("")
def read_txt():
    return {}

@app.get("")
def read_json():
    return {}

#File types: XML, CSV, YAML, TXT, JSON.