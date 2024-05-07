using System;
using System.Linq;
using services.interfaces;
public class StrassenNaive : AlgorithmInterface
{
    /// <summary>
    /// Realiza la multiplicación de dos matrices utilizando el algoritmo de Strassen
    /// de forma ingenua (naive).
    /// </summary>
    /// <param name="matrizA">La primera matriz a multiplicar.</param>
    /// <param name="matrizB">La segunda matriz a multiplicar.</param>
    /// <returns>La matriz resultante de la multiplicación.</returns>
    public static long[][] StrassenNaiveMultiply(long[][] matrizA, long[][] matrizB)
    {
        int cantidadFilasMatrices = matrizA.Length;
        int cantidadColumnasMatrices = matrizB[0].Length;
        int delimitadorMaximaIteracionesFilaColumna = matrizA[0].Length;
        long[][] matrizResultado = new long[cantidadFilasMatrices][];
        for (int i = 0; i < cantidadFilasMatrices; i++)
        {
            matrizResultado[i] = new long[cantidadColumnasMatrices];
        }

        int tamanioMaximo = Math.Max(cantidadFilasMatrices, delimitadorMaximaIteracionesFilaColumna);
        tamanioMaximo = Math.Max(tamanioMaximo, cantidadFilasMatrices);

        if (tamanioMaximo < 16)
        {
            tamanioMaximo = 16; // Si no, no es posible computar K
        }

        int k = (int)Math.Floor(Math.Log(tamanioMaximo) / Math.Log(2)) - 4;
        int m = (int)Math.Floor(tamanioMaximo * Math.Pow(2, -k)) + 1;
        int nuevoTamanio = (int)(m * Math.Pow(2, k));

        long[][] nuevaMatrizA = new long[nuevoTamanio][];
        long[][] nuevaMatrizB = new long[nuevoTamanio][];
        long[][] matrizResultadoAuxiliar = new long[nuevoTamanio][];
        for (int i = 0; i < nuevoTamanio; i++)
        {
            nuevaMatrizA[i] = new long[nuevoTamanio];
            nuevaMatrizB[i] = new long[nuevoTamanio];
            matrizResultadoAuxiliar[i] = new long[nuevoTamanio];
        }

        for (int i = 0; i < cantidadFilasMatrices; i++)
        {
            for (int j = 0; j < delimitadorMaximaIteracionesFilaColumna; j++)
            {
                nuevaMatrizA[i][j] = matrizA[i][j];
            }
        }

        for (int i = 0; i < delimitadorMaximaIteracionesFilaColumna; i++)
        {
            for (int j = 0; j < cantidadColumnasMatrices; j++)
            {
                nuevaMatrizB[i][j] = matrizB[i][j];
            }
        }

        matrizResultadoAuxiliar = StrassenNaiveStep(nuevaMatrizA, nuevaMatrizB, matrizResultadoAuxiliar, nuevoTamanio, m);

        for (int i = 0; i < cantidadFilasMatrices; i++)
        {
            for (int j = 0; j < cantidadColumnasMatrices; j++)
            {
                matrizResultado[i][j] = matrizResultadoAuxiliar[i][j];
            }
        }

        return matrizResultado;
    }

    /// <summary>
    /// Realiza una etapa del algoritmo de Strassen para multiplicación de matrices
    /// de forma ingenua (naive).
    /// </summary>
    /// <param name="matrizA">La primera submatriz de la matriz A.</param>
    /// <param name="matrizB">La primera submatriz de la matriz B.</param>
    /// <param name="matrizResultado">La matriz resultante.</param>
    /// <param name="cantidadFilasMatrices">El tamaño de las submatrices.</param>
    /// <param name="m">El parámetro m del algoritmo.</param>
    /// <returns>La matriz resultante de la multiplicación.</returns>
    public static long[][] StrassenNaiveStep(long[][] matrizA, long[][] matrizB, long[][] matrizResultado, int cantidadFilasMatrices, int m)
    {
        int nuevoTamanio = 0;
        if (cantidadFilasMatrices % 2 == 0 && cantidadFilasMatrices > m)
        {
            nuevoTamanio = cantidadFilasMatrices / 2;

            long[][] matrizA11 = new long[nuevoTamanio][];
            long[][] matrizA12 = new long[nuevoTamanio][];
            long[][] matrizA21 = new long[nuevoTamanio][];
            long[][] matrizA22 = new long[nuevoTamanio][];

            long[][] matrizB11 = new long[nuevoTamanio][];
            long[][] matrizB12 = new long[nuevoTamanio][];
            long[][] matrizB21 = new long[nuevoTamanio][];
            long[][] matrizB22 = new long[nuevoTamanio][];

            long[][] matrizResultadoParte11 = new long[nuevoTamanio][];
            long[][] matrizResultadoParte12 = new long[nuevoTamanio][];
            long[][] matrizResultadoParte21 = new long[nuevoTamanio][];
            long[][] matrizResultadoParte22 = new long[nuevoTamanio][];

            long[][] ayudante1 = new long[nuevoTamanio][];
            long[][] ayudante2 = new long[nuevoTamanio][];

            long[][] auxiliar1 = new long[nuevoTamanio][];
            long[][] auxiliar2 = new long[nuevoTamanio][];
            long[][] auxiliar3 = new long[nuevoTamanio][];
            long[][] auxiliar4 = new long[nuevoTamanio][];
            long[][] auxiliar5 = new long[nuevoTamanio][];
            long[][] auxiliar6 = new long[nuevoTamanio][];
            long[][] auxiliar7 = new long[nuevoTamanio][];

            for (int i = 0; i < nuevoTamanio; i++)
            {
                matrizA11[i] = new long[nuevoTamanio];
                matrizA12[i] = new long[nuevoTamanio];
                matrizA21[i] = new long[nuevoTamanio];
                matrizA22[i] = new long[nuevoTamanio];

                matrizB11[i] = new long[nuevoTamanio];
                matrizB12[i] = new long[nuevoTamanio];
                matrizB21[i] = new long[nuevoTamanio];
                matrizB22[i] = new long[nuevoTamanio];

                matrizResultadoParte11[i] = new long[nuevoTamanio];
                matrizResultadoParte12[i] = new long[nuevoTamanio];
                matrizResultadoParte21[i] = new long[nuevoTamanio];
                matrizResultadoParte22[i] = new long[nuevoTamanio];

                ayudante1[i] = new long[nuevoTamanio];
                ayudante2[i] = new long[nuevoTamanio];

                auxiliar1[i] = new long[nuevoTamanio];
                auxiliar2[i] = new long[nuevoTamanio];
                auxiliar3[i] = new long[nuevoTamanio];
                auxiliar4[i] = new long[nuevoTamanio];
                auxiliar5[i] = new long[nuevoTamanio];
                auxiliar6[i] = new long[nuevoTamanio];
                auxiliar7[i] = new long[nuevoTamanio];
            }

            for (int i = 0; i < nuevoTamanio; i++)
            {
                for (int j = 0; j < nuevoTamanio; j++)
                {
                    matrizA11[i][j] = matrizA[i][j];
                    matrizA12[i][j] = matrizA[i][nuevoTamanio + j];
                    matrizA21[i][j] = matrizA[nuevoTamanio + i][j];
                    matrizA22[i][j] = matrizA[nuevoTamanio + i][nuevoTamanio + j];

                    matrizB11[i][j] = matrizB[i][j];
                    matrizB12[i][j] = matrizB[i][nuevoTamanio + j];
                    matrizB21[i][j] = matrizB[nuevoTamanio + i][j];
                    matrizB22[i][j] = matrizB[nuevoTamanio + i][nuevoTamanio + j];
                }
            }

            for (int i = 0; i < nuevoTamanio; i++)
            {
                for (int j = 0; j < nuevoTamanio; j++)
                {
                    ayudante1[i][j] = matrizA11[i][j] + matrizA22[i][j];
                    ayudante2[i][j] = matrizB11[i][j] + matrizB22[i][j];
                }
            }

            auxiliar1 = StrassenNaiveStep(ayudante1, ayudante2, auxiliar1, nuevoTamanio, m);

            for (int i = 0; i < nuevoTamanio; i++)
            {
                for (int j = 0; j < nuevoTamanio; j++)
                {
                    ayudante1[i][j] = matrizA21[i][j] + matrizA22[i][j];
                }
            }

            auxiliar2 = StrassenNaiveStep(ayudante1, matrizB11, auxiliar2, nuevoTamanio, m);

            for (int i = 0; i < nuevoTamanio; i++)
            {
                for (int j = 0; j < nuevoTamanio; j++)
                {
                    ayudante1[i][j] = matrizA11[i][j];
                }
            }

            auxiliar3 = StrassenNaiveStep(matrizA11, ayudante1, auxiliar3, nuevoTamanio, m);

            for (int i = 0; i < nuevoTamanio; i++)
            {
                for (int j = 0; j < nuevoTamanio; j++)
                {
                    ayudante1[i][j] = matrizA22[i][j];
                }
            }

            auxiliar4 = StrassenNaiveStep(matrizA22, ayudante1, auxiliar4, nuevoTamanio, m);

            for (int i = 0; i < nuevoTamanio; i++)
            {
                for (int j = 0; j < nuevoTamanio; j++)
                {
                    ayudante1[i][j] = matrizA11[i][j] + matrizA12[i][j];
                }
            }

            auxiliar5 = StrassenNaiveStep(ayudante1, matrizB22, auxiliar5, nuevoTamanio, m);

            for (int i = 0; i < nuevoTamanio; i++)
            {
                for (int j = 0; j < nuevoTamanio; j++)
                {
                    ayudante1[i][j] = matrizA21[i][j] - matrizA11[i][j];
                    ayudante2[i][j] = matrizB11[i][j] + matrizB12[i][j];
                }
            }

            auxiliar6 = StrassenNaiveStep(ayudante1, ayudante2, auxiliar6, nuevoTamanio, m);

            for (int i = 0; i < nuevoTamanio; i++)
            {
                for (int j = 0; j < nuevoTamanio; j++)
                {
                    ayudante1[i][j] = matrizA12[i][j] - matrizA22[i][j];
                    ayudante2[i][j] = matrizB21[i][j] + matrizB22[i][j];
                }
            }

            auxiliar7 = StrassenNaiveStep(ayudante1, ayudante2, auxiliar7, nuevoTamanio, m);

            for (int i = 0; i < nuevoTamanio; i++)
            {
                for (int j = 0; j < nuevoTamanio; j++)
                {
                    matrizResultadoParte11[i][j] = auxiliar1[i][j] + auxiliar4[i][j] - auxiliar5[i][j] + auxiliar7[i][j];
                    matrizResultadoParte12[i][j] = auxiliar3[i][j] + auxiliar5[i][j];
                    matrizResultadoParte21[i][j] = auxiliar2[i][j] + auxiliar4[i][j];
                    matrizResultadoParte22[i][j] = auxiliar1[i][j] - auxiliar2[i][j] + auxiliar3[i][j] + auxiliar6[i][j];
                }
            }

            for (int i = 0; i < nuevoTamanio; i++)
            {
                for (int j = 0; j < nuevoTamanio; j++)
                {
                    matrizResultado[i][j] = matrizResultadoParte11[i][j];
                }
            }

            for (int i = 0; i < nuevoTamanio; i++)
            {
                for (int j = 0; j < nuevoTamanio; j++)
                {
                    matrizResultado[i][nuevoTamanio + j] = matrizResultadoParte12[i][j];
                }
            }

            for (int i = 0; i < nuevoTamanio; i++)
            {
                for (int j = 0; j < nuevoTamanio; j++)
                {
                    matrizResultado[nuevoTamanio + i][j] = matrizResultadoParte21[i][j];
                }
            }

            for (int i = 0; i < nuevoTamanio; i++)
            {
                for (int j = 0; j < nuevoTamanio; j++)
                {
                    matrizResultado[nuevoTamanio + i][nuevoTamanio + j] = matrizResultadoParte22[i][j];
                }
            }
        }
        else
        {
            // Usar algoritmo naiv
            matrizResultado = NaivStandard.NaivStandardMultiply(matrizA, matrizB);
        }

        return matrizResultado;
    }

    public long[][] MultiplyMatrices(long[][] matrix1, long[][] matrix2)
    {
        return StrassenNaiveMultiply(matrix1,matrix2);
    }
}
