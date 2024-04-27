using Newtonsoft.Json.Linq;

class JsonImpl : JsonInterface
{
    public void modifyProperty(JObject json,String jsonFilePath, string property, double value)
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
    public (JArray, JArray) readJsonMatrices(string jsonMatrixPath, int caseIndex)
{
    string jsonString = File.ReadAllText(jsonMatrixPath);
    JObject jsonObject = JObject.Parse(jsonString);
    string caseKey = "caso" + caseIndex;
    JArray matrix1 = (JArray)jsonObject[caseKey]["matrix1"];
    JArray matrix2 = (JArray)jsonObject[caseKey]["matrix2"];
    return (matrix1, matrix2);
}
}