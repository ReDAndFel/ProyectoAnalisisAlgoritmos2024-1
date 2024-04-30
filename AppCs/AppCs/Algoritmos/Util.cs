public class Util
{
    /// <summary>
    /// Multiplica una matriz por un escalar.
    /// </summary>
    /// <param name="matrix">Matriz de entrada.</param>
    /// <param name="result">Matriz donde se almacenará el resultado.</param>
    /// <param name="rows">Número de filas de la matriz.</param>
    /// <param name="cols">Número de columnas de la matriz.</param>
    /// <param name="scalar">Escalar multiplicador.</param>
    public static void MultiplyWithScalar(int[][] matrix, int[][] result, int rows, int cols, double scalar)
    {
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                result[i][j] = (int)(matrix[i][j] * scalar);
            }
        }
    }


    /// <summary>
    /// Realiza la suma de dos matrices.
    /// </summary>
    /// <param name="A">Matriz A.</param>
    /// <param name="B">Matriz B.</param>
    /// <param name="Result">Matriz donde se almacenará la suma.</param>
    /// <param name="Size">Tamaño de las matrices.</param>
    public static void Plus(int[][] A, int[][] B, int[][] Result, int Size)
    {
        for (int i = 0; i < Size; i++)
        {
            for (int j = 0; j < Size; j++)
            {
                Result[i][j] = A[i][j] + B[i][j];
            }
        }
    }

    /// <summary>
    /// Realiza la resta de dos matrices.
    /// </summary>
    /// <param name="A">Matriz A.</param>
    /// <param name="B">Matriz B.</param>
    /// <param name="Result">Matriz donde se almacenará la resta.</param>
    /// <param name="Size">Tamaño de las matrices.</param>
    public static void Minus(int[][] A, int[][] B, int[][] Result, int Size)
    {
        for (int i = 0; i < Size; i++)
        {
            for (int j = 0; j < Size; j++)
            {
                Result[i][j] = A[i][j] - B[i][j];
            }
        }
    }

    /// <summary>
    /// Calcula la norma infinito de una matriz.
    /// </summary>
    /// <param name="matrix">Matriz de entrada.</param>
    /// <param name="rows">Número de filas de la matriz.</param>
    /// <param name="cols">Número de columnas de la matriz.</param>
    /// <returns>La norma infinito de la matriz.</returns>
    public static int NormInf(int[][] matrix, int rows, int cols)
    {
        int maxNorm = int.MinValue;

        for (int i = 0; i < rows; i++)
        {
            int rowSum = 0;
            for (int j = 0; j < cols; j++)
            {
                rowSum += Math.Abs(matrix[i][j]);
            }
            maxNorm = Math.Max(maxNorm, rowSum);
        }

        return maxNorm;
    }
}
