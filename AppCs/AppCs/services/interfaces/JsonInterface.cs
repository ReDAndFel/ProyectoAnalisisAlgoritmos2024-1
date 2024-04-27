using Newtonsoft.Json.Linq;

interface JsonInterface
{
     void modifyProperty(JObject json, String jsonFilePath, string property, double value);

     public JObject readJson(string jsonTimesFilePath);
     public (JArray, JArray) readJsonMatrices(string jsonMatrixPath, int caseIndex);
}