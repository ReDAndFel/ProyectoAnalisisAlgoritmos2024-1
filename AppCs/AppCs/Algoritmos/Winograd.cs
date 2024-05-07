using System;
using services.interfaces;

public class Winograd : AlgorithmInterface
{
    /// <summary>
    /// Realiza la multiplicación de dos matrices utilizando el algoritmo original de Winograd.
    /// Calcula primero dos vectores auxiliares, y y z, para mejorar el rendimiento del algoritmo. 
    /// Luego, realiza la multiplicación de las matrices y ajusta el resultado dependiendo de si P es par o impar. 
    /// Los parámetros de entrada son las matrices A y B, y el tamaño de las matrices junto con el tamaño del resultado (N, P, M). 
    /// El resultado de la multiplicación se almacena en la matriz Result.
    /// </summary>
    /// <param name="A">Matriz A.</param>
    /// <param name="B">Matriz B.</param>
    /// <returns>Matriz resultado de la multiplicación.</returns>
    public static long[][] Original(long[][] A, long[][] B)
    {
        int N = A.Length;
        int P = B[0].Length;
        int M = A[0].Length;
        long[][] result = new long[N][];
        int i, j, k;
        int upsilon = P % 2;
        int gamma = P - upsilon;
        long[] y = new long[M];
        long[] z = new long[N];

        // Calculo de y
        for (i = 0; i < M; i++)
        {
            long aux = 0;
            for (j = 0; j < gamma; j += 2)
            {
                aux += A[i][j] * A[i][j + 1];
            }
            y[i] = aux;
        }

        // Calculo de z
        for (i = 0; i < N; i++)
        {
            long aux = 0;
            for (j = 0; j < gamma; j += 2)
            {
                aux += B[j][i] * B[j + 1][i];
            }
            z[i] = aux;
        }

        result = new long[N][];
        for (i = 0; i < N; i++)
        {
            result[i] = new long[M];
        }

        if (upsilon == 1)
        {
            // P es impar
            int PP = P - 1;
            for (i = 0; i < M; i++)
            {
                for (k = 0; k < N; k++)
                {
                    long aux = 0;
                    for (j = 0; j < gamma; j += 2)
                    {
                        aux += (A[i][j] + B[j + 1][k]) * (A[i][j + 1] + B[j][k]);
                    }
                    result[i][k] = aux - y[i] - z[k] + A[i][PP] * B[PP][k];
                }
            }
        }
        else
        {
            // P es par
            for (i = 0; i < M; i++)
            {
                for (k = 0; k < N; k++)
                {
                    long aux = 0;
                    for (j = 0; j < gamma; j += 2)
                    {
                        aux += (A[i][j] + B[j + 1][k]) * (A[i][j + 1] + B[j][k]);
                    }
                    result[i][k] = aux - y[i] - z[k];
                }
            }
        }

        return result;
    }

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
    public static long[][] Scaled(long[][] A, long[][] B)
    {
        int N = A.Length;
        int P = B[0].Length;
        int M = A[0].Length;
        long[][] result = new long[N][];
        int i;

        // Crear copias escaladas de A y B
        long[][] copyA = new long[N][];
        long[][] copyB = new long[P][];
        for (i = 0; i < N; i++)
        {
            copyA[i] = new long[P];
        }
        for (i = 0; i < P; i++)
        {
            copyB[i] = new long[M];
        }

        // Factor de escala
        double a = NormInf(A, N, P);
        double b = NormInf(B, P, M);
        double lambda = Math.Floor(0.5 + Math.Log(b / a) / Math.Log(4));

        // Escalar
        Util.MultiplyWithScalar(A, copyA, N, P, Math.Pow(2, lambda));
        Util.MultiplyWithScalar(B, copyB, P, M, Math.Pow(2, -lambda));

        // Utilizar Winograd con las matrices escaladas
        result = Original(copyA, copyB);

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
        return Original(matrix1,matrix2);
    }
}
