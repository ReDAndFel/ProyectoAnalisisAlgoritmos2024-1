#Algoritmo basado en el libro METHODS OF MATRIX MULTIPLICATION AN OVERVIEW OF SEVERAL METHODS AND THEIR IMPLEMENTATION y apoyado en IA

from math import floor, log
from .NaivStandard import naiv_standard


def strassen_naiv(matrixA, matrixB):

    # Obtiene las dimensiones de las matrices
    rows = len(matrixA)
    cols = len(matrixB[0])
    maxIt = len(matrixA[0])
    #Inicializa la matriz resultado con 0s 
    matrixResult = [[0 for _ in range(cols)] for _ in range(rows)]
    
    # Encuentra la mayor dimensión entre las matrices
    maxSize = max(rows, maxIt)
    maxSize = max(maxSize, rows)

    # Asegura que la dimensión sea al menos 16 para la implementación de Strassen
    if maxSize < 16:
        maxSize = 16

    # Calcula los parámetros necesarios para el algoritmo de Strassen
    k = floor(log(maxSize) / log(2)) - 4
    m = floor(maxSize * pow(2, -k)) + 1
    newSize = m * pow(2, k)

    #Inicializa las nuevas matrices A y B y la matriz resultado auxiliar
    newMatrixA = []
    newMatrixB = []
    matrixResultAux = []

    # Llena las matrices con 0s

    for i in range(newSize):
        newMatrixA.append([0 for i in range(newSize)])
        newMatrixB.append([0 for i in range(newSize)])
        matrixResultAux.append([0 for i in range(newSize)])

    # copia la matrixA y matrixB
    for i in range(rows):
        for j in range(cols):
            newMatrixA[i][j] = matrixA[i][j]
            newMatrixB[i][j] = matrixB[i][j]

    # Realiza la multiplicación de matrices utilizando el algoritmo de Strassen
    matrixResultAux = strassen_naiv_step(
        newMatrixA, newMatrixB, matrixResultAux, newSize, m
    )

    # Llena la matriz resultante con los valores calculados
    for i in range(rows):
        for j in range(cols):
            matrixResult[i][j] = matrixResultAux[i][j]

    return matrixResult

#Paso recursivo del algoritmo de multiplicación de matrices Strassen.
def strassen_naiv_step(matrixA, matrixB, matrizResult, size, m):

    #Calcula el nuevo tamaño
    newSize = 0
    if (size % 2 == 0) and (size > m):
        newSize = size // 2
        # Secciona las matrices en submatrices
        matrixA11 = []
        matrixA12 = []
        matrixA21 = []
        matrixA22 = []
        matrixB11 = []
        matrixB12 = []
        matrixB21 = []
        matrixB22 = []
        matrixResult11 = []
        matrixResult12 = []
        matrixResult21 = []
        matrixResult22 = []
        helper1 = []
        helper2 = []
        aux1 = []
        aux2 = []
        aux3 = []
        aux4 = []
        aux5 = []
        aux6 = []
        aux7 = []

        # Llena las submatrices matrix,helper y aux con 0s
        for i in range(newSize):
            matrixA11.append([0] * newSize)
            matrixA12.append([0] * newSize)
            matrixA21.append([0] * newSize)
            matrixA22.append([0] * newSize)
            matrixB11.append([0] * newSize)
            matrixB12.append([0] * newSize)
            matrixB21.append([0] * newSize)
            matrixB22.append([0] * newSize)
            matrixResult11.append([0] * newSize)
            matrixResult12.append([0] * newSize)
            matrixResult21.append([0] * newSize)
            matrixResult22.append([0] * newSize)
            helper1.append([0] * newSize)
            helper2.append([0] * newSize)
            aux1.append([0] * newSize)
            aux2.append([0] * newSize)
            aux3.append([0] * newSize)
            aux4.append([0] * newSize)
            aux5.append([0] * newSize)
            aux6.append([0] * newSize)
            aux7.append([0] * newSize)

        # Llena las submatrices matrix
        for i in range(newSize):
            for j in range(newSize):
                matrixA11[i][j] = matrixA[i][j]
                matrixA12[i][j] = matrixA[i][newSize + j]
                matrixA21[i][j] = matrixA[newSize + i][j]
                matrixA22[i][j] = matrixA[newSize + i][newSize + j]

                matrixB11[i][j] = matrixB[i][j]
                matrixB12[i][j] = matrixB[i][newSize + j]
                matrixB21[i][j] = matrixB[newSize + i][j]
                matrixB22[i][j] = matrixB[newSize + i][newSize + j]

        # Calcula las siete variables auxiliares
        plus(matrixA11, matrixA22, helper1, newSize)
        plus(matrixB11, matrixB22, helper2, newSize)
        strassen_naiv_step(helper1, helper2, aux1, newSize, m)
        plus(matrixA21, matrixA22, helper1, newSize)
        strassen_naiv_step(helper1, matrixB11, aux2, newSize, m)
        minus(matrixB12, matrixB22, helper1, newSize)
        strassen_naiv_step(matrixA11, helper1, aux3, newSize, m)
        minus(matrixB21, matrixB11, helper1, newSize)
        strassen_naiv_step(matrixA22, helper1, aux4, newSize, m)
        plus(matrixA11, matrixA12, helper1, newSize)
        strassen_naiv_step(helper1, matrixB22, aux5, newSize, m)
        minus(matrixA21, matrixA11, helper1, newSize)
        plus(matrixB11, matrixB12, helper2, newSize)
        strassen_naiv_step(helper1, helper2, aux6, newSize, m)
        minus(matrixA12, matrixA22, helper1, newSize)
        plus(matrixB21, matrixB22, helper2, newSize)
        strassen_naiv_step(helper1, helper2, aux7, newSize, m)

        # Calcula las cuatro partes del resultado
        plus(aux1, aux4, matrixResult11, newSize)
        minus(matrixResult11, aux5, matrixResult11, newSize)
        plus(matrixResult11, aux7, matrixResult11, newSize)
        plus(aux3, aux5, matrixResult12, newSize)
        plus(aux2, aux4, matrixResult21, newSize)
        plus(aux1, aux3, matrixResult22, newSize)
        minus(matrixResult22, aux2, matrixResult22, newSize)
        plus(matrixResult22, aux6, matrixResult22, newSize)

        # Llena la matriz resultado con los resultados de las matrices resultados auxiliares
        for i in range(newSize):
            for j in range(newSize):
                matrizResult[i][j] = matrixResult11[i][j]

        for i in range(newSize):
            for j in range(newSize):
                matrizResult[i][newSize + j] = matrixResult12[i][j]

        for i in range(newSize):
            for j in range(newSize):
                matrizResult[newSize + i][j] = matrixResult21[i][j]

        for i in range(newSize):
            for j in range(newSize):
                matrizResult[newSize + i][newSize + j] = matrixResult22[i][j]

    else:
        # Usa el algoritmo naivstandard
        matrizResult = naiv_standard(
            matrixA,
            matrixB,
            matrizResult,
            len(matrixA),
            len(matrixB),
            len(matrizResult),
        )

    return matrizResult

#Suma de matrices
def plus(A, B, Result, newSize):
    for i in range(newSize):
        for j in range(newSize):
            Result[i][j] = A[i][j] + B[i][j]

#Resta de matrices
def minus(A, B, Result, newSize):
    for i in range(newSize):
        for j in range(newSize):
            Result[i][j] = A[i][j] - B[i][j]
