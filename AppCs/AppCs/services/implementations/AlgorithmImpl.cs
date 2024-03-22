using Newtonsoft.Json.Linq;

class AlgorithmImpl : AlgorithmInterface
{
    JsonImpl jsonImpl = new JsonImpl();
    public void addValue(JObject json,string jsonFilePath,string algorithm_name,int value)
    {
        jsonImpl.modifyProperty(json,jsonFilePath,algorithm_name,value);

    }
}