public class NaivLoopUnrollingTwo{
    /// <summary>
    ///La multiplicación se realiza fila por columna. Se verifica si el número de columnas de la matriz A es par o impar y se ajusta el bucle interno en consecuencia.
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

        if (P % 2 == 0)
        {
            // Si P es par
            for (i = 0; i < N; i++)
            {
                for (j = 0; j < M; j++)
                {
                    aux = 0.0;
                    for (k = 0; k < P; k += 2)
                    {
                        aux += A[i, k] * B[k, j] + A[i, k + 1] * B[k + 1, j];
                    }
                    Result[i, j] = aux;
                }
            }
        }
        else
        {
            // Si P es impar
            int PP = P - 1;
            for (i = 0; i < N; i++)
            {
                for (j = 0; j < M; j++)
                {
                    aux = 0.0;
                    for (k = 0; k < PP; k += 2)
                    {
                        aux += A[i, k] * B[k, j] + A[i, k + 1] * B[k + 1, j];
                    }
                    Result[i, j] = aux + A[i, PP] * B[PP, j];
                }
            }
        }
    }

}