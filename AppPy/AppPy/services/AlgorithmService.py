from . import JsonService as js

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
