public class SequentialBlocks{
    /// <summary>
    /// Se obtienen las dimensiones de las matrices de entrada y se calcula el tamaño del bloque.
    /// Se recorren las matrices utilizando bucles anidados para iterar sobre los bloques de las matrices. 
    /// Dentro de estos bucles, se realiza la multiplicación de matrices tradicional para los elementos dentro de cada bloque.
    /// </summary>
    /// <param name="matrixA">La primera matriz a multiplicar.</param>
    /// <param name="matrixB">La segunda matriz a multiplicar.</param>
    /// <returns>La matriz resultante de la multiplicación.</returns>
    public static int[][] Multiplication(int[][] matrixA, int[][] matrixB)
    {
        // Obtiene las dimensiones de las matrices
        int rowsA = matrixA.Length;
        int colsB = matrixB[0].Length;
        int colsA = matrixA[0].Length;

        // Inicializa la matriz resultante
        int[][] result = new int[rowsA][];
        for (int i = 0; i < rowsA; i++)
        {
            result[i] = new int[colsB];
        }

        // Tamaño de los bloques
        int blockSize = Math.Min(Math.Min(rowsA, colsB), colsA) / 2;

        // Multiplicar las matrices por bloques
        for (int rowBlock = 0; rowBlock < rowsA; rowBlock += blockSize)
        {
            for (int colBlock = 0; colBlock < colsB; colBlock += blockSize)
            {
                for (int colABlock = 0; colABlock < colsA; colABlock += blockSize)
                {
                    for (int row = rowBlock; row < Math.Min(rowBlock + blockSize, rowsA); row++)
                    {
                        for (int col = colBlock; col < Math.Min(colBlock + blockSize, colsB); col++)
                        {
                            for (int colA = colABlock; colA < Math.Min(colABlock + blockSize, colsA); colA++)
                            {
                                result[row][col] += matrixA[row][col] * matrixB[col][colA];
                            }
                        }
                    }
                }
            }
        }

        return result;
    }
}