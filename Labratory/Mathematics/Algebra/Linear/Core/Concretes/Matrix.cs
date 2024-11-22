namespace Labratory.Mathematics.Algebra.Linear.Core.Concretes;

public class Matrix
{
    public int Rows { get; }
    public int Cols { get; }
    private double[,] _mat { get; }

    public Matrix(int rows, int cols)
    {
        Rows = rows;
        Cols = cols;
        _mat = new double[Rows, Cols];
    }

    public ref double AtRef(int i, int j)
    {
        return ref _mat[i, j];
    }

    public double At(int i, int j)
    {
        return _mat[i, j];
    }
}