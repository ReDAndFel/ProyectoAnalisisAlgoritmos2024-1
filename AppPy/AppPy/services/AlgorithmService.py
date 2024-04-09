from . import JsonService as js
import math
from concurrent.futures import ThreadPoolExecutor

def NaivOnArray(matrix_A, matrix_B):
        
    rows_A = len(matrix_A)
    cols_A = len(matrix_A[0])
    cols_B = len(matrix_B[0])

    result = [[0.0] * cols_B for _ in range(rows_A)]  # Crear matriz de resultados

    for i in range(rows_A):
        for j in range(cols_B):
            result[i][j] = 0.0  # Inicializar el elemento en (i, j) a 0.0
            for k in range(cols_A):
                result[i][j] += matrix_A[i][k] * matrix_B[k][j]

    return result

def NaivLoopUnrollingTwo(matrix_A, matrix_B):
    N = len(matrix_A)
    P = len(matrix_A[0])
    M = len(matrix_B[0])
    
    
    Result = [[0.0] * M for _ in range(N)]

    if P % 2 == 0:
        for i in range(N):
            for j in range(M):
                aux = 0.0
                for k in range(0, P, 2):
                    aux += matrix_A[i][k] * matrix_B[k][j] + matrix_A[i][k + 1] * matrix_B[k + 1][j]
                Result[i][j] = aux
    else:
        PP = P - 1
        for i in range(N):
            for j in range(M):
                aux = 0.0
                for k in range(0, PP, 2):
                    aux += matrix_A[i][k] * matrix_B[k][j] + matrix_A[i][k + 1] * matrix_B[k + 1][j]
                Result[i][j] = aux + matrix_A[i][PP] * matrix_B[PP][j]

    return Result

def NaivLoopUnrollingFour(matrix_A, matrix_B):
    rows_A = len(matrix_A)
    cols_A = len(matrix_A[0])
    cols_B = len(matrix_B[0])
    Result = [[0.0] * cols_B for _ in range(rows_A)]

    if cols_A % 4 == 0:
        for i in range(rows_A):
            for j in range(cols_B):
                aux = 0.0
                for k in range(0, cols_A, 4):
                    aux += matrix_A[i][k] * matrix_B[k][j] + matrix_A[i][k + 1] * matrix_B[k + 1][j] \
                           + matrix_A[i][k + 2] * matrix_B[k + 2][j] + matrix_A[i][k + 3] * matrix_B[k + 3][j]
                Result[i][j] = aux
    elif cols_A % 4 == 1:
        cols_A_minus_one = cols_A - 1
        for i in range(rows_A):
            for j in range(cols_B):
                aux = 0.0
                for k in range(0, cols_A_minus_one, 4):
                    aux += matrix_A[i][k] * matrix_B[k][j] + matrix_A[i][k + 1] * matrix_B[k + 1][j] \
                           + matrix_A[i][k + 2] * matrix_B[k + 2][j] + matrix_A[i][k + 3] * matrix_B[k + 3][j]
                Result[i][j] = aux + matrix_A[i][cols_A_minus_one] * matrix_B[cols_A_minus_one][j]
    elif cols_A % 4 == 2:
        cols_A_minus_two = cols_A - 2
        cols_A_minus_one = cols_A - 1
        for i in range(rows_A):
            for j in range(cols_B):
                aux = 0.0
                for k in range(0, cols_A_minus_two, 4):
                    aux += matrix_A[i][k] * matrix_B[k][j] + matrix_A[i][k + 1] * matrix_B[k + 1][j] \
                           + matrix_A[i][k + 2] * matrix_B[k + 2][j] + matrix_A[i][k + 3] * matrix_B[k + 3][j]
                Result[i][j] = aux + matrix_A[i][cols_A_minus_two] * matrix_B[cols_A_minus_two][j] \
                               + matrix_A[i][cols_A_minus_one] * matrix_B[cols_A_minus_one][j]
    else:  # cols_A % 4 == 3
        cols_A_minus_three = cols_A - 3
        cols_A_minus_two = cols_A - 2
        cols_A_minus_one = cols_A - 1
        for i in range(rows_A):
            for j in range(cols_B):
                aux = 0.0
                for k in range(0, cols_A_minus_three, 4):
                    aux += matrix_A[i][k] * matrix_B[k][j] + matrix_A[i][k + 1] * matrix_B[k + 1][j] \
                           + matrix_A[i][k + 2] * matrix_B[k + 2][j] + matrix_A[i][k + 3] * matrix_B[k + 3][j]
                Result[i][j] = aux + matrix_A[i][cols_A_minus_three] * matrix_B[cols_A_minus_three][j] \
                               + matrix_A[i][cols_A_minus_two] * matrix_B[cols_A_minus_two][j] \
                               + matrix_A[i][cols_A_minus_one] * matrix_B[cols_A_minus_one][j]
    
    return Result

def WinogradOriginal(matrix_A, matrix_B):
    rows_A = len(matrix_A)
    cols_A = len(matrix_A[0])
    cols_B = len(matrix_B[0])
    Result = [[0.0] * cols_B for _ in range(rows_A)]

    upsilon = cols_A % 2
    gamma = cols_A - upsilon
    y = [0.0] * cols_B
    z = [0.0] * rows_A

    for i in range(cols_B):
        aux = 0.0
        for j in range(0, gamma, 2):
            aux += matrix_A[i][j] * matrix_A[i][j + 1]
        y[i] = aux

    for i in range(rows_A):
        aux = 0.0
        for j in range(0, gamma, 2):
            aux += matrix_B[j][i] * matrix_B[j + 1][i]
        z[i] = aux

    if upsilon == 1:
        PP = cols_A - 1
        for i in range(cols_B):
            for k in range(rows_A):
                aux = 0.0
                for j in range(0, gamma, 2):
                    aux += (matrix_A[i][j] + matrix_B[j + 1][k]) * (matrix_A[i][j + 1] + matrix_B[j][k])
                Result[i][k] = aux - y[i] - z[k] + matrix_A[i][PP] * matrix_B[PP][k]
    else:
        for i in range(cols_B):
            for k in range(rows_A):
                aux = 0.0
                for j in range(0, gamma, 2):
                    aux += (matrix_A[i][j] + matrix_B[j + 1][k]) * (matrix_A[i][j + 1] + matrix_B[j][k])
                Result[i][k] = aux - y[i] - z[k]

    return Result

def WinogradScaled(matrix_A, matrix_B):
    rows_A = len(matrix_A)
    cols_A = len(matrix_A[0])
    cols_B = len(matrix_B[0])
    Result = [[0.0] * cols_B for _ in range(rows_A)]

    # Crear copias escaladas de A y B
    CopyA = [[0.0] * cols_A for _ in range(rows_A)]
    CopyB = [[0.0] * cols_B for _ in range(cols_A)]

    # Factores de escala
    a = NormInf(matrix_A, rows_A, cols_A)
    b = NormInf(matrix_B, cols_A, cols_B)
    lambda_val = math.floor(0.5 + math.log(b/a) / math.log(4))

    # Escalamiento
    MultiplyWithScalar(matrix_A, CopyA, rows_A, cols_A, 2 ** lambda_val)
    MultiplyWithScalar(matrix_B, CopyB, cols_A, cols_B, 2 ** -lambda_val)

    # Usar Winograd con matrices escaladas
    Result = WinogradOriginal(CopyA, CopyB)

    return Result

# Función para calcular la norma infinita de una matriz
def NormInf(matrix, rows, cols):
    max_val = float('-inf')
    for i in range(rows):
        for j in range(cols):
            max_val = max(max_val, abs(matrix[i][j]))
    return max_val

# Función para multiplicar una matriz por un escalar
def MultiplyWithScalar(matrix, result, rows, cols, scalar):
    for i in range(rows):
        for j in range(cols):
            result[i][j] = matrix[i][j] * scalar
    return result

def III3SequentialBlock(matrix_A, matrix_B):
    # Obtener las dimensiones de las matrices
    
    rows_A = len(matrix_A)
    cols_B = len(matrix_B[0])
    cols_A = len(matrix_A[0])
            
    # Inicializar la matriz resultante
    result = [[0 for _ in range(cols_B)] for _ in range(rows_A)]    
    # Tamaño de los bloques
    block_size = min(rows_A, cols_B, cols_A) // 2

    
    # Multiplicar las matrices por bloques
    for row_block in range(0, rows_A, block_size):
        for col_block in range(0, cols_B, block_size):
            for col_A_block in range(0, cols_A, block_size):
                for row in range(row_block, min(row_block + block_size, rows_A)):
                    for col in range(col_block, min(col_block + block_size, cols_B)):
                        for col_A in range(col_A_block, min(col_A_block + block_size, cols_A)):
                            result[row][col] += matrix_A[row][col_A] * matrix_B[col_A][col]
    return result
                  
def III4ParallelBlock (matrix_A, matrix_B):
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
        for row_start in range(0, size, block_size):
            for col_start in range(0, size, block_size):
                for inner_start in range(0, size, block_size):
                    futures.append(executor.submit(multiply_block, row_start, col_start, inner_start))

        # Esperar a que todas las tareas se completen
        for future in futures:
            future.result()

    return result

def III5EnhancedParallelBlock (matrix_A, matrix_B):
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

def IV3Sequentialblock(matrix_A, matrix_B):
    
    # Obtener las dimensiones de las matrices
    
    rows_A = len(matrix_A)
    cols_B = len(matrix_B[0])
    cols_A = len(matrix_A[0])
            
    # Inicializar la matriz resultante
    result = [[0 for _ in range(cols_B)] for _ in range(rows_A)]    
    # Tamaño de los bloques
    block_size = min(rows_A, cols_B, cols_A) // 2

    
    # Multiplicar las matrices por bloques
    for row_block in range(0, rows_A, block_size):
        for col_block in range(0, cols_B, block_size):
            for col_A_block in range(0, cols_A, block_size):
                for row in range(row_block, min(row_block + block_size, rows_A)):
                    for col in range(col_block, min(col_block + block_size, cols_B)):
                        for col_A in range(col_A_block, min(col_A_block + block_size, cols_A)):
                            result[row][col] += matrix_A[row][col_A] * matrix_B[col_A][col]

    
    return result

def IV4ParallelBlock (matrix_A, matrix_B):
    
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
        for row_start in range(0, size, block_size):
            for col_start in range(0, size, block_size):
                for inner_start in range(0, size, block_size):
                    futures.append(executor.submit(multiply_block, row_start, col_start, inner_start))

        # Esperar a que todas las tareas se completen
        for future in futures:
            future.result()

    return result