#Algoritmo basado en el libro METHODS OF MATRIX MULTIPLICATION AN OVERVIEW OF SEVERAL METHODS AND THEIR IMPLEMENTATION y apoyado en IA

def NaivOnArrayImpl(matrix_A, matrix_B):
    #Obtiene las cantidades de columnas y filas   
    rows_A = len(matrix_A)
    cols_A = len(matrix_A[0])
    cols_B = len(matrix_B[0])

    #Inicializa con ceros la matriz result
    result = [[0.0] * cols_B for _ in range(rows_A)]  # Crear matriz de resultados

    # Realiza la multiplicación de matrices
    for i in range(rows_A):
        for j in range(cols_B):
            result[i][j] = 0.0  
            for k in range(cols_A):
                # Realiza la multiplicación de elementos y suma los resultados
                result[i][j] += matrix_A[i][k] * matrix_B[k][j]

    return result