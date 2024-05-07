using System;
using System.Linq;
using services.interfaces;

public class StrassenWinograd : AlgorithmInterface
{

    public static long[][] StrassenWinogradMultiply(long[][] matrizA, long[][] matrizB)
    {
        int cantidadFilasMatrices = matrizA.Length;
        int cantidadColumnasMatrices = matrizB[0].Length;
        int delimitadorMaximaIteracionesFilaColumna = matrizA[0].Length;
        long[][] matrizResultado = new long[cantidadFilasMatrices][];
        for (int i = 0; i < cantidadFilasMatrices; i++)
        {
            matrizResultado[i] = new long[cantidadColumnasMatrices];
        }

        int mitad = cantidadFilasMatrices / 2;

        // Verificar si las matrices son lo suficientemente pequeñas como para usar el algoritmo naive
        if (cantidadFilasMatrices <= 16)
        {
            matrizResultado = NaivStandard.NaivStandardMultiply(matrizA, matrizB);
        }
        else
        {
            // Dividir las matrices en submatrices
            long[][] A11 = new long[mitad][];
            long[][] A12 = new long[mitad][];
            long[][] A21 = new long[mitad][];
            long[][] A22 = new long[mitad][];

            long[][] B11 = new long[mitad][];
            long[][] B12 = new long[mitad][];
            long[][] B21 = new long[mitad][];
            long[][] B22 = new long[mitad][];

            for (int i = 0; i < mitad; i++)
            {
                A11[i] = new long[mitad];
                A12[i] = new long[mitad];
                A21[i] = new long[mitad];
                A22[i] = new long[mitad];

                B11[i] = new long[mitad];
                B12[i] = new long[mitad];
                B21[i] = new long[mitad];
                B22[i] = new long[mitad];

                for (int j = 0; j < mitad; j++)
                {
                    A11[i][j] = matrizA[i][j];
                    A12[i][j] = matrizA[i][j + mitad];
                    A21[i][j] = matrizA[i + mitad][j];
                    A22[i][j] = matrizA[i + mitad][j + mitad];

                    B11[i][j] = matrizB[i][j];
                    B12[i][j] = matrizB[i][j + mitad];
                    B21[i][j] = matrizB[i + mitad][j];
                    B22[i][j] = matrizB[i + mitad][j + mitad];
                }
            }

            // Calcular las submatrices del resultado
            long[][] C11 = SumarMatrices(StrassenWinogradMultiply(SumarMatrices(A11, A22), SumarMatrices(B11, B22)),
                                        StrassenWinogradMultiply(SumarMatrices(A12, A22), B11));
            long[][] C12 = SumarMatrices(StrassenWinogradMultiply(SumarMatrices(A11, A22), B12),
                                        StrassenWinogradMultiply(A12, B22));
            long[][] C21 = SumarMatrices(StrassenWinogradMultiply(A21, SumarMatrices(B11, B21)),
                                        StrassenWinogradMultiply(A22, SumarMatrices(B12, B22)));
            long[][] C22 = SumarMatrices(StrassenWinogradMultiply(A11, SumarMatrices(B21, B22)),
                                        StrassenWinogradMultiply(A22, SumarMatrices(B12, B11)));

            // Combinar las submatrices en la matriz resultado
            for (int i = 0; i < mitad; i++)
            {
                for (int j = 0; j < mitad; j++)
                {
                    matrizResultado[i][j] = C11[i][j];
                    matrizResultado[i][j + mitad] = C12[i][j];
                    matrizResultado[i + mitad][j] = C21[i][j];
                    matrizResultado[i + mitad][j + mitad] = C22[i][j];
                }
            }
        }

        return matrizResultado;
    }


    // Método auxiliar para verificar si un número es potencia de dos
    private static bool EsPotenciaDeDos(int n)
    {
        return (n & (n - 1)) == 0;
    }

    // Método auxiliar para obtener una submatriz de una matriz
    private static int[][] Submatriz(int[][] matriz, int filaInicio, int columnaInicio, int tamanio)
    {
        int[][] submatriz = new int[tamanio][];
        for (int i = 0; i < tamanio; i++)
        {
            submatriz[i] = new int[tamanio];
            for (int j = 0; j < tamanio; j++)
            {
                submatriz[i][j] = matriz[filaInicio + i][columnaInicio + j];
            }
        }
        return submatriz;
    }

    // Método auxiliar para sumar dos matrices
    private static long[][] SumarMatrices(long[][] matrizA, long[][] matrizB)
    {
        int n = matrizA.Length;
        long[][] resultado = new long[n][];
        for (int i = 0; i < n; i++)
        {
            resultado[i] = new long[n];
            for (int j = 0; j < n; j++)
            {
                resultado[i][j] = matrizA[i][j] + matrizB[i][j];
            }
        }
        return resultado;
    }

    // Método auxiliar para restar dos matrices
    private static int[][] RestarMatrices(int[][] matrizA, int[][] matrizB)
    {
        int n = matrizA.Length;
        int[][] resultado = new int[n][];
        for (int i = 0; i < n; i++)
        {
            resultado[i] = new int[n];
            for (int j = 0; j < n; j++)
            {
                resultado[i][j] = matrizA[i][j] - matrizB[i][j];
            }
        }
        return resultado;
    }
    /// <summary>
    /// Método privado que realiza la multiplicación de matrices de manera recursiva utilizando el algoritmo de Strassen-Winograd.
    /// </summary>
    /// <param name="matrizA">La primera matriz a multiplicar.</param>
    /// <param name="matrizB">La segunda matriz a multiplicar.</param>
    /// <param name="matrizResultado">La matriz en la que se almacenará el resultado.</param>
    /// <param name="cantidadFilasMatrices">El número de filas de las matrices.</param>
    /// <param name="m">Parámetro de ajuste del tamaño de la matriz.</param>
    /// <returns>La matriz resultado de la multiplicación.</returns>
    public static long[][] StrassenWinogradStep(long[][] matrizA, long[][] matrizB, long[][] matrizResultado, int cantidadFilasMatrices, int m)
    {
        int nuevoTamanio = 0;
        if ((cantidadFilasMatrices % 2 == 0) && (cantidadFilasMatrices > m))
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

            long[][] matrizA1 = new long[nuevoTamanio][];
            long[][] matrizA2 = new long[nuevoTamanio][];
            long[][] matrizB1 = new long[nuevoTamanio][];
            long[][] matrizB2 = new long[nuevoTamanio][];

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
            long[][] auxiliar8 = new long[nuevoTamanio][];
            long[][] auxiliar9 = new long[nuevoTamanio][];

            // Asignar memoria para cada fila
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

                matrizA1[i] = new long[nuevoTamanio];
                matrizA2[i] = new long[nuevoTamanio];
                matrizB1[i] = new long[nuevoTamanio];
                matrizB2[i] = new long[nuevoTamanio];

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
                auxiliar8[i] = new long[nuevoTamanio];
                auxiliar9[i] = new long[nuevoTamanio];
            }

            // Llenamos las matrices
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

            // computing the seven aux. variables
            matrizA1 = matrizA11.Zip(matrizA21, (rowA11, rowA21) => rowA11.Zip(rowA21, (a, b) => a + b).ToArray()).ToArray();
            matrizA2 = matrizA22.Zip(matrizA1, (rowA22, rowA1) => rowA22.Zip(rowA1, (a, b) => a + b).ToArray()).ToArray();
            matrizB1 = matrizB22.Zip(matrizB12, (rowB22, rowB12) => rowB22.Zip(rowB12, (a, b) => a + b).ToArray()).ToArray();
            matrizB2 = matrizB1.Zip(matrizB11, (rowB1, rowB11) => rowB1.Zip(rowB11, (a, b) => a + b).ToArray()).ToArray();

            auxiliar1 = StrassenWinogradStep(matrizA11, matrizB11, auxiliar1, nuevoTamanio, m);
            auxiliar2 = StrassenWinogradStep(matrizA12, matrizB21, auxiliar2, nuevoTamanio, m);
            auxiliar3 = StrassenWinogradStep(matrizA2, matrizB2, auxiliar3, nuevoTamanio, m);

            ayudante1 = matrizA21.Zip(matrizA22, (rowA21, rowA22) => rowA21.Zip(rowA22, (a, b) => a + b).ToArray()).ToArray();
            ayudante2 = matrizB12.Zip(matrizB11, (rowB12, rowB11) => rowB12.Zip(rowB11, (a, b) => a - b).ToArray()).ToArray();
            auxiliar4 = StrassenWinogradStep(ayudante1, ayudante2, auxiliar4, nuevoTamanio, m);

            auxiliar5 = StrassenWinogradStep(matrizA1, matrizB1, auxiliar5, nuevoTamanio, m);

            ayudante1 = matrizA12.Zip(matrizA2, (rowA12, rowA2) => rowA12.Zip(rowA2, (a, b) => a - b).ToArray()).ToArray();
            auxiliar6 = StrassenWinogradStep(ayudante1, matrizB22, auxiliar6, nuevoTamanio, m);

            ayudante1 = matrizB21.Zip(matrizB2, (rowB21, rowB2) => rowB21.Zip(rowB2, (a, b) => a - b).ToArray()).ToArray();
            auxiliar7 = StrassenWinogradStep(matrizA22, ayudante1, auxiliar7, nuevoTamanio, m);

            auxiliar8 = auxiliar1.Zip(auxiliar3, (rowA1, rowA3) => rowA1.Zip(rowA3, (a, b) => a + b).ToArray()).ToArray();
            auxiliar9 = auxiliar8.Zip(auxiliar4, (rowA8, rowA4) => rowA8.Zip(rowA4, (a, b) => a - b).ToArray()).ToArray();

            // Calcular partes de la matriz resultado
            matrizResultadoParte11 = auxiliar1.Zip(auxiliar2, (rowA1, rowA2) => rowA1.Zip(rowA2, (a, b) => a + b).ToArray()).ToArray();

            matrizResultadoParte12 = auxiliar9.Zip(auxiliar6, (rowA9, rowA6) => rowA9.Zip(rowA6, (a, b) => a + b).ToArray()).ToArray();

            ayudante1 = auxiliar8.Zip(auxiliar5, (rowA8, rowA5) => rowA8.Zip(rowA5, (a, b) => a - b).ToArray()).ToArray();
            matrizResultadoParte21 = ayudante1.Zip(auxiliar7, (rowAyd, rowA7) => rowAyd.Zip(rowA7, (a, b) => a + b).ToArray()).ToArray();

            matrizResultadoParte22 = auxiliar9.Zip(auxiliar5, (rowA9, rowA5) => rowA9.Zip(rowA5, (a, b) => a + b).ToArray()).ToArray();

            // Almacenar resultados en la matriz resultado
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
        return StrassenWinogradMultiply(matrix1,matrix2);
    }
}
