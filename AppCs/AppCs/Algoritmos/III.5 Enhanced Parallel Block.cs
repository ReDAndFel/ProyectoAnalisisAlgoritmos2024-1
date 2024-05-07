using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using services.interfaces;
public class EnhancedParallelBlocks : AlgorithmInterface{
    /// <summary>
    ///  Funciona igual que ParallelBlocks pero modificado.
    ///  Se dividen las filas de la matriz en dos secciones y se inician tareas para multiplicar los bloques de cada sección por separado.
    ///  Este enfoque busca mejorar la paralelización al dividir las tareas en dos secciones
    ///  lo que puede ayudar a utilizar mejor los recursos de procesamiento disponibles.
    /// </summary>
    /// <param name="matrixA">La primera matriz a multiplicar.</param>
    /// <param name="matrixB">La segunda matriz a multiplicar.</param>
    /// <returns>La matriz resultante de la multiplicación.</returns>
    public static long[][] Multiplication(long[][] matrixA, long[][] matrixB)
    {
        int size = matrixA.Length;
        int blockSize = size / 2;  // Tamaño del bloque

        // Inicializar matriz resultante
        long[][] result = new long[size][];
        for (int i = 0; i < size; i++)
        {
            result[i] = new long[size];
        }

        // Método para multiplicar un bloque específico
        void MultiplyBlock(int rowStart, int colStart, int innerStart)
        {
            for (int row = rowStart; row < Math.Min(rowStart + blockSize, size); row++)
            {
                for (int col = colStart; col < Math.Min(colStart + blockSize, size); col++)
                {
                    for (int inner = innerStart; inner < Math.Min(innerStart + blockSize, size); inner++)
                    {
                        result[row][col] += matrixA[row][inner] * matrixB[inner][col];
                    }
                }
            }
        }

        // Iniciar tareas de multiplicación en paralelo
        List<Task> tasks = new List<Task>();
        for (int rowStart = 0; rowStart < size / 2; rowStart += blockSize)
        {
            for (int colStart = 0; colStart < size; colStart += blockSize)
            {
                for (int innerStart = 0; innerStart < size; innerStart += blockSize)
                {
                    int rowStartCopy = rowStart;
                    int colStartCopy = colStart;
                    int innerStartCopy = innerStart;
                    tasks.Add(Task.Run(() => MultiplyBlock(rowStartCopy, colStartCopy, innerStartCopy)));
                }
            }
        }

        for (int rowStart = size / 2; rowStart < size; rowStart += blockSize)
        {
            for (int colStart = 0; colStart < size; colStart += blockSize)
            {
                for (int innerStart = 0; innerStart < size; innerStart += blockSize)
                {
                    int rowStartCopy = rowStart;
                    int colStartCopy = colStart;
                    int innerStartCopy = innerStart;
                    tasks.Add(Task.Run(() => MultiplyBlock(rowStartCopy, colStartCopy, innerStartCopy)));
                }
            }
        }

        // Esperar a que todas las tareas se completen
        Task.WaitAll(tasks.ToArray());

        return result;
    }

    public long[][] MultiplyMatrices(long[][] matrix1, long[][] matrix2)
    {
        return Multiplication(matrix1,matrix2);
    }
}