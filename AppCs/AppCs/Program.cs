using System.Diagnostics;
using Newtonsoft.Json.Linq;

class Program
{

    static void Main()
    {
        string matrixJsonPath = "../../matrix.json";
        for (int i = 0; i < 8; i++)
        {
            
            Console.Write("Caso " + (i + 1));
            string timesJsonPath = "../../times" + (i + 1) + ".json";
            JObject jsonTimes = JsonInterface.readJson(timesJsonPath);
            (long[][] matrix1, long[][] matrix2) = JsonInterface.readJsonMatrix(matrixJsonPath, (i + 1));
            /*
            // Crear una instancia del algoritmo NaivOnArray
            var naivOnArrayAlgorithm = new NaivOnArray();
            var algorithm = new JsonManager(naivOnArrayAlgorithm);
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            // Multiplicar las matrices usando el algoritmo NaivOnArray
            long[][] result = algorithm.MultiplyMatricesFromJson(matrix1, matrix2);
            stopwatch.Stop();
            //imprime y setea en el json el tiemp de ejecucion del algoritmo NaivOnArray
            Console.WriteLine("Tiempo de ejecución del algoritmo NaivOnArray: {0} segundos", stopwatch.Elapsed.TotalSeconds);
            JsonInterface.modifyProperty(jsonTimes, timesJsonPath, "NaivOnArray", stopwatch.Elapsed.TotalSeconds);

            
            // Crear una instancia del algoritmo naivLoopUnrollingTwo
            var naivLoopUnrollingTwo = new NaivLoopUnrollingTwo();
            var algorithm = new JsonManager(naivLoopUnrollingTwo);
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            // Multiplicar las matrices usando el algoritmo naivLoopUnrollingTwo
            long[][] result = algorithm.MultiplyMatricesFromJson(matrix1, matrix2);
            stopwatch.Stop();
            //imprime y setea en el json el tiemp de ejecucion del algoritmo NaivLoopUnrollingTwo
            Console.WriteLine("Tiempo de ejecución del algoritmo NaivLoopUnrollingTwo: {0} segundos", stopwatch.Elapsed.TotalSeconds);
            JsonInterface.modifyProperty(jsonTimes, timesJsonPath, "NaivLoopUnrollingTwo", stopwatch.Elapsed.TotalSeconds);
            
            // Crear una instancia del algoritmo naivLoopUnrollingFour
            var naivLoopUnrollingFour = new NaivLoopUnrollingFour();
            var algorithm = new JsonManager(naivLoopUnrollingFour);
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            // Multiplicar las matrices usando el algoritmo NaivLoopUnrollingFour
            long[][] result = algorithm.MultiplyMatricesFromJson(matrix1, matrix2);
            stopwatch.Stop();
            //imprime y setea en el json el tiemp de ejecucion del algoritmo NaivLoopUnrollingFour
            Console.WriteLine("Tiempo de ejecución del algoritmo NaivLoopUnrollingFour: {0} segundos", stopwatch.Elapsed.TotalSeconds);
            JsonInterface.modifyProperty(jsonTimes, timesJsonPath, "NaivLoopUnrollingFour", stopwatch.Elapsed.TotalSeconds);
            
                
            // Crear una instancia del algoritmo winogradOriginal
            var winogradOriginal = new Winograd();
            var algorithm = new JsonManager(winogradOriginal);
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            // Multiplicar las matrices usando el algoritmo WinogradOriginal
            long[][] result = algorithm.MultiplyMatricesFromJson(matrix1, matrix2);
            stopwatch.Stop();
            //imprime y setea en el json el tiemp de ejecucion del algoritmo WinogradOriginal
            Console.WriteLine("Tiempo de ejecución del algoritmo WinogradOriginal: {0} segundos", stopwatch.Elapsed.TotalSeconds);
            JsonInterface.modifyProperty(jsonTimes, timesJsonPath, "WinogradOriginal", stopwatch.Elapsed.TotalSeconds);
                        
            // Crear una instancia del algoritmo winogradScaled
            var winogradScaled = new WinogradScaled();
            var algorithm = new JsonManager(winogradScaled);
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            // Multiplicar las matrices usando el algoritmo WinogradScaled
            long[][] result = algorithm.MultiplyMatricesFromJson(matrix1, matrix2);
            stopwatch.Stop();
            //imprime y setea en el json el tiemp de ejecucion del algoritmo WinogradScaled
            Console.WriteLine("Tiempo de ejecución del algoritmo WinogradScaled: {0} segundos", stopwatch.Elapsed.TotalSeconds);
            JsonInterface.modifyProperty(jsonTimes, timesJsonPath, "WinogradScaled", stopwatch.Elapsed.TotalSeconds);
                        
            // Crear una instancia del algoritmo StrassenNaiv
            var strassenNaiv = new StrassenNaive();
            var algorithm = new JsonManager(strassenNaiv);
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            // Multiplicar las matrices usando el algoritmo StrassenNaiv
            long[][] result = algorithm.MultiplyMatricesFromJson(matrix1, matrix2);
            stopwatch.Stop();
            //imprime y setea en el json el tiemp de ejecucion del algoritmo StrassenNaiv
            Console.WriteLine("Tiempo de ejecución del algoritmo StrassenNaiv: {0} segundos", stopwatch.Elapsed.TotalSeconds);
            JsonInterface.modifyProperty(jsonTimes, timesJsonPath, "StrassenNaiv", stopwatch.Elapsed.TotalSeconds);
                        
            // Crear una instancia del algoritmo strassenWinograd
            var strassenWinograd = new StrassenWinograd();
            var algorithm = new JsonManager(strassenWinograd);
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            // Multiplicar las matrices usando el algoritmo StrassenWinograd
            long[][] result = algorithm.MultiplyMatricesFromJson(matrix1, matrix2);
            stopwatch.Stop();
            //imprime y setea en el json el tiemp de ejecucion del algoritmo StrassenWinograd
            Console.WriteLine("Tiempo de ejecución del algoritmo StrassenWinograd: {0} segundos", stopwatch.Elapsed.TotalSeconds);
            JsonInterface.modifyProperty(jsonTimes, timesJsonPath, "StrassenWinograd", stopwatch.Elapsed.TotalSeconds);
                        
            // Crear una instancia del algoritmo III.3 Sequential block
            var sequentialBlocks = new SequentialBlocks();
            var algorithm = new JsonManager(sequentialBlocks);
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            // Multiplicar las matrices usando el algoritmo III.3 Sequential block
            long[][] result = algorithm.MultiplyMatricesFromJson(matrix1, matrix2);
            stopwatch.Stop();
            //imprime y setea en el json el tiemp de ejecucion del algoritmo SequentialBlocks
            Console.WriteLine("Tiempo de ejecución del algoritmo III.3 Sequential block: {0} segundos", stopwatch.Elapsed.TotalSeconds);
            JsonInterface.modifyProperty(jsonTimes, timesJsonPath, "III.3 Sequential block", stopwatch.Elapsed.TotalSeconds);
            */
            
            // Crear una instancia del algoritmo III.4 Parallel Block
            var parallelBlocks = new ParallelBlocks();
            var algorithm = new JsonManager(parallelBlocks);
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            // Multiplicar las matrices usando el algoritmo III.4 Parallel Block
            long[][] result = algorithm.MultiplyMatricesFromJson(matrix1, matrix2);
            stopwatch.Stop();
            //imprime y setea en el json el tiemp de ejecucion del algoritmo SequentialBlocks
            Console.WriteLine("Tiempo de ejecución del algoritmo III.4 Parallel Block: {0} segundos", stopwatch.Elapsed.TotalSeconds);
            JsonInterface.modifyProperty(jsonTimes, timesJsonPath, "III.4 Parallel Block", stopwatch.Elapsed.TotalSeconds);
            /*
            // Crear una instancia del algoritmo III.5 Enhanced Parallel Block
            var enhancedParallelBlocks = new EnhancedParallelBlocks();
            algorithm = new JsonManager(enhancedParallelBlocks);
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            // Multiplicar las matrices usando el algoritmo III.5 Enhanced Parallel Block
            long[][] result = algorithm.MultiplyMatricesFromJson(matrix1, matrix2);
            stopwatch.Stop();
            //imprime y setea en el json el tiemp de ejecucion del algoritmo SequentialBlocks
            Console.WriteLine("Tiempo de ejecución del algoritmo III.5 Enhanced Parallel Block: {0} segundos", stopwatch.Elapsed.TotalSeconds);
            JsonInterface.modifyProperty(jsonTimes, timesJsonPath, "III.5 Enhanced Parallel Block", stopwatch.Elapsed.TotalSeconds);

            // Crear una instancia del algoritmo IV.3 Sequential block
            var sequentialBlocks2 = new IV3SequentialBlocks();
            algorithm = new JsonManager(sequentialBlocks2);
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            // Multiplicar las matrices usando el algoritmo IV.3 Sequential block
            long[][] result = algorithm.MultiplyMatricesFromJson(matrix1, matrix2);
            stopwatch.Stop();
            //imprime y setea en el json el tiemp de ejecucion del algoritmo IV.3 Sequential block
            Console.WriteLine("Tiempo de ejecución del algoritmo IV.3 Sequential block: {0} segundos", stopwatch.Elapsed.TotalSeconds);
            JsonInterface.modifyProperty(jsonTimes, timesJsonPath, "IV.3 Sequential block", stopwatch.Elapsed.TotalSeconds);

            // Crear una instancia del algoritmo IV.4 Parallel Block
            var parallelBlocks2 = new ParallelBlocks2();
            algorithm = new JsonManager(parallelBlocks2);
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            // Multiplicar las matrices usando el algoritmo IV.4 Parallel Block
            long[][] result = algorithm.MultiplyMatricesFromJson(matrix1, matrix2);
            stopwatch.Stop();
            //imprime y setea en el json el tiemp de ejecucion del algoritmo IV.4 Parallel Block
            Console.WriteLine("Tiempo de ejecución del algoritmo IV.4 Parallel Block: {0} segundos", stopwatch.Elapsed.TotalSeconds);
            JsonInterface.modifyProperty(jsonTimes, timesJsonPath, "IV.4 Parallel Block", stopwatch.Elapsed.TotalSeconds);

            // Crear una instancia del algoritmo IV.5 Enhanced Parallel Block
            var enhancedParallelBlocks2 = new ParallelBlocks();
            algorithm = new JsonManager(enhancedParallelBlocks2);
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            // Multiplicar las matrices usando el algoritmo IV.5 Enhanced Parallel Block
            long[][] result = algorithm.MultiplyMatricesFromJson(matrix1, matrix2);
            stopwatch.Stop();
            //imprime y setea en el json el tiemp de ejecucion del algoritmo IV.5 Enhanced Parallel Block
            Console.WriteLine("Tiempo de ejecución del algoritmo IV.5 Enhanced Parallel Block: {0} segundos", stopwatch.Elapsed.TotalSeconds);
            JsonInterface.modifyProperty(jsonTimes, timesJsonPath, "IV.5 Enhanced Parallel Block", stopwatch.Elapsed.TotalSeconds);

            // Crear una instancia del algoritmo V.3 Sequential block
            var sequentialBlock2 = new SequentialBlock2();
            algorithm = new JsonManager(sequentialBlock2);
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            // Multiplicar las matrices usando el algoritmo V.3 Sequential block
            long[][] result = algorithm.MultiplyMatricesFromJson(matrix1, matrix2);
            stopwatch.Stop();
            //imprime y setea en el json el tiemp de ejecucion del algoritmo V.3 Sequential block
            Console.WriteLine("Tiempo de ejecución del algoritmo V.3 Sequential block: {0} segundos", stopwatch.Elapsed.TotalSeconds);
            JsonInterface.modifyProperty(jsonTimes, timesJsonPath, "V.3 Sequential block", stopwatch.Elapsed.TotalSeconds);


            // Crear una instancia del algoritmo V.4 Parallel Block
            var parallelBlocks3 = new ParallelBlock3();
            algorithm = new JsonManager(parallelBlocks3);
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            // Multiplicar las matrices usando el algoritmo V.4 Parallel Block
            long[][] result = algorithm.MultiplyMatricesFromJson(matrix1, matrix2);
            stopwatch.Stop();
            //imprime y setea en el json el tiemp de ejecucion del algoritmo V.4 Parallel Block
            Console.WriteLine("Tiempo de ejecución del algoritmo V.4 Parallel Block: {0} segundos", stopwatch.Elapsed.TotalSeconds);
            JsonInterface.modifyProperty(jsonTimes, timesJsonPath, "V.4 Parallel Block", stopwatch.Elapsed.TotalSeconds);
        }*/
        }
    }
}