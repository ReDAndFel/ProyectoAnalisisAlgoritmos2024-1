import json
import os
import random

# Ruta absoluta para el archivo JSON
json_matrix_file_path = "../matrix.json"

def generar_arreglo_bidimensional(n):
    matrix = []
    for _ in range(n):
        fila = []
        for _ in range(n):
            numero = random.randint(100000, 999999)  # Generar número aleatorio de 6 dígitos
            fila.append(numero)
        matrix.append(fila)
    return matrix

def generar_dos_arreglos_bidimensionales():
    n = 4
    # n = random.randint(1, 10)  # implementar que sea 2 sobre n 
    print("Valor de n:", n)  # Imprimir el valor de n
    matrix1 = generar_arreglo_bidimensional(n)
    matrix2 = generar_arreglo_bidimensional(n)
    return matrix1, matrix2

matrix1, matrix2 = generar_dos_arreglos_bidimensionales()

# Guardar los arreglos en un archivo JSON
data = {"matrix1": matrix1, "matrix2": matrix2}
with open(json_matrix_file_path, 'w') as file_json:
    json.dump(data, file_json)
