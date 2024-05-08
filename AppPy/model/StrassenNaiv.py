from math import floor,log
from .NaivStandard import naiv_standard

def strassen_naiv(matrizA, matrizB):
    
    cantidadFilasMatrices = len(matrizA)
    cantidadColumnasMatrices = len(matrizB[0])
    delimitadorMaximaIteracionesFilaColumna = len(matrizA[0])
    matrizResultado = [[0 for _ in range(cantidadColumnasMatrices)] for _ in range(cantidadFilasMatrices)]

    tamanioMaximo = max(cantidadFilasMatrices, delimitadorMaximaIteracionesFilaColumna)
    tamanioMaximo = max(tamanioMaximo, cantidadFilasMatrices)
    
    if tamanioMaximo < 16:
        tamanioMaximo = 16 # Si no, no es posible computar K
        
    k = floor(log(tamanioMaximo)/log(2)) - 4
    m = floor(tamanioMaximo * pow(2,-k)) + 1
    nuevoTamanio = m * pow(2,k)
    
    nuevaMatrizA = []
    nuevaMatrizB = [] 
    matrizResultadoAuxiliar = []
    
    # Asignar memoria e inicializar Inicializar cada elemento de las nuevas matrices A y B con ceros
   
    for i in range(nuevoTamanio):
         nuevaMatrizA.append([0 for i in range(nuevoTamanio)] )
         nuevaMatrizB.append([0 for i in range(nuevoTamanio)] )
         matrizResultadoAuxiliar.append([0 for i in range(nuevoTamanio)] )
            
    # Asignamos en cada posición i,j de las nuevas matrices A y B los valores que están en las matrices A y B respectivamente
    for i in range(cantidadFilasMatrices):
        for j in range(cantidadColumnasMatrices):
            nuevaMatrizA[i][j] = matrizA[i][j]
            
    for i in range(cantidadFilasMatrices):
        for j in range(cantidadColumnasMatrices):
            nuevaMatrizB[i][j] = matrizB[i][j]
            
    matrizResultadoAuxiliar = strassen_naiv_step(nuevaMatrizA, nuevaMatrizB, matrizResultadoAuxiliar, nuevoTamanio, m)
    
    for i in range(cantidadFilasMatrices):
        for j in range(cantidadColumnasMatrices):
            matrizResultado[i][j] = matrizResultadoAuxiliar[i][j]
            
    return matrizResultado

def strassen_naiv_step(matrizA, matrizB, matrizResultado, cantidadFilasMatrices, m):

    nuevoTamanio = 0
    if (cantidadFilasMatrices % 2 == 0) and (cantidadFilasMatrices > m):
        nuevoTamanio = cantidadFilasMatrices // 2
        
        matrizA11 = []
        matrizA12 = []
        matrizA21 = []
        matrizA22 = []
        
        matrizB11 = []
        matrizB12 = [] 
        matrizB21 = []
        matrizB22 = []
        
        matrizResultadoParte11 = []
        matrizResultadoParte12 = []
        matrizResultadoParte21 = []
        matrizResultadoParte22 = []
        
        ayudante1 = []
        ayudante2 = []
        
        auxiliar1 = []
        auxiliar2 = []
        auxiliar3 = []
        auxiliar4 = []
        auxiliar5 = []
        auxiliar6 = []
        auxiliar7 = []        
        for i in range(nuevoTamanio):
            matrizA11.append([0] * nuevoTamanio)
            matrizA12.append([0] * nuevoTamanio)
            matrizA21.append([0] * nuevoTamanio)
            matrizA22.append([0] * nuevoTamanio)
                
            matrizB11.append([0] * nuevoTamanio)
            matrizB12.append([0] * nuevoTamanio)
            matrizB21.append([0] * nuevoTamanio)
            matrizB22.append([0] * nuevoTamanio)
                
            matrizResultadoParte11.append([0] * nuevoTamanio)
            matrizResultadoParte12.append([0] * nuevoTamanio)
            matrizResultadoParte21.append([0] * nuevoTamanio)
            matrizResultadoParte22.append([0] * nuevoTamanio)
                
            ayudante1.append([0] * nuevoTamanio)
            ayudante2.append([0] * nuevoTamanio)
            
            auxiliar1.append([0] * nuevoTamanio)
            auxiliar2.append([0] * nuevoTamanio)
            auxiliar3.append([0] * nuevoTamanio)
            auxiliar4.append([0] * nuevoTamanio)
            auxiliar5.append([0] * nuevoTamanio)
            auxiliar6.append([0] * nuevoTamanio)
            auxiliar7.append([0] * nuevoTamanio)
            
        # Llenamos las matrices
        for i in range(nuevoTamanio):
            for j in range(nuevoTamanio):
                matrizA11[i][j] = matrizA[i][j]
                matrizA12[i][j] = matrizA[i][nuevoTamanio + j]
                matrizA21[i][j] = matrizA[nuevoTamanio + i][j] 
                matrizA22[i][j] = matrizA[nuevoTamanio + i][nuevoTamanio + j]

                matrizB11[i][j] = matrizB[i][j]
                matrizB12[i][j] = matrizB[i][nuevoTamanio + j]
                matrizB21[i][j] = matrizB[nuevoTamanio + i][j]
                matrizB22[i][j] = matrizB[nuevoTamanio + i][nuevoTamanio + j]
        
        # computing the seven aux. variables

        plus(matrizA11, matrizA22, ayudante1, nuevoTamanio)
        plus(matrizB11, matrizB22, ayudante2, nuevoTamanio)
        strassen_naiv_step(ayudante1, ayudante2, auxiliar1, nuevoTamanio, m)
        plus(matrizA21, matrizA22, ayudante1, nuevoTamanio)
        strassen_naiv_step(ayudante1, matrizB11, auxiliar2, nuevoTamanio, m)
        minus(matrizB12, matrizB22, ayudante1, nuevoTamanio)
        strassen_naiv_step(matrizA11, ayudante1, auxiliar3, nuevoTamanio, m)
        minus(matrizB21, matrizB11, ayudante1, nuevoTamanio)
        strassen_naiv_step(matrizA22, ayudante1, auxiliar4, nuevoTamanio, m)
        plus(matrizA11, matrizA12, ayudante1, nuevoTamanio)
        strassen_naiv_step(ayudante1, matrizB22, auxiliar5, nuevoTamanio, m)
        minus(matrizA21, matrizA11, ayudante1, nuevoTamanio)
        plus(matrizB11, matrizB12, ayudante2, nuevoTamanio)
        strassen_naiv_step(ayudante1, ayudante2, auxiliar6, nuevoTamanio, m)
        minus(matrizA12, matrizA22, ayudante1, nuevoTamanio)
        plus(matrizB21, matrizB22, ayudante2, nuevoTamanio)
        strassen_naiv_step(ayudante1, ayudante2, auxiliar7, nuevoTamanio, m)
        #computing the four parts of the result
        plus(auxiliar1, auxiliar4, matrizResultadoParte11, nuevoTamanio)
        minus(matrizResultadoParte11, auxiliar5, matrizResultadoParte11, nuevoTamanio)
        plus(matrizResultadoParte11, auxiliar7, matrizResultadoParte11, nuevoTamanio)
        plus(auxiliar3, auxiliar5, matrizResultadoParte12, nuevoTamanio)
        plus(auxiliar2, auxiliar4, matrizResultadoParte21, nuevoTamanio)
        plus(auxiliar1, auxiliar3, matrizResultadoParte22, nuevoTamanio)
        minus(matrizResultadoParte22, auxiliar2, matrizResultadoParte22, nuevoTamanio)
        plus(matrizResultadoParte22, auxiliar6, matrizResultadoParte22, nuevoTamanio)        

        # Almacenar resultados en la matriz resultado
        for i in range(nuevoTamanio):
            for j in range(nuevoTamanio):
                matrizResultado[i][j] = matrizResultadoParte11[i][j]
        
        for i in range(nuevoTamanio):
            for j in range(nuevoTamanio):
                matrizResultado[i][nuevoTamanio + j] = matrizResultadoParte12[i][j]
        
        for i in range(nuevoTamanio):
            for j in range(nuevoTamanio):
                matrizResultado[nuevoTamanio + i][j] = matrizResultadoParte21[i][j]
        
        for i in range(nuevoTamanio):
            for j in range(nuevoTamanio):
                matrizResultado[nuevoTamanio + i][nuevoTamanio + j] = matrizResultadoParte22[i][j]
        
    else:
        # Usar algoritmo naiv
        matrizResultado = naiv_standard(matrizA, matrizB, matrizResultado, len(matrizA), len(matrizB), len(matrizResultado))
    
    return matrizResultado

def plus(A, B, Result, newSize):
    for i in range(newSize):
        for j in range(newSize):
            Result[i][j] = A[i][j] + B[i][j]

def minus(A, B, Result, newSize):
    for i in range(newSize):
        for j in range(newSize):
            Result[i][j] = A[i][j] - B[i][j]            


