import json, yaml, csv, xml.etree.ElementTree as ET

class Parser:
    def __init__(self):
        self.supported_file_types = ["txt", "xml", "yaml", "json", "csv"]
    
    def parse_file(self, file_path):
        file_type = file_path.split(".")[-1]
        if file_type not in self.supported_file_types:
            print(f"file type not supported: {file_type}")
            return

        with open(file_path, "r") as file:
            file_content = file.read()
            if file_type == "txt":
                print(file_content)
            elif file_type == "xml":
                root = ET.fromstring(file_content)
                print(ET.tostring(root, encoding="unicode"))
            elif file_type == "yaml":
                data = yaml.safe_load(file_content)
                print(data)
            elif file_type == "json":
                data = json.loads(file_content)
                print(json.dumps(data, indent=4, default=str))
            elif file_type == "csv":
                reader = csv.reader(file_content.splitlines())
                for row in reader:
                    print(row)