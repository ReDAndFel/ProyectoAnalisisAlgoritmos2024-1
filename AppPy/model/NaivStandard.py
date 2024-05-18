#Algoritmo basado en el libro METHODS OF MATRIX MULTIPLICATION AN OVERVIEW OF SEVERAL METHODS AND THEIR IMPLEMENTATION y apoyado en IA

def naiv_standard(matrizA, matrizB, matrizResultado, cantidadFilasMatrices, cantidadColumnasMatrices, cantidadMaximaIteracionesFilaColumna):
    
    aux = 0.0
    # Realiza la multiplicación de matrices
    for i in range(cantidadFilasMatrices):
        for j in range(cantidadColumnasMatrices):
            aux = 0.0
            # Realiza la multiplicación de elementos y suma los resultados
            for k in range(cantidadMaximaIteracionesFilaColumna):
                aux += matrizA[i][k] * matrizB[k][j]
            matrizResultado[i][j] = aux
            
    return matrizResultado