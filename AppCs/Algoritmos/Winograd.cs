using Microsoft.VisualBasic.CompilerServices;
using Algoritmos.Util;
public class Winograd{
    /// <summary>
    /// Realiza la multiplicación de dos matrices utilizando el algoritmo original de Winograd.
    /// Calcula primero dos vectores auxiliares, y y z, para mejorar el rendimiento del algoritmo. 
    /// Luego, realiza la multiplicación de las matrices y ajusta el resultado dependiendo de si P es par o impar. 
    /// Los parámetros de entrada son las matrices A y B, y el tamaño de las matrices junto con el tamaño del resultado (N, P, M). 
    /// El resultado de la multiplicación se almacena en la matriz Result.
    /// </summary>
    /// <param name="A">Matriz A.</param>
    /// <param name="B">Matriz B.</param>
    /// <param name="Result">Matriz donde se almacenará el resultado.</param>
    /// <param name="N">Número de filas de la matriz A y número de columnas de la matriz B.</param>
    /// <param name="P">Número de columnas de la matriz A y número de filas de la matriz B.</param>
    /// <param name="M">Número de filas de la matriz B y de la matriz resultado.</param>
    public static void Original(double[,] A, double[,] B)
    {
        int N = A[].Length;
        int P = B[0].Length;
        int M = A[0].Length;
        double[][] result = new int[rowsA][];
        int i, j, k;
        double aux;
        int upsilon = P % 2;
        int gamma = P - upsilon;
        double[] y = new double[M];
        double[] z = new double[N];

        // Calculo de y
        for (i = 0; i < M; i++)
        {
            aux = 0.0;
            for (j = 0; j < gamma; j += 2)
            {
                aux += A[i, j] * A[i, j + 1];
            }
            y[i] = aux;
        }

        // Calculo de z
        for (i = 0; i < N; i++)
        {
            aux = 0.0;
            for (j = 0; j < gamma; j += 2)
            {
                aux += B[j, i] * B[j + 1, i];
            }
            z[i] = aux;
        }

        if (upsilon == 1)
        {
            // P es impar
            int PP = P - 1;
            for (i = 0; i < M; i++)
            {
                for (k = 0; k < N; k++)
                {
                    aux = 0.0;
                    for (j = 0; j < gamma; j += 2)
                    {
                        aux += (A[i, j] + B[j + 1, k]) * (A[i, j + 1] + B[j, k]);
                    }
                    Result[i, k] = aux - y[i] - z[k] + A[i, PP] * B[PP, k];
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
                    aux = 0.0;
                    for (j = 0; j < gamma; j += 2)
                    {
                        aux += (A[i, j] + B[j + 1, k]) * (A[i, j + 1] + B[j, k]);
                    }
                    Result[i, k] = aux - y[i] - z[k];
                }
            }
        }

        // Liberación de memoria
        y = null;
        z = null;
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
    /// <param name="Result">Matriz donde se almacenará el resultado.</param>
    /// <param name="N">Número de filas de la matriz A y número de columnas de la matriz B.</param>
    /// <param name="P">Número de columnas de la matriz A y número de filas de la matriz B.</param>
    /// <param name="M">Número de filas de la matriz B y de la matriz resultado.</param>
    public static void Scaled(double[,] A, double[,] B, double[,] Result, int N, int P, int M)
    {
        int i;
        // Crear copias escaladas de A y B
        double[,] CopyA = new double[N, P];
        double[,] CopyB = new double[P, M];

        // Factor de escala
        double a = NormInf(A, N, P);
        double b = NormInf(B, P, M);
        double lambda = Math.Floor(0.5 + Math.Log(b / a) / Math.Log(4));

        // Escalar
        Util.MultiplyWithScalar(A, CopyA, N, P, Math.Pow(2, lambda));
        Util.MultiplyWithScalar(B, CopyB, P, M, Math.Pow(2, -lambda));

        // Utilizar Winograd con las matrices escaladas
        Original(CopyA, CopyB, Result, N, P, M);
    }
}