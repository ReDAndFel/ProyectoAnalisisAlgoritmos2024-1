import json
            
def read_json(json_file_path):
    # Leer la matriz desde el archivo JSON
    with open(json_file_path, 'r') as json_matrix:
        return json.load(json_matrix)     