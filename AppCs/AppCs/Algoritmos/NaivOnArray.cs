using services.interfaces;

class NaivOnArray : AlgorithmInterface {
    public int[][] MultiplyMatrices(int[][] matrix1, int[][] matrix2)
    {
        return naivOnArray(matrix1,matrix2);
    }

    /// <summary>
    /// La multiplicación se realiza fila por columna. 
    /// Los parámetros de entrada son las matrices A y B, y el tamaño de las matrices junto con el tamaño del resultado (N, P, M). 
    /// El resultado de la multiplicación se almacena en la matriz Result.
    /// </summary>
    /// <param name="A">Matriz A.</param>
    /// <param name="B">Matriz B.</param>
    /// <returns>Matriz donde se almacenará el resultado.</returns>
    public int[][] naivOnArray(int[][] A, int[][] B)
    {
        int N = A.Length;
        int P = B[0].Length;
        int M = B.Length;
        int[][] result = new int[N][];
        for (int o = 0; o < N; o++)
        {
            result[o] = new int[M];
        }
        
        for (int i = 0; i < N; i++)
        {
            result[i] = new int[M];
            for (int j = 0; j < M; j++)
            {
                result[i][j] = 0;
                for (int k = 0; k < P; k++)
                {
                    result[i][j] += A[i][k] * B[k][j];
                }
            }
        }

        return result;
    }

}
