using System;
using System.Linq;
using services.interfaces;

public class StrassenWinograd : AlgorithmInterface
{

    public static int[][] StrassenWinogradMultiply(int[][] matrizA, int[][] matrizB)
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

        // Asignar memoria e inicializar Inicializar cada elemento de las nuevas matrices A y B con ceros
        for (int i = 0; i < nuevoTamanio; i++)
        {
            for (int j = 0; j < nuevoTamanio; j++)
            {
                nuevaMatrizA[i][j] = 0;
                nuevaMatrizB[i][j] = 0;
                matrizResultadoAuxiliar[i][j] = 0;
            }
        }

        // Asignamos en cada posición i,j de las nuevas matrices A y B los valores que están en las matrices A y B respectivamente
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

        matrizResultadoAuxiliar = StrassenWinogradStep(nuevaMatrizA, nuevaMatrizB, matrizResultadoAuxiliar, nuevoTamanio, m);

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
    /// Método privado que realiza la multiplicación de matrices de manera recursiva utilizando el algoritmo de Strassen-Winograd.
    /// </summary>
    /// <param name="matrizA">La primera matriz a multiplicar.</param>
    /// <param name="matrizB">La segunda matriz a multiplicar.</param>
    /// <param name="matrizResultado">La matriz en la que se almacenará el resultado.</param>
    /// <param name="cantidadFilasMatrices">El número de filas de las matrices.</param>
    /// <param name="m">Parámetro de ajuste del tamaño de la matriz.</param>
    /// <returns>La matriz resultado de la multiplicación.</returns>
    public static int[][] StrassenWinogradStep(int[][] matrizA, int[][] matrizB, int[][] matrizResultado, int cantidadFilasMatrices, int m)
    {
        int nuevoTamanio = 0;
        if ((cantidadFilasMatrices % 2 == 0) && (cantidadFilasMatrices > m))
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

            int[][] matrizA1 = new int[nuevoTamanio][];
            int[][] matrizA2 = new int[nuevoTamanio][];
            int[][] matrizB1 = new int[nuevoTamanio][];
            int[][] matrizB2 = new int[nuevoTamanio][];

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
            int[][] auxiliar8 = new int[nuevoTamanio][];
            int[][] auxiliar9 = new int[nuevoTamanio][];

            // Asignar memoria para cada fila
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

                matrizA1[i] = new int[nuevoTamanio];
                matrizA2[i] = new int[nuevoTamanio];
                matrizB1[i] = new int[nuevoTamanio];
                matrizB2[i] = new int[nuevoTamanio];

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
                auxiliar8[i] = new int[nuevoTamanio];
                auxiliar9[i] = new int[nuevoTamanio];
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

    public int[][] MultiplyMatrices(int[][] matrix1, int[][] matrix2)
    {
        return StrassenWinogradMultiply(matrix1,matrix2);
    }
}
