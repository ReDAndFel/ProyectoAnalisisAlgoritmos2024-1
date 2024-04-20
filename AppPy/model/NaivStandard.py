def naiv_standard(matrizA, matrizB, matrizResultado, cantidadFilasMatrices, cantidadColumnasMatrices, cantidadMaximaIteracionesFilaColumna):
    
    aux = 0.0
    for i in range(cantidadFilasMatrices):
        for j in range(cantidadColumnasMatrices):
            aux = 0.0
            for k in range(cantidadMaximaIteracionesFilaColumna):
                aux += matrizA[i][k] * matrizB[k][j]
            matrizResultado[i][j] = aux
            
    return matrizResultado