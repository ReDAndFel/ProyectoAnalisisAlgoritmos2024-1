using Newtonsoft.Json.Linq;

interface AlgorithmInterface{
    void addValue(JObject json,String jsonFilePath,string algorithm_name,int value);
}