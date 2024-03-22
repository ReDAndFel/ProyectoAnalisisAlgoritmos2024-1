using Newtonsoft.Json.Linq;

interface JsonInterface {
     void modifyProperty(JObject json, String jsonFilePath, string property, int value);
}