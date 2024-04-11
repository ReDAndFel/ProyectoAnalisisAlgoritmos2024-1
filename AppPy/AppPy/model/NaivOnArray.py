def NaivOnArrayImpl(matrix_A, matrix_B):
        
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