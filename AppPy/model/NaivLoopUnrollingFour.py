#Algoritmo basado en el libro METHODS OF MATRIX MULTIPLICATION AN OVERVIEW OF SEVERAL METHODS AND THEIR IMPLEMENTATION y apoyado en IA

def NaivLoopUnrollingFourImpl(matrix_A, matrix_B):
    #Obtiene las cantidades de columnas y filas
    rows_A = len(matrix_A)
    cols_A = len(matrix_A[0])
    cols_B = len(matrix_B[0])

    #Inicializa con ceros la matriz result
    Result = [[0.0] * cols_B for _ in range(rows_A)]

    # Realiza la multiplicación de matrices utilizando bucles desenrollados
    if cols_A % 4 == 0:
        for i in range(rows_A):
            for j in range(cols_B):
                aux = 0.0
                for k in range(0, cols_A, 4):
                    # Realiza la multiplicación de 4 elementos a la vez y suma los resultados
                    aux += matrix_A[i][k] * matrix_B[k][j] + matrix_A[i][k + 1] * matrix_B[k + 1][j] \
                           + matrix_A[i][k + 2] * matrix_B[k + 2][j] + matrix_A[i][k + 3] * matrix_B[k + 3][j]
                # Añade el producto de los elementos
                Result[i][j] = aux
    elif cols_A % 4 == 1:
        cols_A_minus_one = cols_A - 1
        for i in range(rows_A):
            for j in range(cols_B):
                aux = 0.0
                # Realiza la multiplicación de 4 elementos a la vez y suma los resultados
                for k in range(0, cols_A_minus_one, 4):
                    aux += matrix_A[i][k] * matrix_B[k][j] + matrix_A[i][k + 1] * matrix_B[k + 1][j] \
                           + matrix_A[i][k + 2] * matrix_B[k + 2][j] + matrix_A[i][k + 3] * matrix_B[k + 3][j]
                # Añade el producto de los elementos
                Result[i][j] = aux + matrix_A[i][cols_A_minus_one] * matrix_B[cols_A_minus_one][j]
    elif cols_A % 4 == 2:
        cols_A_minus_two = cols_A - 2
        cols_A_minus_one = cols_A - 1
        for i in range(rows_A):
            for j in range(cols_B):
                aux = 0.0
                for k in range(0, cols_A_minus_two, 4):
                    # Realiza la multiplicación de 4 elementos a la vez y suma los resultados
                    aux += matrix_A[i][k] * matrix_B[k][j] + matrix_A[i][k + 1] * matrix_B[k + 1][j] \
                           + matrix_A[i][k + 2] * matrix_B[k + 2][j] + matrix_A[i][k + 3] * matrix_B[k + 3][j]
                # Añade el producto de los elementos
                Result[i][j] = aux + matrix_A[i][cols_A_minus_two] * matrix_B[cols_A_minus_two][j] \
                               + matrix_A[i][cols_A_minus_one] * matrix_B[cols_A_minus_one][j]
    else:  # cols_A % 4 == 3
        cols_A_minus_three = cols_A - 3
        cols_A_minus_two = cols_A - 2
        cols_A_minus_one = cols_A - 1
        for i in range(rows_A):
            for j in range(cols_B):
                aux = 0.0
                # Realiza la multiplicación de 4 elementos a la vez y suma los resultados
                for k in range(0, cols_A_minus_three, 4):
                    aux += matrix_A[i][k] * matrix_B[k][j] + matrix_A[i][k + 1] * matrix_B[k + 1][j] \
                           + matrix_A[i][k + 2] * matrix_B[k + 2][j] + matrix_A[i][k + 3] * matrix_B[k + 3][j]
                # Añade el producto de los elementos
                Result[i][j] = aux + matrix_A[i][cols_A_minus_three] * matrix_B[cols_A_minus_three][j] \
                               + matrix_A[i][cols_A_minus_two] * matrix_B[cols_A_minus_two][j] \
                               + matrix_A[i][cols_A_minus_one] * matrix_B[cols_A_minus_one][j]
    
    return Result