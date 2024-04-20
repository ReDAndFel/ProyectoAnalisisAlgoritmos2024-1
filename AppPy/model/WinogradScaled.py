import math
from .WinogradOriginal import WinogradOriginalImpl

def WinogradScaledImpl(matrix_A, matrix_B):
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
    Result = WinogradOriginalImpl(CopyA, CopyB)

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