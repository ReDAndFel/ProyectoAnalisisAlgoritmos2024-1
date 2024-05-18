#Algoritmo basado en el libro METHODS OF MATRIX MULTIPLICATION AN OVERVIEW OF SEVERAL METHODS AND THEIR IMPLEMENTATION y apoyado en IA

def WinogradOriginalImpl(matrix_A, matrix_B):
    # Obtiene las dimensiones de las matrices
    rows_A = len(matrix_A)
    cols_A = len(matrix_A[0])
    cols_B = len(matrix_B[0])
    #Inicializa la variable resultado con ceros
    Result = [[0.0] * cols_B for _ in range(rows_A)]

    #Calcula la paridad de la cantidad de columnas de la matriz A.
    upsilon = cols_A % 2
    #calcula el número de columnas de la matriz A que se pueden procesar en pares en el algoritmo
    gamma = cols_A - upsilon
    #Inicializa con 0s los arreglos y y z
    y = [0.0] * cols_B
    z = [0.0] * rows_A

    # Calcula los arreglos y y z
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

     # Realiza la multiplicación de matrices
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