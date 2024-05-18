//Algoritmo basado en el libro METHODS OF MATRIX MULTIPLICATION AN OVERVIEW OF SEVERAL METHODS AND THEIR IMPLEMENTATION y apoyado en IA
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
        //Obtiene las dimensiones de las matrices
        int N = A.Length;
        int P = B[0].Length;
        int M = A[0].Length;
        
        int i, j, k;
        //Calcula la paridad de la cantidad de columnas de la matriz A.
        int upsilon = P % 2;
        //Calcula el número de columnas de la matriz A que se pueden procesar en pares en el algoritmo
        int gamma = P - upsilon;
        //Inicializa los arreglos y y z
        long[] y = new long[M];
        long[] z = new long[N];

        // LLena con 0s el arreglo y
        for (i = 0; i < M; i++)
        {
            long aux = 0;
            for (j = 0; j < gamma; j += 2)
            {
                aux += A[i][j] * A[i][j + 1];
            }
            y[i] = aux;
        }

        // LLena con 0s el arreglo z
        for (i = 0; i < N; i++)
        {
            long aux = 0;
            for (j = 0; j < gamma; j += 2)
            {
                aux += B[j][i] * B[j + 1][i];
            }
            z[i] = aux;
        }

        //Inicializa la matriz resultado
        long[][] result = new long[N][];
        for (i = 0; i < N; i++)
        {
            result[i] = new long[M];
        }

        //Realiza la multiplicación de matrices
        //Verifica si la cantidad de columnas de la matriz A es impar (upsilon == 1).
        if (upsilon == 1)
        {
            // Si es impar, se ajusta la multiplicación para el último elemento de la fila/columna.
            //PP almacena el índice de la última columna de la matriz A.
            int PP = P - 1;
            for (i = 0; i < M; i++)
            {
                for (k = 0; k < N; k++)
                {
                    long aux = 0;
                    //Recorre los bloques de las matrices A y B.
                    for (j = 0; j < gamma; j += 2)
                    {
                        //Realiza la suma de productos para cada bloque de matrices.
                        aux += (A[i][j] + B[j + 1][k]) * (A[i][j + 1] + B[j][k]);
                    }
                    //Almacena el resultado ajustado restando las sumas auxiliares y agregando el producto del último elemento.
                    result[i][k] = aux - y[i] - z[k] + A[i][PP] * B[PP][k];
                }
            }
        }
        else
        {
            // # Si la cantidad de columnas de la matriz A es par, realiza la multiplicación sin ajustes.
            for (i = 0; i < M; i++)
            {
                for (k = 0; k < N; k++)
                {
                    long aux = 0;
                    //Recorre los bloques de las matrices A y B.
                    for (j = 0; j < gamma; j += 2)
                    {
                        //Realiza la suma de productos para cada bloque de matrices.
                        aux += (A[i][j] + B[j + 1][k]) * (A[i][j + 1] + B[j][k]);
                    }
                    //Almacena el resultado ajustado restando las sumas auxiliares y agregando el producto del último elemento.
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
