using System;
using System.Collections.Generic;
using System.Threading.Tasks;
public class ParallelBlocks2{
    /// <summary>
    /// Se obtienen las dimensiones de las matrices de entrada y se calcula el tamaño del bloque.
    /// Se define un método interno MultiplyBlock para multiplicar un bloque específico de las matrices de entrada y actualizar la matriz resultante.
    /// 
    /// Se inician tareas para multiplicar bloques específicos de las matrices de entrada en paralelo utilizando múltiples hilos. 
    /// Se invierte el orden de acceso a los elementos de la matriz B durante la multiplicación.
    /// </summary>
    /// <param name="matrixA">La primera matriz a multiplicar.</param>
    /// <param name="matrixB">La segunda matriz a multiplicar.</param>
    /// <returns>La matriz resultante de la multiplicación.</returns>
    public static int[][] Multiplication(int[][] matrixA, int[][] matrixB)
    {
        int size = matrixA.Length;
        int blockSize = size / 2;  // Tamaño del bloque

        // Inicializar matriz A con ceros
        int[][] result = new int[size][];
        for (int i = 0; i < size; i++)
        {
            result[i] = new int[size];
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
        for (int rowStart = 0; rowStart < size; rowStart += blockSize)
        {
            for (int colStart = 0; colStart < size; colStart += blockSize)
            {
                for (int innerStart = 0; innerStart < size; innerStart += blockSize)
                {
                    tasks.Add(Task.Run(() => MultiplyBlock(rowStart, colStart, innerStart)));
                }
            }
        }

        // Esperar a que todas las tareas se completen
        Task.WaitAll(tasks.ToArray());

        return result;
    }
}