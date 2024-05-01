using services.interfaces;
public class IV3SequentialBlocks : AlgorithmInterface{
    /// <summary>
    /// Se obtienen las dimensiones de las matrices de entrada y se calcula el tamaño del bloque.
    /// Se recorren las matrices utilizando bucles anidados para iterar sobre los bloques de las matrices. 
    /// Dentro de estos bucles, se realiza la multiplicación de matrices tradicional para los elementos dentro de cada bloque.
    /// </summary>
    /// <param name="matrixA">La primera matriz a multiplicar.</param>
    /// <param name="matrixB">La segunda matriz a multiplicar.</param>
    /// <returns>La matriz resultante de la multiplicación.</returns>
    static public int[][] Multiplication(int[][] matrix_A, int[][] matrix_B)
    {
        // Obtener las dimensiones de las matrices
        int rows_A = matrix_A.Length;
        int cols_B = matrix_B[0].Length;
        int cols_A = matrix_A[0].Length;

        // Inicializar la matriz resultante
        int[][] result = new int[rows_A][];
        for (int i = 0; i < rows_A; i++)
        {
            result[i] = new int[cols_B];
        }

        // Tamaño de los bloques
        int block_size = Math.Min(Math.Min(rows_A, cols_B), cols_A) / 2;

        // Multiplicar las matrices por bloques
        for (int row_block = 0; row_block < rows_A; row_block += block_size)
        {
            for (int col_block = 0; col_block < cols_B; col_block += block_size)
            {
                for (int col_A_block = 0; col_A_block < cols_A; col_A_block += block_size)
                {
                    for (int row = row_block; row < Math.Min(row_block + block_size, rows_A); row++)
                    {
                        for (int col = col_block; col < Math.Min(col_block + block_size, cols_B); col++)
                        {
                            for (int col_A = col_A_block; col_A < Math.Min(col_A_block + block_size, cols_A); col_A++)
                            {
                                result[row][col] += matrix_A[row][col_A] * matrix_B[col_A][col];
                            }
                        }
                    }
                }
            }
        }

        return result;
    }


    public int[][] MultiplyMatrices(int[][] matrix1, int[][] matrix2)
    {
        return Multiplication(matrix1,matrix2);
    }
}