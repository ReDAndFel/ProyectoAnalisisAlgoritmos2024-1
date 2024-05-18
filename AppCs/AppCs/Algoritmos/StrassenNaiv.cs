//Algoritmo basado en el libro METHODS OF MATRIX MULTIPLICATION AN OVERVIEW OF SEVERAL METHODS AND THEIR IMPLEMENTATION y apoyado en IA
using System;
using services.interfaces;
public class StrassenNaive : AlgorithmInterface
{
    public static long[][] StrassenNaivMultiply(long[][] matrixA, long[][] matrixB)
    {
        //Obtiene las dimensiones de las matrices
        int rows = matrixA.Length;
        int cols = matrixB[0].Length;
        int maxIt = matrixA[0].Length;
        //Inicializa la matriz resultado con 0s 
        long[][] matrixResult = new long[rows][];

        for (int i = 0; i < rows; i++)
        {
            matrixResult[i] = new long[cols];
        }
        //Encuentra la mayor dimensión entre las matrices
        int maxSize = Math.Max(rows, maxIt);
        maxSize = Math.Max(maxSize, rows);

        //Asegura que la dimensión sea al menos 16 para la implementación de Strassen
        if (maxSize < 16)
        {
            maxSize = 16;
        }
        
        //Calcula los parámetros necesarios para el algoritmo de Strassen
        int k = (int)Math.Floor(Math.Log(maxSize) / Math.Log(2)) - 4;
        int m = (int)(maxSize * Math.Pow(2, -k)) + 1;
        int newSize = m * (int)Math.Pow(2, k);

        //Inicializa las nuevas matrices A y B y la matriz resultado auxiliar
        long[][] newMatrixA = new long[newSize][];
        long[][] newMatrixB = new long[newSize][];
        long[][] matrixResultAux = new long[newSize][];

        for (int i = 0; i < newSize; i++)
        {
            newMatrixA[i] = new long[newSize];
            newMatrixB[i] = new long[newSize];
            matrixResultAux[i] = new long[newSize];
        }
        
        //copia la matrixA y matrixB
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                newMatrixA[i][j] = matrixA[i][j];
                newMatrixB[i][j] = matrixB[i][j];
            }
        }

        //Realiza la multiplicación de matrices utilizando el algoritmo de Strassen
        matrixResultAux = StrassenNaivStep(newMatrixA, newMatrixB, matrixResultAux, newSize, m);

        //Llena la matriz resultante con los valores calculados
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                matrixResult[i][j] = matrixResultAux[i][j];
            }
        }

        return matrixResult;
    }

    //Paso recursivo del algoritmo de multiplicación de matrices Strassen.
    private static long[][] StrassenNaivStep(long[][] matrixA, long[][] matrixB, long[][] matrixResult, int size, int m)
    {
        //Calcula el nuevo tamaño
        int newSize = 0;
        if (size % 2 == 0 && size > m)
        {
            newSize = size / 2;
            
            //Secciona las matrices en submatrices
            long[][] matrixA11 = new long[newSize][];
            long[][] matrixA12 = new long[newSize][];
            long[][] matrixA21 = new long[newSize][];
            long[][] matrixA22 = new long[newSize][];
            long[][] matrixB11 = new long[newSize][];
            long[][] matrixB12 = new long[newSize][];
            long[][] matrixB21 = new long[newSize][];
            long[][] matrixB22 = new long[newSize][];
            long[][] matrixResult11 = new long[newSize][];
            long[][] matrixResult12 = new long[newSize][];
            long[][] matrixResult21 = new long[newSize][];
            long[][] matrixResult22 = new long[newSize][];
            long[][] helper1 = new long[newSize][];
            long[][] helper2 = new long[newSize][];
            long[][] aux1 = new long[newSize][];
            long[][] aux2 = new long[newSize][];
            long[][] aux3 = new long[newSize][];
            long[][] aux4 = new long[newSize][];
            long[][] aux5 = new long[newSize][];
            long[][] aux6 = new long[newSize][];
            long[][] aux7 = new long[newSize][];
            
            for (int i = 0; i < newSize; i++)
            {
                matrixA11[i] = new long[newSize];
                matrixA12[i] = new long[newSize];
                matrixA21[i] = new long[newSize];
                matrixA22[i] = new long[newSize];
                matrixB11[i] = new long[newSize];
                matrixB12[i] = new long[newSize];
                matrixB21[i] = new long[newSize];
                matrixB22[i] = new long[newSize];
                matrixResult11[i] = new long[newSize];
                matrixResult12[i] = new long[newSize];
                matrixResult21[i] = new long[newSize];
                matrixResult22[i] = new long[newSize];
                helper1[i] = new long[newSize];
                helper2[i] = new long[newSize];
                aux1[i] = new long[newSize];
                aux2[i] = new long[newSize];
                aux3[i] = new long[newSize];
                aux4[i] = new long[newSize];
                aux5[i] = new long[newSize];
                aux6[i] = new long[newSize];
                aux7[i] = new long[newSize];
            }

            //Llena las submatrices matrix
            for (int i = 0; i < newSize; i++)
            {
                for (int j = 0; j < newSize; j++)
                {
                    matrixA11[i][j] = matrixA[i][j];
                    matrixA12[i][j] = matrixA[i][newSize + j];
                    matrixA21[i][j] = matrixA[newSize + i][j];
                    matrixA22[i][j] = matrixA[newSize + i][newSize + j];

                    matrixB11[i][j] = matrixB[i][j];
                    matrixB12[i][j] = matrixB[i][newSize + j];
                    matrixB21[i][j] = matrixB[newSize + i][j];
                    matrixB22[i][j] = matrixB[newSize + i][newSize + j];
                }
            }

            // Calcula las siete variables auxiliares
            Plus(matrixA11, matrixA22, helper1, newSize);
            Plus(matrixB11, matrixB22, helper2, newSize);
            StrassenNaivStep(helper1, helper2, aux1, newSize, m);
            Plus(matrixA21, matrixA22, helper1, newSize);
            StrassenNaivStep(helper1, matrixB11, aux2, newSize, m);
            Minus(matrixB12, matrixB22, helper1, newSize);
            StrassenNaivStep(matrixA11, helper1, aux3, newSize, m);
            Minus(matrixB21, matrixB11, helper1, newSize);
            StrassenNaivStep(matrixA22, helper1, aux4, newSize, m);
            Plus(matrixA11, matrixA12, helper1, newSize);
            StrassenNaivStep(helper1, matrixB22, aux5, newSize, m);
            Minus(matrixA21, matrixA11, helper1, newSize);
            Plus(matrixB11, matrixB12, helper2, newSize);
            StrassenNaivStep(helper1, helper2, aux6, newSize, m);
            Minus(matrixA12, matrixA22, helper1, newSize);
            Plus(matrixB21, matrixB22, helper2, newSize);
            StrassenNaivStep(helper1, helper2, aux7, newSize, m);

            // Calcula las cuatro partes del resultado
            Plus(aux1, aux4, matrixResult11, newSize);
            Minus(matrixResult11, aux5, matrixResult11, newSize);
            Plus(matrixResult11, aux7, matrixResult11, newSize);
            Plus(aux3, aux5, matrixResult12, newSize);
            Plus(aux2, aux4, matrixResult21, newSize);
            Plus(aux1, aux3, matrixResult22, newSize);
            Minus(matrixResult22, aux2, matrixResult22, newSize);
            Plus(matrixResult22, aux6, matrixResult22, newSize);

            // Llena la matriz resultado con los resultados de las matrices resultados auxiliares
            for (int i = 0; i < newSize; i++)
            {
                for (int j = 0; j < newSize; j++)
                {
                    matrixResult[i][j] = matrixResult11[i][j];
                }
            }

            for (int i = 0; i < newSize; i++)
            {
                for (int j = 0; j < newSize; j++)
                {
                    matrixResult[i][newSize + j] = matrixResult12[i][j];
                }
            }

            for (int i = 0; i < newSize; i++)
            {
                for (int j = 0; j < newSize; j++)
                {
                    matrixResult[newSize + i][j] = matrixResult21[i][j];
                }
            }

            for (int i = 0; i < newSize; i++)
            {
                for (int j = 0; j < newSize; j++)
                {
                    matrixResult[newSize + i][newSize + j] = matrixResult22[i][j];
                }
            }
        }
        else
        {
            // Usa el algoritmo naivstandard
            matrixResult = NaivStandard(matrixA, matrixB, matrixResult, matrixA.Length, matrixB[0].Length, matrixResult.Length);
        }

        return matrixResult;
    }

    //Suma de matrices
    private static void Plus(long[][] matrixA, long[][] matrixB, long[][] result, int newSize)
    {
        for (int i = 0; i < newSize; i++)
        {
            for (int j = 0; j < newSize; j++)
            {
                result[i][j] = matrixA[i][j] + matrixB[i][j];
            }
        }
    }
    
    //Resta de matrices
    private static void Minus(long[][] matrixA, long[][] matrixB, long[][] result, int newSize)
    {
        for (int i = 0; i < newSize; i++)
        {
            for (int j = 0; j < newSize; j++)
            {
                result[i][j] = matrixA[i][j] - matrixB[i][j];
            }
        }
    }

    //algoritmo naivstandard
    private static long[][] NaivStandard(long[][] matrixA, long[][] matrixB, long[][] matrixResult, int rowsA, int colsB, int rowsResult)
    {
        for (int i = 0; i < rowsA; i++)
        {
            for (int j = 0; j < colsB; j++)
            {
                matrixResult[i][j] = 0;
                for (int k = 0; k < rowsResult; k++)
                {
                    //Realiza la multiplicación de elementos y suma los resultados
                    matrixResult[i][j] += matrixA[i][k] * matrixB[k][j];
                }
            }
        }
        return matrixResult;
    }

    public long[][] MultiplyMatrices(long[][] matrix1, long[][] matrix2)
    {
        return StrassenNaivMultiply(matrix1,matrix2);
    }
}
