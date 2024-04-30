using services.interfaces;

public class JsonManager
{
    private AlgorithmInterface algorithm;

    public JsonManager(AlgorithmInterface algorithm)
    {
        this.algorithm = algorithm;
    }

    public int[][] MultiplyMatricesFromJson(int[][] matrix1, int[][] matrix2)
    {
        return algorithm.MultiplyMatrices(matrix1, matrix2);
    }
}
