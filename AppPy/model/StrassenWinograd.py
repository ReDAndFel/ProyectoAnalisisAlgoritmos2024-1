from math import floor,log
from .NaivStandard import naiv_standard

def strassen_winograd(matrizA, matrizB):

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
            
    matrizResultadoAuxiliar = strassen_winograd_step(nuevaMatrizA, nuevaMatrizB, matrizResultadoAuxiliar, nuevoTamanio, m)
    
    for i in range(cantidadFilasMatrices):
        for j in range(cantidadColumnasMatrices):
            matrizResultado[i][j] = matrizResultadoAuxiliar[i][j]
            
    return matrizResultado

def strassen_winograd_step(matrizA, matrizB, matrizResultado, cantidadFilasMatrices, m):

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
        
        matrizA1 = []
        matrizA2 = []
        matrizB1 = []
        matrizB2 = []
        
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
        
        auxiliar8 = []
        auxiliar9 = []

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
            
            matrizA1.append([])
            matrizA2.append([])
            matrizB1.append([])
            matrizB2.append([])
            
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
            
            auxiliar8.append([])
            auxiliar9.append([])
            
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
        
        matrizA1 = [list(map(sum,zip(rowA11, rowA21))) for rowA11, rowA21 in zip(matrizA11, matrizA21)]
        matrizA2 = [list(map(sum,zip(rowA22, rowA1))) for rowA22, rowA1 in zip(matrizA22, matrizA1)]
       
        matrizB1 = [list(map(sum,zip(rowB22, rowB12))) for rowB22, rowB12 in zip(matrizB22, matrizB12)]
        matrizB2 = [list(map(sum, zip(rowB1, rowB11))) for rowB1, rowB11 in zip(matrizB1, matrizB11)]
       
        auxiliar1 = strassen_winograd_step(matrizA11, matrizB11, auxiliar1, nuevoTamanio, m)
        auxiliar2 = strassen_winograd_step(matrizA12, matrizB21, auxiliar2, nuevoTamanio, m)  
        auxiliar3 = strassen_winograd_step(matrizA2, matrizB2, auxiliar3, nuevoTamanio, m)
       
        ayudante1 = [list(map(sum,zip(rowA21, rowA22))) for rowA21, rowA22 in zip(matrizA21, matrizA22)]
        ayudante2 = [list(map(sum,zip(rowB12, rowB11))) for rowB12, rowB11 in zip(matrizB12, matrizB11)]
        auxiliar4 = strassen_winograd_step(ayudante1, ayudante2, auxiliar4, nuevoTamanio, m)
       
        auxiliar5 = strassen_winograd_step(matrizA1, matrizB1, auxiliar5, nuevoTamanio, m)
       
        ayudante1 = [list(map(sum,zip(rowA12, rowA2))) for rowA12, rowA2 in zip(matrizA12, matrizA2)]  
        auxiliar6 = strassen_winograd_step(ayudante1, matrizB22, auxiliar6, nuevoTamanio, m)
       
        ayudante1 = [list(map(sum,zip(rowB21, rowB2))) for rowB21, rowB2 in zip(matrizB21, matrizB2)]
        auxiliar7 = strassen_winograd_step(matrizA22, ayudante1, auxiliar7, nuevoTamanio, m)
       
        auxiliar8 = [list(map(sum,zip(rowA1, rowA3))) for rowA1, rowA3 in zip(auxiliar1, auxiliar3)]
        auxiliar9 = [list(map(sum,zip(rowA8, rowA4))) for rowA8, rowA4 in zip(auxiliar8, auxiliar4)]
       
       # Calcular partes de la matriz resultado
        matrizResultadoParte11 = [list(map(sum,zip(rowA1, rowA2))) for rowA1, rowA2 in zip(auxiliar1, auxiliar2)]
       
        matrizResultadoParte12 = [list(map(sum,zip(rowA9, rowA6))) for rowA9, rowA6 in zip(auxiliar9, auxiliar6)]
       
        ayudante1 = [list(map(sum,zip(rowA8, rowA5))) for rowA8, rowA5 in zip(auxiliar8, auxiliar5)]
        matrizResultadoParte21 =[list(map(sum,zip(rowAyd, rowA7))) for rowAyd, rowA7 in zip(ayudante1, auxiliar7)]
       
        matrizResultadoParte22 = [list(map(sum,zip(rowA9, rowA5))) for rowA9, rowA5 in zip(auxiliar9, auxiliar5)]
       

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