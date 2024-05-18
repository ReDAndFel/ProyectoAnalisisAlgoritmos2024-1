//Algoritmo basado en el libro METHODS OF MATRIX MULTIPLICATION AN OVERVIEW OF SEVERAL METHODS AND THEIR IMPLEMENTATION y apoyado en IA
using System;
using services.interfaces;

public class WinogradScaled : AlgorithmInterface
{
    /// <summary>
    /// Realiza la multiplicación de dos matrices utilizando el algoritmo de Winograd escalado.
    /// Primero, crea copias escaladas de las matrices de entrada A y B. 
    /// Luego, calcula el factor de escala lambda basado en la norma infinito de las matrices originales. 
    /// Después, escala las matrices de entrada con el factor lambda y utiliza el algoritmo de Winograd original con las matrices escaladas para obtener el resultado final. 
    /// Los parámetros de entrada son las matrices A y B, y el tamaño de las matrices junto con el tamaño del resultado (N, P, M).
    /// </summary>
    /// <param name="A">Matriz A.</param>
    /// <param name="B">Matriz B.</param>
    /// <returns>Matriz resultado de la multiplicación.</returns>
    public static long[][] Multiplication(long[][] A, long[][] B)
    {
        //Obtiene las dimensiones de las matrices
        int N = A.Length;
        int P = B[0].Length;
        int M = A[0].Length;
        //Inicializa la matriz resultado
        long[][] result = new long[N][];
        for (int j = 0; j < N; j++)
        {
            result[j] = new long[M];
        }
        int i;

        // Crear copias escaladas de A y B
        long[][] CopyA = new long[N][];
        long[][] CopyB = new long[P][];
        for (i = 0; i < N; i++)
        {
            CopyA[i] = new long[P];
        }
        for (i = 0; i < P; i++)
        {
            CopyB[i] = new long[M];
        }

        // Factor de escala
        double a = NormInf(A, N, P);
        double b = NormInf(B, P, M);
        double lambda = Math.Floor(0.5 + Math.Log(b / a) / Math.Log(4));

        // Escalar
        Util.MultiplyWithScalar(A, CopyA, N, P, Math.Pow(2, lambda));
        Util.MultiplyWithScalar(B, CopyB, P, M, Math.Pow(2, -lambda));

        // Utilizar Winograd con las matrices escaladas
        result = Winograd.Original(CopyA, CopyB);

        return result;
    }

    /// <summary>
    /// Calcula la norma infinito de una matriz.
    /// </summary>
    /// <param name="matrix">La matriz.</param>
    /// <param name="rows">El número de filas de la matriz.</param>
    /// <param name="cols">El número de columnas de la matriz.</param>
    /// <returns>La norma infinito de la matriz.</returns>
    private static double NormInf(long[][] matrix, int rows, int cols)
    {
        double maxNorm = 0;
        for (int i = 0; i < rows; i++)
        {
            double rowSum = 0;
            for (int j = 0; j < cols; j++)
            {
                rowSum += Math.Abs(matrix[i][j]);
            }
            maxNorm = Math.Max(maxNorm, rowSum);
        }
        return maxNorm;
    }

    public long[][] MultiplyMatrices(long[][] matrix1, long[][] matrix2)
    {
        return Multiplication(matrix1,matrix2);
    }
}
