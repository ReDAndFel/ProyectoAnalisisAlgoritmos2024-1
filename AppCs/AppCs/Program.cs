using System.Diagnostics;
using Newtonsoft.Json.Linq;
class Program
{
    static void Main(string[] args)
    {
        string jsonMatrixFilePath = "../../matrixExperimental.json";

        JsonInterface jsonInterface = new JsonImpl();

        for (int i = 1; i <= 8; i++)
        {
            string jsonTimesFilePath = "../../times" + i + ".json";
            JObject jsonTimes = jsonInterface.readJson(jsonTimesFilePath);
            (JArray matrix1, JArray matrix2) = jsonInterface.readJsonMatrices(jsonMatrixFilePath, i);
            Console.WriteLine("Caso:" + i);

            // Imprimir la matriz1 del JSON
            Console.WriteLine("matriz 1:");
            foreach (JArray row in matrix1)
            {
                foreach (var element in row)
                {
                    Console.Write(element + " ");
                }
                Console.WriteLine();
            }

            // Imprimir la matriz2 del JSON
            Console.WriteLine("matriz 2:");
            foreach (JArray row in matrix2)
            {
                foreach (var element in row)
                {
                    Console.Write(element + " ");
                }
                Console.WriteLine();
            }

            // Se ejecuta el algoritmo V.4 Parallel Block
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            //double[,] matrix_result_NaivOnArray = (agregar aqui la invocacion);
            stopwatch.Stop();
            double elapsed_time = stopwatch.Elapsed.TotalSeconds;
            // Modificar propiedad JSON (suponiendo que tienes una clase o método para manejar JSON)
            //agrega el tiempo a la etiqueta NaivOnArray del json times 
            jsonInterface.modifyProperty(jsonTimes, jsonTimesFilePath, "NaivOnArray", elapsed_time);
            // Imprimir el tiempo de ejecución
            Console.WriteLine("Tiempo de ejecución de NaivOnArray: {0} segundos", elapsed_time);
            
            
        }



    }


}
