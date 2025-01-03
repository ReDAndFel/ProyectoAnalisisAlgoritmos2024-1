//Algoritmo basado en el libro METHODS OF MATRIX MULTIPLICATION AN OVERVIEW OF SEVERAL METHODS AND THEIR IMPLEMENTATION y apoyado en IA
using System;
using services.interfaces;
public class ParallelBlock3 : AlgorithmInterface{
    /// <summary>
    /// Se define un método interno MultiplyBlock para multiplicar un bloque específico de las matrices 
    /// de entrada y actualizar la matriz resultante. 
    /// Se invierte el orden de acceso a los elementos en la matriz resultante.
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
                        result[inner][row] += matrixA[inner][col] * matrixB[col][row];
                    }
                }
            }
        }

        // Iniciar tareas de multiplicación en paralelo
        List<Task> tasks = new List<Task>();
        for (int rowStart = 0; rowStart < size; rowStart += blockSize)
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