import json


def modify_property(json_file_path, property_name, value):
        
        json_data = read_json(json_file_path)

        # Modificar la propiedad en el objeto JSON
        json_data['py'][property_name] = value

        # Escribir el objeto JSON modificado de vuelta al archivo
        with open(json_file_path, 'w') as file:
            json.dump(json_data, file, indent=4)
            
def read_json(json_file_path):
    # Leer la matriz desde el archivo JSON
    with open(json_file_path, 'r') as json_matrix:
        return json.load(json_matrix)              