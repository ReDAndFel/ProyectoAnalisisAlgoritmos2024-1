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
    public static int[][] StrassenNaiveMultiply(int[][] matrizA, int[][] matrizB)
    {
        int cantidadFilasMatrices = matrizA.Length;
        int cantidadColumnasMatrices = matrizB[0].Length;
        int delimitadorMaximaIteracionesFilaColumna = matrizA[0].Length;
        int[][] matrizResultado = new int[cantidadFilasMatrices][];
        for (int i = 0; i < cantidadFilasMatrices; i++)
        {
            matrizResultado[i] = new int[cantidadColumnasMatrices];
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

        int[][] nuevaMatrizA = new int[nuevoTamanio][];
        int[][] nuevaMatrizB = new int[nuevoTamanio][];
        int[][] matrizResultadoAuxiliar = new int[nuevoTamanio][];
        for (int i = 0; i < nuevoTamanio; i++)
        {
            nuevaMatrizA[i] = new int[nuevoTamanio];
            nuevaMatrizB[i] = new int[nuevoTamanio];
            matrizResultadoAuxiliar[i] = new int[nuevoTamanio];
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
    public static int[][] StrassenNaiveStep(int[][] matrizA, int[][] matrizB, int[][] matrizResultado, int cantidadFilasMatrices, int m)
    {
        int nuevoTamanio = 0;
        if (cantidadFilasMatrices % 2 == 0 && cantidadFilasMatrices > m)
        {
            nuevoTamanio = cantidadFilasMatrices / 2;

            int[][] matrizA11 = new int[nuevoTamanio][];
            int[][] matrizA12 = new int[nuevoTamanio][];
            int[][] matrizA21 = new int[nuevoTamanio][];
            int[][] matrizA22 = new int[nuevoTamanio][];

            int[][] matrizB11 = new int[nuevoTamanio][];
            int[][] matrizB12 = new int[nuevoTamanio][];
            int[][] matrizB21 = new int[nuevoTamanio][];
            int[][] matrizB22 = new int[nuevoTamanio][];

            int[][] matrizResultadoParte11 = new int[nuevoTamanio][];
            int[][] matrizResultadoParte12 = new int[nuevoTamanio][];
            int[][] matrizResultadoParte21 = new int[nuevoTamanio][];
            int[][] matrizResultadoParte22 = new int[nuevoTamanio][];

            int[][] ayudante1 = new int[nuevoTamanio][];
            int[][] ayudante2 = new int[nuevoTamanio][];

            int[][] auxiliar1 = new int[nuevoTamanio][];
            int[][] auxiliar2 = new int[nuevoTamanio][];
            int[][] auxiliar3 = new int[nuevoTamanio][];
            int[][] auxiliar4 = new int[nuevoTamanio][];
            int[][] auxiliar5 = new int[nuevoTamanio][];
            int[][] auxiliar6 = new int[nuevoTamanio][];
            int[][] auxiliar7 = new int[nuevoTamanio][];

            for (int i = 0; i < nuevoTamanio; i++)
            {
                matrizA11[i] = new int[nuevoTamanio];
                matrizA12[i] = new int[nuevoTamanio];
                matrizA21[i] = new int[nuevoTamanio];
                matrizA22[i] = new int[nuevoTamanio];

                matrizB11[i] = new int[nuevoTamanio];
                matrizB12[i] = new int[nuevoTamanio];
                matrizB21[i] = new int[nuevoTamanio];
                matrizB22[i] = new int[nuevoTamanio];

                matrizResultadoParte11[i] = new int[nuevoTamanio];
                matrizResultadoParte12[i] = new int[nuevoTamanio];
                matrizResultadoParte21[i] = new int[nuevoTamanio];
                matrizResultadoParte22[i] = new int[nuevoTamanio];

                ayudante1[i] = new int[nuevoTamanio];
                ayudante2[i] = new int[nuevoTamanio];

                auxiliar1[i] = new int[nuevoTamanio];
                auxiliar2[i] = new int[nuevoTamanio];
                auxiliar3[i] = new int[nuevoTamanio];
                auxiliar4[i] = new int[nuevoTamanio];
                auxiliar5[i] = new int[nuevoTamanio];
                auxiliar6[i] = new int[nuevoTamanio];
                auxiliar7[i] = new int[nuevoTamanio];
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

    public int[][] MultiplyMatrices(int[][] matrix1, int[][] matrix2)
    {
        return StrassenNaiveMultiply(matrix1,matrix2);
    }
}
