using Newtonsoft.Json.Linq;

public class JsonInterface
{
    public static void modifyProperty(JObject json, String jsonFilePath, string property, int value)
    {
        json["cs"][property] = value;
        string modifiedJson = json.ToString();
        File.WriteAllText(jsonFilePath, modifiedJson);
    }

    public static JObject readJson(string jsonTimesFilePath)
    {
        string initialJsonText = File.ReadAllText(jsonTimesFilePath);
        JObject json = JObject.Parse(initialJsonText);
        return json;
    }
    public static (long[][], long[][]) readJsonMatrix(string jsonMatrixFilePath, int caseIndex)
    {
        // Lee el archivo JSON
        string jsonString = File.ReadAllText(jsonMatrixFilePath);

        // Parsea el JSON como un objeto JSON
        JObject jsonObject = JObject.Parse(jsonString);

        // Construye la clave del caso específico
        string caseKey = "caso" + caseIndex;

        // Accede a las matrices dentro del caso específico
        JArray matrix1Array = (JArray)jsonObject[caseKey]["matrix1"];
        JArray matrix2Array = (JArray)jsonObject[caseKey]["matrix2"];

        // Convierte los arrays de matrices en matrices de enteros
        long[][] matrix1 = matrix1Array.Select(a => a.ToObject<long[]>()).ToArray();
        long[][] matrix2 = matrix2Array.Select(a => a.ToObject<long[]>()).ToArray();

        return (matrix1, matrix2);
    }
}