using Newtonsoft.Json.Linq;

class Program
{
    static void Main(string[] args)
    {
        string jsonTimesFilePath = "../../times.json";
        string jsonMatrixFilePath = "../../Matrix.json";

        AlgorithmImpl algorithmImpl = new AlgorithmImpl();
        JsonImpl jsonImpl = new JsonImpl();

        JObject jsonTimes = jsonImpl.readJson(jsonTimesFilePath);
        JArray jsonMatrix = jsonImpl.readJsonMatrix(jsonMatrixFilePath);

        // Suponiendo que el JSON solo contiene una matriz directamente
        JArray matrix = JArray.Parse(jsonMatrix.ToString());

        Console.WriteLine("La matriz del JSON es la siguiente:");

        // Recorrer la matriz
        for (int i = 0; i < matrix.Count(); i++)
        {
            for (int j = 0; j < matrix[i].Count(); j++)
            {
                Console.Write(matrix[i][j] + " ");
            }
            Console.WriteLine();
        }

        // Modificar propiedad "NaivOnArray" en "Cs por el valor 1"
        algorithmImpl.addValue(jsonTimes, jsonTimesFilePath, "NaivOnArray", 1);


    }


}
