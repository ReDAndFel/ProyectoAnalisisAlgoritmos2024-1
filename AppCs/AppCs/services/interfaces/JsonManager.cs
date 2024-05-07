using services.interfaces;

public class JsonManager
{
    private AlgorithmInterface algorithm;

    public JsonManager(AlgorithmInterface algorithm)
    {
        this.algorithm = algorithm;
    }

    public long[][] MultiplyMatricesFromJson(long[][] matrix1, long[][] matrix2)
    {
        return algorithm.MultiplyMatrices(matrix1, matrix2);
    }
}
