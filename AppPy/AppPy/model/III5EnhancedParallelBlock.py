from concurrent.futures import ThreadPoolExecutor

def III5EnhancedParallelBlockImpl(matrix_A, matrix_B):
    size = len(matrix_A)
    block_size = size // 2  # Tamaño del bloque
    
    # Inicializar matriz A con ceros
    result = [[0 for _ in range(size)] for _ in range(size)]
    
    def multiply_block(row_start, col_start, inner_start):
        for row in range(row_start, min(row_start + block_size, size)):
            for col in range(col_start, min(col_start + block_size, size)):
                for inner in range(inner_start, min(inner_start + block_size, size)):
                    result[row][col] += matrix_A[row][inner] * matrix_B[inner][col]

    with ThreadPoolExecutor() as executor:
        futures = []
        for row_start in range(0, size // 2, block_size):
            for col_start in range(0, size, block_size):
                for inner_start in range(0, size, block_size):
                    futures.append(executor.submit(multiply_block, row_start, col_start, inner_start))
        
            for row_start in range(size // 2, size, block_size):
                for col_start in range(0, size, block_size):
                    for inner_start in range(0, size, block_size):
                        futures.append(executor.submit(multiply_block, row_start, col_start, inner_start))
        
        # Esperar a que todas las tareas se completen
        for future in futures:
            future.result()

    return result