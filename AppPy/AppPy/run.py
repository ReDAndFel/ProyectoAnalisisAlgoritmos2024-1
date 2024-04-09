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

# Se ejecuta el algoritmo WinogradScaled
start_time = time.time()
matrix_result_WinogradScaled = As.WinogradScaled(matrix1,matrix2)
end_time = time.time()
elapsed_time = end_time - start_time
Js.modify_property(json_times_file_path,"WinogradScaled", elapsed_time)
print("Tiempo de ejecución de WinogradScaled:", elapsed_time, "segundos")
#Imprime la matriz resultante de WinogradScaled
print("La matrix resultante del WinogradScaled es:")
for row in matrix_result_WinogradScaled:
    for element in row:
        print(element, end=" ")
    print()      
    
"""Se ejecuta el algoritmo StrassenNaiv (corregir)
start_time = time.time()
matrix_result_StrassenNaiv = As.StrassenNaiv(matrix1,matrix2)
end_time = time.time()
elapsed_time = end_time - start_time
Js.modify_property(json_times_file_path,"StrassenNaiv", elapsed_time)
print("Tiempo de ejecución de StrassenNaiv:", elapsed_time, "segundos")
#Imprime la matriz resultante de StrassenNaiv
print("La matrix resultante del StrassenNaiv es:")
for row in matrix_result_StrassenNaiv:
    for element in row:
        print(element, end=" ")
    print()     """

# Se ejecuta el algoritmo III.3 Sequential block
start_time = time.time()
matrix_result_III3SequentialBlock = As.III3SequentialBlock(matrix1,matrix2)
end_time = time.time()
elapsed_time = end_time - start_time
Js.modify_property(json_times_file_path,"III.3 Sequential block", elapsed_time)
print("Tiempo de ejecución de III.3 Sequential block:", elapsed_time, "segundos")
#Imprime la matriz resultante de III.3 Sequential block
print("La matrix resultante del III.3 Sequential block es:")
for row in matrix_result_III3SequentialBlock:
    for element in row:
        print(element, end=" ")
    print()    

# Se ejecuta el algoritmo III.4 Parallel block
start_time = time.time()
matrix_result_III4ParallelBlock = As.III4ParallelBlock(matrix1,matrix2)
end_time = time.time()
elapsed_time = end_time - start_time
Js.modify_property(json_times_file_path,"III.4 Parallel block", elapsed_time)
print("Tiempo de ejecución de III.4 Parallel block:", elapsed_time, "segundos")
#Imprime la matriz resultante de III.4 Parallel block
print("La matrix resultante del III.4 Parallel block es:")
for row in matrix_result_III4ParallelBlock:
    for element in row:
        print(element, end=" ")
    print()

# Se ejecuta el algoritmo III.5 Enhanced Parallel Block
start_time = time.time()
matrix_result_III5EnhancedParallelBlock = As.III5EnhancedParallelBlock(matrix1,matrix2)
end_time = time.time()
elapsed_time = end_time - start_time
Js.modify_property(json_times_file_path,"III.5 Enhanced Parallel Block", elapsed_time)
print("Tiempo de ejecución de III.5 Enhanced Parallel Block:", elapsed_time, "segundos")
#Imprime la matriz resultante de III.5 Enhanced Parallel Block
print("La matrix resultante del III.5 Enhanced Parallel Block es:")
for row in matrix_result_III5EnhancedParallelBlock:
    for element in row:
        print(element, end=" ")
    print()
    
# Se ejecuta el algoritmo IV.3 Sequential block
start_time = time.time()
matrix_result_IV3Sequentialblock = As.IV3Sequentialblock(matrix1,matrix2)
end_time = time.time()
elapsed_time = end_time - start_time
Js.modify_property(json_times_file_path,"IV.3 Sequential block", elapsed_time)
print("Tiempo de ejecución de IV.3 Sequential block:", elapsed_time, "segundos")
#Imprime la matriz resultante de IV.3 Sequential block
print("La matrix resultante del IV.3 Sequential block es:")
for row in matrix_result_IV3Sequentialblock:
    for element in row:
        print(element, end=" ")
    print()    
             

    