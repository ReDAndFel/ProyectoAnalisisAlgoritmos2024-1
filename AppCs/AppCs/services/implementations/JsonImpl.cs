using Newtonsoft.Json.Linq;

class JsonImpl : JsonInterface
{
    public void modifyProperty(JObject json,String jsonFilePath, string property, int value)
    {
        json["cs"][property] = value;
        string modifiedJson = json.ToString();
        File.WriteAllText(jsonFilePath, modifiedJson);
    }

    public JObject readJson(string jsonTimesFilePath)
    {
        string initialJsonText = File.ReadAllText(jsonTimesFilePath);
        JObject json = JObject.Parse(initialJsonText); 
        return json; 
    }
    public (JArray, JArray) readJsonMatrices(string jsonMatrixPath)
    {
        string jsonString = File.ReadAllText(jsonMatrixPath);
        JObject jsonObject = JObject.Parse(jsonString);
        JArray matrix1 = (JArray)jsonObject["matrix1"];
        JArray matrix2 = (JArray)jsonObject["matrix2"];
        return (matrix1, matrix2);
    }
}