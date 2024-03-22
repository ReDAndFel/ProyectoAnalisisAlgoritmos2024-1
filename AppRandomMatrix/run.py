import json
import os
import random

# Ruta absoluta para el archivo JSON
json_matrix_file_path = "../../matrix.json"

def generar_arreglo_bidimensional():
    n = random.randint(1, 10)  # Generar un número aleatorio entre 1 y 10 para el número de filas
    m = random.randint(1, 10)  # Generar un número aleatorio entre 1 y 10 para el número de columnas
    print("Valor de n:", n)  # Imprimir el valor de n
    print("Valor de m:", m)  # Imprimir el valor de m
    arreglo = []
    for _ in range(n):
        fila = []
        for _ in range(m):
            numero = random.randint(100000, 999999)  # Generar número aleatorio de 6 dígitos
            fila.append(numero)
        arreglo.append(fila)
    return arreglo

arreglo_bidimensional = generar_arreglo_bidimensional()

# Guardar la matriz en un archivo JSON
with open(json_matrix_file_path, 'w') as archivo_json:
    json.dump(arreglo_bidimensional, archivo_json)
