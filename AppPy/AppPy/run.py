import time
import services.AlgorithmService as As
import services.JsonService as Js

json_times_file_path = "../times.json"
json_matrix_file_path = "../matrix.json"

matrix1, matrix2 = Js.read_json_matrix(json_matrix_file_path)

# Imprimir la matriz1
print("La matriz1 desde el archivo JSON es:")
for row in matrix1:
    for element in row:
        print(element, end=" ")
    print() 
    
# Imprimir la matriz2
print("La matriz2 desde el archivo JSON es:")
for row in matrix2:
    for element in row:
        print(element, end=" ")
    print()    

# Se ejecuta el algoritmo NaivOnArray
start_time = time.time()
matrix_result_NaivOnArray = As.NaivOnArray(matrix1,matrix2)
end_time = time.time()
elapsed_time = end_time - start_time
Js.modify_property(json_times_file_path,"NaivOnArray", elapsed_time)
print("Tiempo de ejecución de NaivOnArray:", elapsed_time, "segundos")
#Imprime la matriz resultante de NaivOnArray
print("La matrix resultante del NaivOnArray es:")
for row in matrix_result_NaivOnArray:
    for element in row:
        print(element, end=" ")
    print()   

# Se ejecuta el algoritmo NaivLoopUnrollingTwo
start_time = time.time()
matrix_result_NaivLoopUnrollingTwo = As.NaivLoopUnrollingTwo(matrix1,matrix2)
end_time = time.time()
elapsed_time = end_time - start_time
Js.modify_property(json_times_file_path,"NaivLoopUnrollingTwo", elapsed_time)
print("Tiempo de ejecución de NaivLoopUnrollingTwo:", elapsed_time, "segundos")
#Imprime la matriz resultante de NaivLoopUnrollingTwo
print("La matrix resultante del NaivLoopUnrollingTwo es:")
for row in matrix_result_NaivLoopUnrollingTwo:
    for element in row:
        print(element, end=" ")
    print()   

# Se ejecuta el algoritmo NaivLoopUnrollingFour
start_time = time.time()
matrix_result_NaivLoopUnrollingFour = As.NaivLoopUnrollingFour(matrix1,matrix2)
end_time = time.time()
elapsed_time = end_time - start_time
Js.modify_property(json_times_file_path,"NaivLoopUnrollingFour", elapsed_time)
print("Tiempo de ejecución de NaivLoopUnrollingFour:", elapsed_time, "segundos")
#Imprime la matriz resultante de NaivLoopUnrollingFour
print("La matrix resultante del NaivLoopUnrollingFour es:")
for row in matrix_result_NaivLoopUnrollingFour:
    for element in row:
        print(element, end=" ")
    print()      
    
# Se ejecuta el algoritmo WinogradOriginal
start_time = time.time()
matrix_result_WinogradOriginal = As.WinogradOriginal(matrix1,matrix2)
end_time = time.time()
elapsed_time = end_time - start_time
Js.modify_property(json_times_file_path,"WinogradOriginal", elapsed_time)
print("Tiempo de ejecución de WinogradOriginal:", elapsed_time, "segundos")
#Imprime la matriz resultante de WinogradOriginal
print("La matrix resultante del WinogradOriginal es:")
for row in matrix_result_WinogradOriginal:
    for element in row:
        print(element, end=" ")
    print()    