//Algoritmo basado en el libro METHODS OF MATRIX MULTIPLICATION AN OVERVIEW OF SEVERAL METHODS AND THEIR IMPLEMENTATION y apoyado en IA
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using services.interfaces;
public class SequentialBlocks : AlgorithmInterface{
    /// <summary>
    /// Se recorren las matrices utilizando bucles anidados para iterar sobre los bloques de las matrices. 
    /// Dentro de estos bucles, se realiza la multiplicación de matrices tradicional para los elementos dentro de cada bloque.
    /// </summary>
    /// <param name="matrixA">La primera matriz a multiplicar.</param>
    /// <param name="matrixB">La segunda matriz a multiplicar.</param>
    /// <returns>La matriz resultante de la multiplicación.</returns>
    public static long[][] Multiplication(long[][] matrixA, long[][] matrixB)
    {
        // Obtener las dimensiones de las matrices
        int rowsA = matrixA.Length;
        int colsB = matrixB[0].Length;
        int colsA = matrixA[0].Length;

        // Inicializar la matriz resultante
        long[][] result = new long[rowsA][];
        for (int i = 0; i < rowsA; i++)
        {
            result[i] = new long[colsB];
        }

        // Tamaño de los bloques
        int blockSize = Math.Min(Math.Min(rowsA, colsB), colsA) / 2;

        // Multiplicar las matrices por bloques
        for (int rowBlock = 0; rowBlock < rowsA; rowBlock += blockSize)
        {
            for (int colBlock = 0; colBlock < colsB; colBlock += blockSize)
            {
                for (int colABlock = 0; colABlock < colsA; colABlock += blockSize)
                {
                    for (int row = rowBlock; row < Math.Min(rowBlock + blockSize, rowsA); row++)
                    {
                        for (int col = colBlock; col < Math.Min(colBlock + blockSize, colsB); col++)
                        {
                            for (int colA = colABlock; colA < Math.Min(colABlock + blockSize, colsA); colA++)
                            {
                                result[row][col] += matrixA[row][colA] * matrixB[colA][col];
                            }
                        }
                    }
                }
            }
        }
        return result;
    }

    public long[][] MultiplyMatrices(long[][] matrix1, long[][] matrix2)
    {
        return Multiplication(matrix1,matrix2);
    }
}