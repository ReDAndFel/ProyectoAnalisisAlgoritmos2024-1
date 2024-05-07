using System.Diagnostics;

class Program
{

    static void Main()
    {
        string matrixJsonPath = "../../matrixExperimental.json";
        for (int i = 0; i < 8; i++)
        {
            Console.Write("Caso " + (i+1));
            (long[][] matrix1, long[][] matrix2) = JsonInterface.readJsonMatrix(matrixJsonPath, (i + 1));
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            // Crear una instancia del algoritmo NaivOnArray
            var naivOnArrayAlgorithm = new NaivOnArray();
            var algorithm = new JsonManager(naivOnArrayAlgorithm);
            // Multiplicar las matrices usando el algoritmo NaivOnArray
            long[][] result = algorithm.MultiplyMatricesFromJson(matrix1, matrix2);
            stopwatch.Stop(); // Detener la medición.
            // Mostrar el tiempo transcurriodo con un formato hh:mm:ss.000
            Console.WriteLine("Time elapsed: {0}", stopwatch.Elapsed.ToString("hh\\:mm\\:ss\\.fff"));            
            // Imprimir la matriz resultante
            Console.WriteLine("Resultado de la NaivOnArray:");
            PrintMatrix(result);
            /*
            // Crear una instancia del algoritmo naivLoopUnrollingTwo
            var naivLoopUnrollingTwo = new NaivLoopUnrollingTwo();
            algorithm = new JsonManager(naivLoopUnrollingTwo);

            // Multiplicar las matrices usando el algoritmo naivLoopUnrollingTwo
            result = algorithm.MultiplyMatricesFromJson(matrix1, matrix2);

            // Imprimir la matriz resultante
            Console.WriteLine("Resultado de naivLoopUnrollingTwo:");
            PrintMatrix(result);

            // Crear una instancia del algoritmo naivLoopUnrollingFour
            var naivLoopUnrollingFour = new NaivLoopUnrollingFour();
            algorithm = new JsonManager(naivLoopUnrollingFour);

            // Multiplicar las matrices usando el algoritmo StrassenNaive
            result = algorithm.MultiplyMatricesFromJson(matrix1, matrix2);

            // Imprimir la matriz resultante
            Console.WriteLine("Resultado de naivLoopUnrollingFour:");
            PrintMatrix(result);

            // Crear una instancia del algoritmo winogradOriginal
            var winogradOriginal = new Winograd();
            algorithm = new JsonManager(winogradOriginal);

            // Multiplicar las matrices usando el algoritmo StrassenNaive
            result = algorithm.MultiplyMatricesFromJson(matrix1, matrix2);

            // Imprimir la matriz resultante
            Console.WriteLine("Resultado de winogradOriginal:");
            PrintMatrix(result);

            // Crear una instancia del algoritmo winogradScaled
            var winogradScaled = new WinogradScaled();
            algorithm = new JsonManager(winogradScaled);

            // Multiplicar las matrices usando el algoritmo StrassenNaive
            result = algorithm.MultiplyMatricesFromJson(matrix1, matrix2);

            // Imprimir la matriz resultante
            Console.WriteLine("Resultado de winogradScaled:");
            PrintMatrix(result);

            // Crear una instancia del algoritmo StrassenNaive
            var strassenNaiv = new StrassenNaive();
            algorithm = new JsonManager(strassenNaiv);

            // Multiplicar las matrices usando el algoritmo StrassenNaive
            result = algorithm.MultiplyMatricesFromJson(matrix1, matrix2);

            // Imprimir la matriz resultante
            Console.WriteLine("Resultado de la StrassenNaive:");
            PrintMatrix(result);

            // Crear una instancia del algoritmo strassenWinograd
            var strassenWinograd = new StrassenWinograd();
            algorithm = new JsonManager(strassenWinograd);

            // Multiplicar las matrices usando el algoritmo strassenWinograd
            result = algorithm.MultiplyMatricesFromJson(matrix1, matrix2);

            // Imprimir la matriz resultante
            Console.WriteLine("Resultado de strassenWinograd:");
            PrintMatrix(result);

            // Crear una instancia del algoritmo sequentialBlocks
            var sequentialBlocks = new SequentialBlocks();
            algorithm = new JsonManager(sequentialBlocks);

            // Multiplicar las matrices usando el algoritmo SequentialBlocks
            result = algorithm.MultiplyMatricesFromJson(matrix1, matrix2);

            // Imprimir la matriz resultante
            Console.WriteLine("Resultado de sequentialBlocks:");
            PrintMatrix(result);

            // Crear una instancia del algoritmo parallelBlocks
            var parallelBlocks = new ParallelBlocks();
            algorithm = new JsonManager(parallelBlocks);

            // Multiplicar las matrices usando el algoritmo parallelBlocks
            result = algorithm.MultiplyMatricesFromJson(matrix1, matrix2);

            // Imprimir la matriz resultante
            Console.WriteLine("Resultado de parallelBlocks:");
            PrintMatrix(result);

            // Crear una instancia del algoritmo enhancedParallelBlocks
            var enhancedParallelBlocks = new EnhancedParallelBlocks();
            algorithm = new JsonManager(enhancedParallelBlocks);

            // Multiplicar las matrices usando el algoritmo enhancedParallelBlocks
            result = algorithm.MultiplyMatricesFromJson(matrix1, matrix2);

            // Imprimir la matriz resultante
            Console.WriteLine("Resultado de enhancedParallelBlocks:");
            PrintMatrix(result);

            // Crear una instancia del algoritmo IV3SequentialBlocks
            var sequentialBlocks2 = new IV3SequentialBlocks();
            algorithm = new JsonManager(sequentialBlocks2);

            // Multiplicar las matrices usando el algoritmo IV3SequentialBlocks
            result = algorithm.MultiplyMatricesFromJson(matrix1, matrix2);

            // Imprimir la matriz resultante
            Console.WriteLine("Resultado de IV3SequentialBlocks:");
            PrintMatrix(result);

            // Crear una instancia del algoritmo IV.4parallelBlocks
            var parallelBlocks2 = new ParallelBlocks2();
            algorithm = new JsonManager(parallelBlocks2);

            // Multiplicar las matrices usando el algoritmo IV.4parallelBlocks
            result = algorithm.MultiplyMatricesFromJson(matrix1, matrix2);

            // Imprimir la matriz resultante
            Console.WriteLine("Resultado de IV.4parallelBlocks:");
            PrintMatrix(result);

            // Crear una instancia del algoritmo IV.5enhancedParallelBlocks
            var enhancedParallelBlocks2 = new ParallelBlocks();
            algorithm = new JsonManager(enhancedParallelBlocks2);

            // Multiplicar las matrices usando el algoritmo IV.5enhancedParallelBlocks
            result = algorithm.MultiplyMatricesFromJson(matrix1, matrix2);

            // Imprimir la matriz resultante
            Console.WriteLine("Resultado de IV.5enhancedParallelBlocks:");
            PrintMatrix(result);

            // Crear una instancia del algoritmo V3.sequentialBlock
            var sequentialBlock2 = new SequentialBlock2();
            algorithm = new JsonManager(sequentialBlock2);

            // Multiplicar las matrices usando el algoritmo V3.sequentialBlock2
            result = algorithm.MultiplyMatricesFromJson(matrix1, matrix2);

            // Imprimir la matriz resultante
            Console.WriteLine("Resultado de V3.SequentialBlock2:");
            PrintMatrix(result);

            // Crear una instancia del algoritmo V4.ParallelBlocks
            var parallelBlocks3 = new ParallelBlock3();
            algorithm = new JsonManager(parallelBlocks3);

            // Multiplicar las matrices usando el algoritmo V4.ParallelBlocks
            result = algorithm.MultiplyMatricesFromJson(matrix1, matrix2);

            // Imprimir la matriz resultante
            Console.WriteLine("Resultado de V4.ParallelBlocks:");
            PrintMatrix(result);*/
        }
    }

    static void PrintMatrix(long[][] matrix)
    {
        Console.Write(matrix[matrix.Length - 1][matrix.Length - 1] + "\n");
    }
}