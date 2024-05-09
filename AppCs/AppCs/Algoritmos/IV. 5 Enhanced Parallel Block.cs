//Algoritmo basado en el libro METHODS OF MATRIX MULTIPLICATION AN OVERVIEW OF SEVERAL METHODS AND THEIR IMPLEMENTATION y apoyado en IA
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using services.interfaces;
public class EnhancedParallelBlocks2 : AlgorithmInterface{
    /// <summary>
    /// Se obtienen las dimensiones de las matrices de entrada y se calcula el tamaño del bloque.
    /// Se define un método interno MultiplyBlock para multiplicar un bloque específico de las matrices de entrada y actualizar la matriz resultante.
    /// 
    /// Se inician tareas para multiplicar bloques específicos de las matrices de entrada en paralelo utilizando múltiples hilos. 
    /// Se dividen las filas de la matriz en dos secciones y se inician tareas para multiplicar los bloques de cada sección por separado.
    /// </summary>
    /// <param name="matrixA">La primera matriz a multiplicar.</param>
    /// <param name="matrixB">La segunda matriz a multiplicar.</param>
    /// <returns>La matriz resultante de la multiplicación.</returns>
    public static long[][] Multiplication(long[][] matrixA, long[][] matrixB)
    {
        int size = matrixA.Length;
        int blockSize = size / 2;  // Tamaño del bloque

        // Inicializar matriz A con ceros
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
                        result[row][inner] += matrixA[row][col] * matrixB[col][inner];
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