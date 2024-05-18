//Algoritmo basado en el libro METHODS OF MATRIX MULTIPLICATION AN OVERVIEW OF SEVERAL METHODS AND THEIR IMPLEMENTATION y apoyado en IA
using System;
using System.Linq;
using services.interfaces;

public class StrassenWinograd : AlgorithmInterface
{
    public static long[][] StrassenWinogradMultiply(long[][] matrixA, long[][] matrixB)
    {
        //Obtiene las dimensiones de las matrices
        int rows = matrixA.Length;
        int cols = matrixB[0].Length;
        int maxIt = matrixA[0].Length;
        //Inicializacion de la matriz resultado
        long[][] matrixResult = new long[rows][];

        for (int i = 0; i < rows; i++)
        {
            matrixResult[i] = new long[cols];
        }

        //Encuentra la mayor dimensión entre las matrices
        int maxSize = Math.Max(rows, maxIt);
        maxSize = Math.Max(maxSize, rows);

        //Asegura que la dimensión sea al menos 16 para la implementación de Strassen-Winograd
        if (maxSize < 16)
        {
            maxSize = 16;
        }

        //Calcula los parámetros necesarios para el algoritmo de Strassen-Winograd
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

        //copia matrixA y matrixB
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                newMatrixA[i][j] = matrixA[i][j];
                newMatrixB[i][j] = matrixB[i][j];
            }
        }

        //Realiza la multiplicación de matrices utilizando el algoritmo de Strassen-winograd
        matrixResultAux = StrassenWinogradStep(newMatrixA, newMatrixB, matrixResultAux, newSize, m);

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

    //Paso recursivo del algoritmo de multiplicación de matrices Strassen-winograd
    private static long[][] StrassenWinogradStep(long[][] matrixA, long[][] matrixB, long[][] matrixResult, int size, int m)
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
            long[][] matrixA1 = new long[newSize][];
            long[][] matrixA2 = new long[newSize][];
            long[][] matrixB1 = new long[newSize][];
            long[][] matrixB2 = new long[newSize][];
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
            long[][] aux8 = new long[newSize][];
            long[][] aux9 = new long[newSize][];

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
                matrixA1[i] = new long[newSize];
                matrixA2[i] = new long[newSize];
                matrixB1[i] = new long[newSize];
                matrixB2[i] = new long[newSize];
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
                aux8[i] = new long[newSize];
                aux9[i] = new long[newSize];
            }

            //Llena las submatrices con los valores correspondientes de las matrices originales
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

            // Calcula las variables auxiliares necesarias para el algoritmo
            Minus(matrixA11, matrixA21, matrixA1, newSize);
            Minus(matrixA22, matrixA1, matrixA2, newSize);
            Minus(matrixB22, matrixB12, matrixB1, newSize);
            Plus(matrixB1, matrixB11, matrixB2, newSize);
            StrassenWinogradStep(matrixA11, matrixB11, aux1, newSize, m);
            StrassenWinogradStep(matrixA12, matrixB21, aux2, newSize, m);
            StrassenWinogradStep(matrixA2, matrixB2, aux3, newSize, m);
            Plus(matrixA21, matrixA22, helper1, newSize);
            Minus(matrixB12, matrixB11, helper2, newSize);
            StrassenWinogradStep(helper1, helper2, aux4, newSize, m);
            StrassenWinogradStep(matrixA1, matrixB1, aux5, newSize, m);
            Minus(matrixA12, matrixA2, helper1, newSize);
            StrassenWinogradStep(helper1, matrixB22, aux6, newSize, m);
            Minus(matrixB21, matrixB2, helper1, newSize);
            StrassenWinogradStep(matrixA22, helper1, aux7, newSize, m);
            Plus(aux1, aux3, aux8, newSize);
            Plus(aux8, aux4, aux9, newSize);

            // Calcula las cuatro partes del resultado
            Plus(aux1, aux2, matrixResult11, newSize);
            Plus(aux9, aux6, matrixResult12, newSize);
            Plus(aux8, aux5, helper1, newSize);
            Plus(helper1, aux7, matrixResult21, newSize);
            Plus(aux9, aux5, matrixResult22, newSize);

            // Llena la matriz resultado con los resultados de las matrices resultado auxiliares
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
            // usa el algoritmo naivstanndard
            matrixResult = NaiveStandard(matrixA, matrixB, matrixResult, matrixA.Length, matrixB[0].Length, matrixResult.Length);
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
    private static long[][] NaiveStandard(long[][] matrixA, long[][] matrixB, long[][] matrixResult, int rowsA, int colsB, int rowsResult)
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
        return StrassenWinogradMultiply(matrix1,matrix2);
    }
}
