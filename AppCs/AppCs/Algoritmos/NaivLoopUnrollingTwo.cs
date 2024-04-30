using services.interfaces;
public class NaivLoopUnrollingTwo : AlgorithmInterface {
    /// <summary>
    /// La multiplicación se realiza fila por columna. Se verifica si el número de columnas de la matriz A es par o impar y se ajusta el bucle interno en consecuencia.
    /// </summary>
    /// <param name="A">Matriz A.</param>
    /// <param name="B">Matriz B.</param>
    /// <returns>Matriz resultado de la multiplicación de A y B.</returns>
    public static int[][] Multiplication(int[][] A, int[][] B) {
        int N = A.Length;
        int P = B[0].Length;
        int M = A[0].Length;
        int[][] result = new int[N][];
        for (int o = 0; o < N; o++)
        {
            result[o] = new int[M];
        }
        int i, j, k;
        int aux;

        if (P % 2 == 0) {
            // Si P es par
            for (i = 0; i < N; i++) {
                for (j = 0; j < M; j++) {
                    aux = 0;
                    for (k = 0; k < P; k += 2) {
                        aux += A[i][k] * B[k][j] + A[i][k + 1] * B[k + 1][j];
                    }
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
                        aux += A[i][k] * B[k][j] + A[i][k + 1] * B[k + 1][j];
                    }
                    result[i][j] = aux + A[i][PP] * B[PP][j];
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