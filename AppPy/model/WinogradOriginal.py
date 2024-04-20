def WinogradOriginalImpl(matrix_A, matrix_B):
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