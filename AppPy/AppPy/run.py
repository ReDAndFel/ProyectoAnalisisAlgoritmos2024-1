import services.AlgorithmService as As
import services.JsonService as Js

json_times_file_path = "../../times.json"
json_matrix_file_path = "../../matrix.json"

matrix = Js.read_json(json_matrix_file_path)

# Imprimir la matriz
print("La matriz desde el archivo JSON es:")
for fila in matrix:
    for elemento in fila:
        print(elemento, end=" ")  # Imprimir cada elemento de la fila seguido de un espacio
    print()  # Imprimir un salto de línea al final de cada fila


# Modificar propiedad "NaivOnArray" en "Cs por el valor 1"
As.add_time(json_times_file_path,"NaivOnArray", 1)




