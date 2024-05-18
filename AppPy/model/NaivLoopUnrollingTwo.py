#Algoritmo basado en el libro METHODS OF MATRIX MULTIPLICATION AN OVERVIEW OF SEVERAL METHODS AND THEIR IMPLEMENTATION y apoyado en IA

def NaivLoopUnrollingTwoImpl(matrix_A, matrix_B):
    #Obtiene las cantidades de columnas y filas
    N = len(matrix_A)
    P = len(matrix_A[0])
    M = len(matrix_B[0])

    #Inicializa con ceros la matriz result
    Result = [[0.0] * M for _ in range(N)]

    # Realiza la multiplicación de matrices utilizando bucles desenrollados
    if P % 2 == 0:
        for i in range(N):
            for j in range(M):
                aux = 0.0
                for k in range(0, P, 2):
                    # Realiza la multiplicación de 2 elementos a la vez y suma los resultados
                    aux += matrix_A[i][k] * matrix_B[k][j] + matrix_A[i][k + 1] * matrix_B[k + 1][j]
                Result[i][j] = aux
    else:
        # Si el número de columnas de A es impar
        PP = P - 1  # Número de columnas de A menos uno
        for i in range(N):
            for j in range(M):
                aux = 0.0
                for k in range(0, PP, 2):
                    # Realiza la multiplicación de 2 elementos a la vez y suma los resultados
                    aux += matrix_A[i][k] * matrix_B[k][j] + matrix_A[i][k + 1] * matrix_B[k + 1][j]
                Result[i][j] = aux + matrix_A[i][PP] * matrix_B[PP][j]

    return Result