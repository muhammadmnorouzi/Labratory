using System.Diagnostics;

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

    public void Fill(double value)
    {
        Operation((mat, i, j) => mat.AtRef(i, j) = value);
    }

    public ref double AtRef(int i, int j)
    {
        return ref _mat[i, j];
    }

    public double At(int i, int j)
    {
        return _mat[i, j];
    }

    public void Operation(Action<Matrix, int, int> operation)
    {
        for (int i = 0; i < Rows; i++)
        {
            for (int j = 0; j < Cols; j++)
            {
                operation(this, i, j);
            }
        }
    }

    public Matrix Transpose()
    {
        Matrix transposed = new(Cols, Rows);
        Operation((mat, i, j) => transposed.AtRef(j, i) = mat.At(i, j));
        return transposed;
    }

    public IEnumerable<double> Row(int i)
    {
        // TODO Validate row number throw exception if invalid
        for (int j = 0; j < Cols; j++)
        {
            yield return At(i, j);
        }
    }

    public IEnumerable<double> Col(int j)
    {
        // TODO Validate col number throw exception if invalid
        for (int i = 0; i < Rows; i++)
        {
            yield return At(i, j);
        }
    }

    public void Print(TextWriter writer)
    {
        for (int i = 0; i < Rows; i++)
        {
            for (int j = 0; j < Cols; j++)
            {
                writer.Write($"\t{_mat[i, j]}");
            }

            writer.WriteLine();
        }

        writer.WriteLine();
    }

    public void Randomize()
    {
        Operation((mat, i, j) => mat.AtRef(i, j) = Random.Shared.NextDouble());
    }

    public Matrix Multiplicate(Matrix other)
    {
        // TODO: Validate this.Cols == other.Rows and throw exception when needed
        Debug.Assert(this.Cols == other.Rows);

        Matrix result = new(this.Rows, other.Cols);

        for (int i = 0; i < this.Rows; i++)
        {
            for (int j = 0; j < other.Cols; j++)
            {
                result.AtRef(i, j) = Row(i).Zip(other.Col(j)).Select(x => x.First * x.Second).Sum();
            }
        }

        return result;
    }

    public void Eye(double value = 1.0D)
    {
        for (int i = 0; i < Math.Min(Rows, Cols); i++)
        {
            AtRef(i, i) = value;
        }
    }
}