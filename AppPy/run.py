import time
import services.AlgorithmService as As
import services.JsonService as Js

json_matrix_file_path = "matrix.json"

for i in range(8):

    print(f"caso de uso {i+1}")   
    
    json_times_file_path = f"times{i+1}.json"

    matrix1, matrix2 = Js.read_json_matrix(json_matrix_file_path, i+1)    
    
    print(f"Ejecucion caso {i+1}")

    print(f"Matriz de tamaño ", len(matrix1))
    """
    # Se ejecuta el algoritmo NaivOnArray
    start_time = time.time()
    matrix_result_NaivOnArray = As.NaivOnArray(matrix1,matrix2)
    end_time = time.time()
    elapsed_time = end_time - start_time
    Js.modify_property(json_times_file_path,"NaivOnArray", elapsed_time)
    print("Tiempo de ejecución de NaivOnArray:", elapsed_time, "segundos")
    
    # Se ejecuta el algoritmo NaivLoopUnrollingTwo
    start_time = time.time()
    matrix_result_NaivLoopUnrollingTwo = As.NaivLoopUnrollingTwo(matrix1,matrix2)
    end_time = time.time()
    elapsed_time = end_time - start_time
    Js.modify_property(json_times_file_path,"NaivLoopUnrollingTwo", elapsed_time)
    print("Tiempo de ejecución de NaivLoopUnrollingTwo:", elapsed_time, "segundos")
    
    # Se ejecuta el algoritmo NaivLoopUnrollingFour
    start_time = time.time()
    matrix_result_NaivLoopUnrollingFour = As.NaivLoopUnrollingFour(matrix1,matrix2)
    end_time = time.time()
    elapsed_time = end_time - start_time
    Js.modify_property(json_times_file_path,"NaivLoopUnrollingFour", elapsed_time)
    print("Tiempo de ejecución de NaivLoopUnrollingFour:", elapsed_time, "segundos")
        
    #Se ejecuta el algoritmo WinogradOriginal
    start_time = time.time()
    matrix_result_WinogradOriginal = As.WinogradOriginal(matrix1,matrix2)
    end_time = time.time()
    elapsed_time = end_time - start_time
    Js.modify_property(json_times_file_path,"WinogradOriginal", elapsed_time)
    print("Tiempo de ejecución de WinogradOriginal:", elapsed_time, "segundos")
    """
    # Se ejecuta el algoritmo WinogradScaled
    start_time = time.time()
    matrix_result_WinogradScaled = As.WinogradScaled(matrix1,matrix2)
    end_time = time.time()
    elapsed_time = end_time - start_time
    Js.modify_property(json_times_file_path,"WinogradScaled", elapsed_time)
    print("Tiempo de ejecución de WinogradScaled:", elapsed_time, "segundos")
    """        
    #Se ejecuta el algoritmo StrassenNaiv
    start_time = time.time()
    matrix_result_StrassenNaiv = As.StrassenNaiv(matrix1,matrix2)
    end_time = time.time()
    elapsed_time = end_time - start_time
    Js.modify_property(json_times_file_path,"StrassenNaiv", elapsed_time)
    print("Tiempo de ejecución de StrassenNaiv:", elapsed_time, "segundos")
    
    #Se ejecuta el algoritmo IV.3 Sequential Block
    start_time = time.time()
    matrix_result_IV3SequentialBlock = As.IV3SequentialBlock(matrix1,matrix2)
    end_time = time.time()
    elapsed_time = end_time - start_time
    Js.modify_property(json_times_file_path,"IV.3 Sequential Block", elapsed_time)
    print("Tiempo de ejecución de IV.3 Sequential Block:", elapsed_time, "segundos")
    
    #Se ejecuta el algoritmo StrassenWinograd
    start_time = time.time()
    matrix_result_StrassenWinograd = As.StrassenWinograd(matrix1,matrix2)
    end_time = time.time()
    elapsed_time = end_time - start_time
    Js.modify_property(json_times_file_path,"StrassenWinograd", elapsed_time)
    print("Tiempo de ejecución de StrassenWinograd:", elapsed_time, "segundos")
       
    # Se ejecuta el algoritmo III.3 Sequential block
    start_time = time.time()
    matrix_result_III3SequentialBlock = As.III3SequentialBlock(matrix1,matrix2)
    end_time = time.time()
    elapsed_time = end_time - start_time
    Js.modify_property(json_times_file_path,"III.3 Sequential block", elapsed_time)
    print("Tiempo de ejecución de III.3 Sequential block:", elapsed_time, "segundos")
    
    # Se ejecuta el algoritmo III.4 Parallel block
    start_time = time.time()
    matrix_result_III4ParallelBlock = As.III4ParallelBlock(matrix1,matrix2)
    end_time = time.time()
    elapsed_time = end_time - start_time
    Js.modify_property(json_times_file_path,"III.4 Parallel block", elapsed_time)
    print("Tiempo de ejecución de III.4 Parallel block:", elapsed_time, "segundos")
    
    # Se ejecuta el algoritmo III.5 Enhanced Parallel Block
    start_time = time.time()
    matrix_result_III5EnhancedParallelBlock = As.III5EnhancedParallelBlock(matrix1,matrix2)
    end_time = time.time()
    elapsed_time = end_time - start_time
    Js.modify_property(json_times_file_path,"III.5 Enhanced Parallel Block", elapsed_time)
    print("Tiempo de ejecución de III.5 Enhanced Parallel Block:", elapsed_time, "segundos")
            
    # Se ejecuta el algoritmo IV.4 Parallel Block
    start_time = time.time()
    matrix_result_IV4ParallelBlock = As.IV4ParallelBlock(matrix1,matrix2)
    end_time = time.time()
    elapsed_time = end_time - start_time
    Js.modify_property(json_times_file_path,"IV.4 Parallel Block", elapsed_time)
    print("Tiempo de ejecución de IV.4 Parallel Block:", elapsed_time, "segundos")
    
    # Se ejecuta el algoritmo IV.5 Enhanced Parallel Block
    start_time = time.time()
    matrix_result_IV5EnhancedParallelBlock = As.IV5EnhancedParallelBlock(matrix1,matrix2)
    end_time = time.time()
    elapsed_time = end_time - start_time
    Js.modify_property(json_times_file_path,"IV.5 Enhanced Parallel Block", elapsed_time)
    print("Tiempo de ejecución de IV.5 Enhanced Parallel Block:", elapsed_time, "segundos")
       
    # Se ejecuta el algoritmo V.3 Sequential block
    start_time = time.time()
    matrix_result_V3Sequentialblock = As.V3SequentialBlock(matrix1,matrix2)
    end_time = time.time()
    elapsed_time = end_time - start_time
    Js.modify_property(json_times_file_path,"V.3 Sequential block", elapsed_time)
    print("Tiempo de ejecución de V.3 Sequential block:", elapsed_time, "segundos")

    # Se ejecuta el algoritmo V.4 Parallel Block
    start_time = time.time()
    matrix_result_V4ParallelBlock = As.V4ParallelBlock(matrix1,matrix2)
    end_time = time.time()
    elapsed_time = end_time - start_time
    Js.modify_property(json_times_file_path,"V.4 Parallel Block", elapsed_time)
    print("Tiempo de ejecución de V.4 Parallel Block:", elapsed_time, "segundos")"""