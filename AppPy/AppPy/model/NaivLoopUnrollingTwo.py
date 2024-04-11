def NaivLoopUnrollingTwoImpl(matrix_A, matrix_B):
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