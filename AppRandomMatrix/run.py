import json
import os
import random

# Ruta absoluta para el archivo JSON
json_matrix_file_path = "matrix.json"

def generar_arreglo_bidimensional(n):
    matrix = []
    for _ in range(n):
        fila = []
        for _ in range(n):
            numero = random.randint(100000, 999999)  # Generar número aleatorio de 6 dígitos
            fila.append(numero)
        matrix.append(fila)
    return matrix

def generar_dos_arreglos_bidimensionales(n):
    size = pow(2, n) #Crea una tamaño de 2 a la n
    print("Tamaño de la matriz:", size)  # Imprimir el valor del tamaño
    matrix1 = generar_arreglo_bidimensional(size)
    matrix2 = generar_arreglo_bidimensional(size)
    return matrix1, matrix2

data = {}
n=1
for i in range(8):
    case_name = f"caso{i+1}"
    matrix1, matrix2 = generar_dos_arreglos_bidimensionales(n)
    data[case_name] = {"matrix1": matrix1, "matrix2": matrix2}
    n+=1

with open(json_matrix_file_path, 'w') as file_json:
    json.dump(data, file_json)
