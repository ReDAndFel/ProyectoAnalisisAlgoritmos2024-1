using services.interfaces;
public class SequentialBlock2 : AlgorithmInterface{
    /// <summary>
    ///  Se recorren las matrices utilizando bucles anidados para iterar sobre los bloques de las matrices. 
    /// Dentro de estos bucles, se realiza la multiplicación de matrices tradicional para los elementos dentro de cada bloque. 
    /// Se invierte el orden de acceso y actualización de los elementos en la matriz resultante.
    /// </summary>
    /// <param name="matrixA">La primera matriz a multiplicar.</param>
    /// <param name="matrixB">La segunda matriz a multiplicar.</param>
    /// <returns>La matriz resultante de la multiplicación.</returns>
    static long[][] Multiplication(long[][] matrix_A, long[][] matrix_B)
    {
        // Obtener las dimensiones de las matrices
        int rows_A = matrix_A.Length;
        int cols_B = matrix_B[0].Length;
        int cols_A = matrix_A[0].Length;

        // Inicializar la matriz resultante
        long[][] result = new long[rows_A][];
        for (int i = 0; i < rows_A; i++)
        {
            result[i] = new long[cols_B];
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
                                result[col_A][row] += matrix_A[col_A][col] * matrix_B[col][row];
                            }
                        }
                    }
                }
            }
        }

        return result;
    }


    public long[][] MultiplyMatrices(long[][] matrix1, long[][] matrix2)
    {
        return Multiplication(matrix1,matrix2);
    }
}