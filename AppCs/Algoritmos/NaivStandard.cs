using System;

public static class NaivStandard
{
    /// <summary>
    /// Realiza la multiplicación de matrices utilizando el algoritmo estándar (naive).
    /// </summary>
    /// <param name="matrizA">La primera matriz a multiplicar.</param>
    /// <param name="matrizB">La segunda matriz a multiplicar.</param>
    /// <param name="matrizResultado">La matriz en la que se almacenará el resultado.</param>
    /// <param name="cantidadFilasMatrices">El número de filas de las matrices.</param>
    /// <param name="cantidadColumnasMatrices">El número de columnas de las matrices.</param>
    /// <param name="cantidadMaximaIteracionesFilaColumna">La cantidad máxima de iteraciones para las filas y columnas.</param>
    /// <returns>La matriz resultado de la multiplicación.</returns>
    public static int[][] NaivStandardMultiply(int[][] matrizA, int[][] matrizB, int[][] matrizResultado, int cantidadFilasMatrices, int cantidadColumnasMatrices, int cantidadMaximaIteracionesFilaColumna)
    {
        double aux;
        for (int i = 0; i < cantidadFilasMatrices; i++)
        {
            for (int j = 0; j < cantidadColumnasMatrices; j++)
            {
                aux = 0.0;
                for (int k = 0; k < cantidadMaximaIteracionesFilaColumna; k++)
                {
                    aux += matrizA[i][k] * matrizB[k][j];
                }
                matrizResultado[i][j] = (int)aux;
            }
        }
        return matrizResultado;
    }
}

