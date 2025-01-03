#Algoritmo basado en el libro METHODS OF MATRIX MULTIPLICATION AN OVERVIEW OF SEVERAL METHODS AND THEIR IMPLEMENTATION y apoyado en IA

from concurrent.futures import ThreadPoolExecutor


def V4ParallelBlockImpl(matrix_A, matrix_B):
    
    size = len(matrix_A)
    block_size = size // 2  # Tamaño del bloque
    
    # Inicializar matriz A con ceros
    result = [[0 for _ in range(size)] for _ in range(size)]
    
    # Método para multiplicar un bloque específico
    def multiply_block(row_start, col_start, inner_start):
        for row in range(row_start, min(row_start + block_size, size)):
            for col in range(col_start, min(col_start + block_size, size)):
                for inner in range(inner_start, min(inner_start + block_size, size)):
                    result[inner][row] += matrix_A[inner][col] * matrix_B[col][row]

    #Inicia tareas de multiplicacion en paralelo
    with ThreadPoolExecutor() as executor:
        futures = []
        for row_start in range(0, size, block_size):
            for col_start in range(0, size, block_size):
                for inner_start in range(0, size, block_size):
                    futures.append(executor.submit(multiply_block, row_start, col_start, inner_start))

        # Esperar a que todas las tareas se completen
        for future in futures:
            future.result()

    return result