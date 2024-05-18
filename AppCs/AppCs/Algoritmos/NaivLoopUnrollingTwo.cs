//Algoritmo basado en el libro METHODS OF MATRIX MULTIPLICATION AN OVERVIEW OF SEVERAL METHODS AND THEIR IMPLEMENTATION y apoyado en IA
using System;
using services.interfaces;
public class NaivLoopUnrollingTwo : AlgorithmInterface {
    /// <summary>
    /// La multiplicación se realiza fila por columna. Se verifica si el número de columnas de la matriz A es par o impar y se ajusta el bucle interno en consecuencia.
    /// </summary>
    /// <param name="A">Matriz A.</param>
    /// <param name="B">Matriz B.</param>
    /// <returns>Matriz resultado de la multiplicación de A y B.</returns>
    public static long[][] Multiplication(long[][] A, long[][] B) {
        // Obtiene las cantidades de columnas y filas
        int N = A.Length;
        int P = B[0].Length;
        int M = A[0].Length;
        //Inicializa con ceros la matriz result
        long[][] result = new long[N][];
        for (int o = 0; o < N; o++)
        {
            result[o] = new long[M];
        }
        int i, j, k;
        long aux;

        // Realiza la multiplicación de matrices utilizando bucles desenrollados
        if (P % 2 == 0) {
            // Si P es par
            for (i = 0; i < N; i++) {
                for (j = 0; j < M; j++) {
                    aux = 0;
                    for (k = 0; k < P; k += 2) {
                        // Realiza la multiplicación de 2 elementos a la vez y suma los resultados
                        aux += A[i][k] * B[k][j] + A[i][k + 1] * B[k + 1][j];
                    }
                    // Añade el producto de los elementos
                    result[i][j] = aux;
                }
            }
        } else {
            // Si P es impar
            int PP = P - 1;
            for (i = 0; i < N; i++) {
                for (j = 0; j < M; j++) {
                    aux = 0;
                    for (k = 0; k < PP; k += 2) {
                        // Realiza la multiplicación de 2 elementos a la vez y suma los resultados
                        aux += A[i][k] * B[k][j] + A[i][k + 1] * B[k + 1][j];
                    }
                    // Añade el producto de los elementos
                    result[i][j] = aux + A[i][PP] * B[PP][j];
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