using System.Diagnostics;
using Labratory.Mathematics.Algebra.Linear.Core.Concretes;

namespace Labratory.Mathematics.Algebra.Linear.Algorithms;

public static partial class LinearAlgebraAlgorithms
{
    public static Matrix Multiplicate(this Matrix left, Matrix right)
    {
        // TODO: Validate this.Cols == other.Rows and throw exception when needed
        Debug.Assert(left.Cols == right.Rows);

        Matrix result = new(left.Rows, right.Cols);

        for (int i = 0; i < left.Rows; i++)
        {
            for (int j = 0; j < right.Cols; j++)
            {
                result.AtRef(i, j) = left.Row(i).Zip(right.Col(j)).Select(x => x.First * x.Second).Sum();
            }
        }

        return result;
    }

    public static Matrix Multiplicate(this Matrix mat, double value)
    {
        mat.Operation((_, i, j) => mat.AtRef(i, j) *= value);
        return mat;
    }

    public static Matrix Add(this Matrix left, Matrix right)
    {
        // TODO: Validate left.shape == right.shape and throw exception when needed
        Debug.Assert(left.Rows == right.Rows);
        Debug.Assert(left.Cols == right.Cols);

        left.Operation((mat, i, j) => mat.AtRef(i, j) = left.At(i, j) + right.At(i, j));
        return left;
    }

    public static Matrix Add(this Matrix mat, double value)
    {
        mat.Operation((_, i, j) => mat.AtRef(i, j) += value);
        return mat;
    }

    public static Matrix Subtract(this Matrix left, Matrix right)
    {
        // TODO: Validate left.shape == right.shape and throw exception when needed
        Debug.Assert(left.Rows == right.Rows);
        Debug.Assert(left.Cols == right.Cols);

        left.Operation((mat, i, j) => mat.AtRef(i, j) = left.At(i, j) - right.At(i, j));
        return left;
    }

    public static Matrix Subtract(this Matrix mat, double value)
    {
        mat.Operation((_, i, j) => mat.AtRef(i, j) -= value);
        return mat;
    }

    public static Matrix MultiplicateElementWise(this Matrix left, Matrix right)
    {
        // TODO: Validate left.shape == right.shape and throw exception when needed
        Debug.Assert(left.Rows == right.Rows);
        Debug.Assert(left.Cols == right.Cols);

        left.Operation((mat, i, j) => mat.AtRef(i, j) = left.At(i, j) * right.At(i, j));
        return left;
    }

    public static Matrix Negate(this Matrix mat)
    {
        mat.Operation((_, i, j) => mat.AtRef(i, j) = -mat.At(i, j));
        return mat;
    }

    public static Matrix Transpose(this Matrix mat)
    {
        Matrix transposed = new(mat.Cols, mat.Rows);
        mat.Operation((mat, i, j) => transposed.AtRef(j, i) = mat.At(i, j));
        return transposed;
    }

    public static Matrix Fill(this Matrix mat, double value)
    {
        mat.Operation((mat, i, j) => mat.AtRef(i, j) = value);
        return mat;
    }

    public static Matrix Operation(this Matrix mat, Action<Matrix, int, int> operation)
    {
        for (int i = 0; i < mat.Rows; i++)
        {
            for (int j = 0; j < mat.Cols; j++)
            {
                operation(mat, i, j);
            }
        }

        return mat;
    }

    public static Matrix Randomize(this Matrix mat)
    {
        mat.Operation((mat, i, j) => mat.AtRef(i, j) = Random.Shared.NextDouble());

        return mat;
    }

    public static Matrix Eye(this Matrix mat, double value = 1.0D)
    {
        // TODO: this.Rows == this.Cols
        Debug.Assert(mat.Rows == mat.Cols);

        for (int i = 0; i < mat.Rows; i++)
        {
            mat.AtRef(i, i) = value;
        }

        return mat;
    }

    public static IEnumerable<double> Row(this Matrix mat, int i)
    {
        // TODO Validate row number throw exception if invalid
        for (int j = 0; j < mat.Cols; j++)
        {
            yield return mat.At(i, j);
        }
    }

    public static IEnumerable<double> Col(this Matrix mat, int j)
    {
        // TODO Validate col number throw exception if invalid
        for (int i = 0; i < mat.Rows; i++)
        {
            yield return mat.At(i, j);
        }
    }

    public static Matrix Print(this Matrix mat, TextWriter writer)
    {
        for (int i = 0; i < mat.Rows; i++)
        {
            for (int j = 0; j < mat.Cols; j++)
            {
                writer.Write($"\t{mat.At(i, j)}");
            }

            writer.WriteLine();
        }

        writer.WriteLine();

        return mat;
    }

    public static Matrix Clone(this Matrix mat)
    {
        Matrix result = new(mat.Rows, mat.Cols);
        mat.Operation((matrix, i, j) => result.AtRef(i, j) = matrix.At(i, j));
        return result;
    }
}