using Microsoft.VisualBasic.CompilerServices;
using Algoritmos.Util;
public class WinogradScaled{
    /// <summary>
    /// Realiza la multiplicación de dos matrices utilizando el algoritmo de Winograd escalado.
    /// Primero, crea copias escaladas de las matrices de entrada A y B. 
    /// Luego, calcula el factor de escala lambda basado en la norma infinito de las matrices originales. 
    /// Después, escala las matrices de entrada con el factor lambda y utiliza el algoritmo de Winograd original con las matrices escaladas para obtener el resultado final. 
    /// Los parámetros de entrada son las matrices A y B, y el tamaño de las matrices junto con el tamaño del resultado (N, P, M).
    /// </summary>
    /// <param name="A">Matriz A.</param>
    /// <param name="B">Matriz B.</param>
    /// <param name="Result">Matriz donde se almacenará el resultado.</param>
    /// <param name="N">Número de filas de la matriz A y número de columnas de la matriz B.</param>
    /// <param name="P">Número de columnas de la matriz A y número de filas de la matriz B.</param>
    /// <param name="M">Número de filas de la matriz B y de la matriz resultado.</param>
    public static void Multiplication(double[,] A, double[,] B)
    {
        int N = A[].Length;
        int P = B[0].Length;
        int M = A[0].Length;
        double[][] result = new int[rowsA][];
        int i;
        // Crear copias escaladas de A y B
        double[,] CopyA = new double[N, P];
        double[,] CopyB = new double[P, M];

        // Factor de escala
        double a = NormInf(A, N, P);
        double b = NormInf(B, P, M);
        double lambda = Math.Floor(0.5 + Math.Log(b / a) / Math.Log(4));

        // Escalar
        Util.MultiplyWithScalar(A, CopyA, N, P, Math.Pow(2, lambda));
        Util.MultiplyWithScalar(B, CopyB, P, M, Math.Pow(2, -lambda));

        // Utilizar Winograd con las matrices escaladas
        WinogradOriginal(CopyA, CopyB, Result, N, P, M);
    }
}