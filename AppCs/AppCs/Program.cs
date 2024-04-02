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
        (JArray matrix1, JArray matrix2) = jsonImpl.readJsonMatrices(jsonMatrixFilePath);
        
        // Imprimir la matriz1 del JSON
        Console.WriteLine("La matriz1 del JSON es la siguiente:");
        foreach (JArray row in matrix1)
        {
            foreach (var element in row)
            {
                Console.Write(element + " ");
            }
            Console.WriteLine();
        }

        // Imprimir la matriz2 del JSON
        Console.WriteLine("La matriz2 del JSON es la siguiente:");
        foreach (JArray row in matrix2)
        {
            foreach (var element in row)
            {
                Console.Write(element + " ");
            }
            Console.WriteLine();
        }


        // Modificar propiedad "NaivOnArray" en "Cs por el valor 1"
        //algorithmImpl.addValue(jsonTimes, jsonTimesFilePath, "NaivOnArray", 1);


    }


}
