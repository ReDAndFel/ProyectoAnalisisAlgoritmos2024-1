//Algoritmo basado en el libro METHODS OF MATRIX MULTIPLICATION AN OVERVIEW OF SEVERAL METHODS AND THEIR IMPLEMENTATION y apoyado en IA
using System;

public static class NaivStandard
{
    /// <summary>
    /// Realiza la multiplicación de matrices utilizando el algoritmo estándar (naive).
    /// </summary>
    /// <param name="matrizA">La primera matriz a multiplicar.</param>
    /// <param name="matrizB">La segunda matriz a multiplicar.</param>
    /// <returns>La matriz resultado de la multiplicación.</returns>
    public static long[][] NaivStandardMultiply(long[][] matrizA, long[][] matrizB)
    {
        int cantidadFilasMatrizA = matrizA.Length;
        int cantidadColumnasMatrizA = matrizA[0].Length;
        int cantidadFilasMatrizB = matrizB.Length;
        int cantidadColumnasMatrizB = matrizB[0].Length;

        if (cantidadColumnasMatrizA != cantidadFilasMatrizB)
        {
            throw new ArgumentException("Las dimensiones de las matrices no son compatibles para la multiplicación.");
        }

        long[][] matrizResultado = new long[cantidadFilasMatrizA][];
        for (int i = 0; i < cantidadFilasMatrizA; i++)
        {
            matrizResultado[i] = new long[cantidadColumnasMatrizB];
            for (int j = 0; j < cantidadColumnasMatrizB; j++)
            {
                double aux = 0.0;
                for (int k = 0; k < cantidadColumnasMatrizA; k++)
                {
                    aux += matrizA[i][k] * matrizB[k][j];
                }
                matrizResultado[i][j] = (int)aux;
            }
        }
        return matrizResultado;
    }
}
