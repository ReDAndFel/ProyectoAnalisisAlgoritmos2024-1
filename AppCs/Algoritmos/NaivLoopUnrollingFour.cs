public class NaivLoopUnrollingFour{
    /// <summary>
    /// La multiplicación se realiza fila por columna. Dependiendo del residuo de la división de P por 4
    /// se ajusta el bucle interno en consecuencia para mejorar el rendimiento. 
    /// Los parámetros de entrada son las matrices A y B, y el tamaño de las matrices junto con el tamaño del resultado (N, P, M). 
    /// El resultado de la multiplicación se almacena en la matriz Result.
    /// </summary>
    /// <param name="A">Matriz A.</param>
    /// <param name="B">Matriz B.</param>
    /// <param name="Result">Matriz donde se almacenará el resultado.</param>
    /// <param name="N">Número de filas de la matriz A y de la matriz resultado.</param>
    /// <param name="P">Número de columnas de la matriz A y número de filas de la matriz B.</param>
    /// <param name="M">Número de columnas de la matriz B y de la matriz resultado.</param>
    public static void Multiplication(double[,] A, double[,] B)
    {
        int N = A[].Length;
        int P = B[0].Length;
        int M = A[0].Length;
        double[][] result = new int[rowsA][];
        int i, j, k;
        double aux;

        if (P % 4 == 0)
        {
            // Si P es divisible por 4
            for (i = 0; i < N; i++)
            {
                for (j = 0; j < M; j++)
                {
                    aux = 0.0;
                    for (k = 0; k < P; k += 4)
                    {
                        aux += A[i, k] * B[k, j] + A[i, k + 1] * B[k + 1, j] + A[i, k + 2] * B[k + 2, j] + A[i, k + 3] * B[k + 3, j];
                    }
                    Result[i, j] = aux;
                }
            }
        }
        else if (P % 4 == 1)
        {
            // Si P mod 4 es 1
            int PP = P - 1;
            for (i = 0; i < N; i++)
            {
                for (j = 0; j < M; j++)
                {
                    aux = 0.0;
                    for (k = 0; k < PP; k += 4)
                    {
                        aux += A[i, k] * B[k, j] + A[i, k + 1] * B[k + 1, j] + A[i, k + 2] * B[k + 2, j] + A[i, k + 3] * B[k + 3, j];
                    }
                    Result[i, j] = aux + A[i, PP] * B[PP, j];
                }
            }
        }
        else if (P % 4 == 2)
        {
            // Si P mod 4 es 2
            int PP = P - 2;
            int PPP = P - 1;
            for (i = 0; i < N; i++)
            {
                for (j = 0; j < M; j++)
                {
                    aux = 0.0;
                    for (k = 0; k < PP; k += 4)
                    {
                        aux += A[i, k] * B[k, j] + A[i, k + 1] * B[k + 1, j] + A[i, k + 2] * B[k + 2, j] + A[i, k + 3] * B[k + 3, j];
                    }
                    Result[i, j] = aux + A[i, PP] * B[PP, j] + A[i, PPP] * B[PPP, j];
                }
            }
        }
        else
        {
            // Si P mod 4 es 3
            int PP = P - 3;
            int PPP = P - 2;
            int PPPP = P - 1;
            for (i = 0; i < N; i++)
            {
                for (j = 0; j < M; j++)
                {
                    aux = 0.0;
                    for (k = 0; k < PP; k += 4)
                    {
                        aux += A[i, k] * B[k, j] + A[i, k + 1] * B[k + 1, j] + A[i, k + 2] * B[k + 2, j] + A[i, k + 3] * B[k + 3, j];
                    }
                    Result[i, j] = aux + A[i, PP] * B[PP, j] + A[i, PPP] * B[PPP, j] + A[i, PPPP] * B[PPPP, j];
                }
            }
        }
    }

}