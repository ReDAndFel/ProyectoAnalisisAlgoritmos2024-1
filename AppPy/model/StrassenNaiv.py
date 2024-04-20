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
        for j in range(delimitadorMaximaIteracionesFilaColumna):
            nuevaMatrizA[i][j] = matrizA[i][j]
            
    for i in range(delimitadorMaximaIteracionesFilaColumna):
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

        # Asignar memoria para cada fila
        for i in range(nuevoTamanio):
            matrizA11.append([])
            matrizA12.append([])
            matrizA21.append([])
            matrizA22.append([])
            
            matrizB11.append([])
            matrizB12.append([])
            matrizB21.append([])
            matrizB22.append([])
            
            matrizResultadoParte11.append([])
            matrizResultadoParte12.append([])
            matrizResultadoParte21.append([])
            matrizResultadoParte22.append([])
            
            ayudante1.append([])
            ayudante2.append([])
            
            auxiliar1.append([])
            auxiliar2.append([])
            auxiliar3.append([])
            auxiliar4.append([])
            auxiliar5.append([])
            auxiliar6.append([])
            auxiliar7.append([])
            
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
        
        ayudante1 = [list(map(sum, zip(filaA11, filaA22))) for filaA11, filaA22 in zip(matrizA11, matrizA22)]
        ayudante2 = [list(map(sum, zip(filaB11, filaB22))) for filaB11, filaB22 in zip(matrizB11, matrizB22)]
        
        auxiliar1 = strassen_naiv_step(ayudante1, ayudante2, auxiliar1, nuevoTamanio, m)
        
        ayudante1 = [list(map(sum, zip(filaA21, filaA22))) for filaA21, filaA22 in zip(matrizA21, matrizA22)]        
        auxiliar2 = strassen_naiv_step(ayudante1, matrizB11, auxiliar2, nuevoTamanio, m)
        
        ayudante1 = [list(map(sum, zip(filaA21, filaA22))) for filaA21, filaA22 in zip(matrizA21, matrizA22)]        
        auxiliar3 = strassen_naiv_step(matrizA11, ayudante1, auxiliar3, nuevoTamanio, m)
        
        ayudante1 = [list(map(sum, zip(filaB21, filaB11))) for filaB21, filaB11 in zip(matrizB21, matrizB11)]        
        auxiliar4 = strassen_naiv_step(matrizA22, ayudante1, auxiliar4, nuevoTamanio, m)
        
        ayudante1 = [list(map(sum, zip(filaA11, filaA12))) for filaA11, filaA12 in zip(matrizA11, matrizA12)]        
        auxiliar5 = strassen_naiv_step(ayudante1, matrizB22, auxiliar5, nuevoTamanio, m)
        
        ayudante1 = [list(map(sum, zip(filaA21, filaA11))) for filaA21, filaA11 in zip(matrizA21, matrizA11)]
        ayudante2 = [list(map(sum, zip(filaB11, filaB12))) for filaB11, filaB12 in zip(matrizB11, matrizB12)]        
        auxiliar6 = strassen_naiv_step(ayudante1, ayudante2, auxiliar6, nuevoTamanio, m)
        
        ayudante1 = [list(map(sum, zip(filaA12, filaA22))) for filaA12, filaA22 in zip(matrizA12, matrizA22)]
        ayudante2 = [list(map(sum, zip(filaB21, filaB22))) for filaB21, filaB22 in zip(matrizB21, matrizB22)]        
        auxiliar7 = strassen_naiv_step(ayudante1, ayudante2, auxiliar7, nuevoTamanio, m)
        
        # computing the four parts of the result
        matrizResultadoParte11 = [list(map(sum, zip(filaAux1, filaAux4))) for filaAux1, filaAux4 in zip(auxiliar1, auxiliar4)]
        matrizResultadoParte11 = [list(map(sum, zip(filaAux5, filaParte11))) for filaAux5, filaParte11 in zip(auxiliar5, matrizResultadoParte11)]
        matrizResultadoParte11 = [list(map(sum, zip(filaAux7, filaParte11))) for filaAux7, filaParte11 in zip(auxiliar7, matrizResultadoParte11)]
        
        matrizResultadoParte12 = [list(map(sum, zip(filaAux3, filaAux5))) for filaAux3, filaAux5 in zip(auxiliar3, auxiliar5)]
        
        matrizResultadoParte21 = [list(map(sum, zip(filaAux3, filaAux5))) for filaAux3, filaAux5 in zip(auxiliar3, auxiliar5)]
        
        matrizResultadoParte22 = [list(map(sum, zip(filaAux1, filaAux3))) for filaAux1, filaAux3 in zip(auxiliar1, auxiliar3)]
        matrizResultadoParte22 = [list(map(sum, zip(filaAux2, filaParte22))) for filaAux2, filaParte22 in zip(auxiliar2, matrizResultadoParte22)]
        matrizResultadoParte22 = [list(map(sum, zip(filaAux6, filaParte22))) for filaAux6, filaParte22 in zip(auxiliar6, matrizResultadoParte22)]

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

