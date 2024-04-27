class NaivOnArray : AlgorithmInterface
{
    /// <summary>
    /// La multiplicación se realiza fila por columna. 
    /// Los parámetros de entrada son las matrices A y B, y el tamaño de las matrices junto con el tamaño del resultado (N, P, M). 
    /// El resultado de la multiplicación se almacena en la matriz Result.
    /// </summary>
    /// <param name="A">Matriz A.</param>
    /// <param name="B">Matriz B.</param>
    /// <param name="Result">Matriz donde se almacenará el resultado.</param>
    /// <param name="N">Número de filas de la matriz A y de la matriz resultado.</param>
    /// <param name="P">Número de columnas de la matriz A y número de filas de la matriz B.</param>
    /// <param name="M">Número de columnas de la matriz B y de la matriz resultado.</param>
    public double[][] naivOnArray(double[,] A, double[,] B)
    {
        int N = A[].Length;
        int P = B[0].Length;
        int M = A[0].Length;
        double[][] result = new int[rowsA][];

        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < M; j++)
            {
                Result[i, j] = 0.0;
                for (int k = 0; k < P; k++)
                {
                    Result[i, j] += A[i, k] * B[k, j];
                }
            }
        }

        return Result;
    }
}
