using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using services.interfaces;
public class ParallelBlocks : AlgorithmInterface{
    /// <summary>
    ///  Se define un método interno MultiplyBlock que multiplica un bloque específico
    ///  de las matrices de entrada y actualiza la matriz resultante con el resultado de la multiplicación.
    ///  Se inician tareas para multiplicar bloques específicos de las matrices de entrada en paralelo utilizando múltiples hilos.
    /// 
    ///  Este enfoque aprovecha la capacidad de paralelización para mejorar el rendimiento de la multiplicación
    ///  de matrices al distribuir la carga de trabajo en múltiples hilos.
    /// </summary>
    /// <param name="matrixA">La primera matriz a multiplicar.</param>
    /// <param name="matrixB">La segunda matriz a multiplicar.</param>
    /// <returns>La matriz resultante de la multiplicación.</returns>
    public static int[][] Multiplication(int[][] matrixA, int[][] matrixB)
    {
        int size = matrixA.Length;
        int blockSize = size / 2;  // Tamaño del bloque

        // Inicializar matriz resultante
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
                        result[row][col] += matrixA[row][inner] * matrixB[inner][col];
                    }
                }
            }
        }

        // Iniciar tareas de multiplicacion en paralelo
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

    public int[][] MultiplyMatrices(int[][] matrix1, int[][] matrix2)
    {
        return Multiplication(matrix1,matrix2);
    }
}