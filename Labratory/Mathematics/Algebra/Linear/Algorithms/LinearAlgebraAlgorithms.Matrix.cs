using System.Diagnostics;
using Labratory.Exceptions;
using Labratory.Mathematics.Algebra.Linear.Core.Abstractions;
using Labratory.Mathematics.Algebra.Linear.Core.Concretes;

namespace Labratory.Mathematics.Algebra.Linear.Algorithms;

public static partial class LinearAlgebraAlgorithms
{
    public static Matrix Multiplicate(this Matrix left, Matrix right)
    {
        LaboratoryException.ThrowIfNot(
            left.Cols == right.Rows,
            "Matrix multiplication is only defined when left.Cols == right.Rows",
            LaboratoryExceptionType.InvalidArgument);

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

    public static bool IsSkewSymmetric(this Matrix mat)
    {
        if (mat.Rows != mat.Cols)
        {
            return false;
        }

        return mat
            .Generate<Matrix, double, bool?>((i, j) => mat.At(i, j).Equals(-mat.At(j, i)))
            .All(x => x == true);
    }


    public static Matrix Multiplicate(this Matrix mat, double value)
    {
        mat.Operate<Matrix, double>((i, j) => mat.AtRef(i, j) *= value);
        return mat;
    }

    public static Matrix Add(this Matrix left, Matrix right)
    {
        // TODO: Validate left.shape == right.shape and throw exception when needed
        Debug.Assert(left.Rows == right.Rows);
        Debug.Assert(left.Cols == right.Cols);

        left.Operate<Matrix, double>((i, j) => left.AtRef(i, j) = left.At(i, j) + right.At(i, j));

        return left;
    }

    public static Matrix Add(this Matrix mat, double value)
    {
        mat.Operate<Matrix, double>((i, j) => mat.AtRef(i, j) += value);
        return mat;
    }

    public static Matrix Subtract(this Matrix left, Matrix right)
    {
        // TODO: Validate left.shape == right.shape and throw exception when needed
        Debug.Assert(left.Rows == right.Rows);
        Debug.Assert(left.Cols == right.Cols);

        left.Operate<Matrix, double>((i, j) => left.AtRef(i, j) = left.At(i, j) - right.At(i, j));

        return left;
    }

    public static Matrix Subtract(this Matrix mat, double value)
    {
        mat.Operate<Matrix, double>((i, j) => mat.AtRef(i, j) -= value);

        return mat;
    }

    public static Matrix MultiplicateElementWise(this Matrix left, Matrix right)
    {
        // TODO: Validate left.shape == right.shape and throw exception when needed
        Debug.Assert(left.Rows == right.Rows);
        Debug.Assert(left.Cols == right.Cols);

        left.Operate<Matrix, double>((i, j) => left.AtRef(i, j) = left.At(i, j) * right.At(i, j));

        return left;
    }

    public static Matrix Negate(this Matrix mat)
    {
        mat.Operate<Matrix, double>((i, j) => mat.AtRef(i, j) = -mat.At(i, j));

        return mat;
    }

    public static TMatrix Transpose<TMatrix, TData>(this TMatrix mat)
    where TMatrix : MatrixBase<TData>
    where TData : notnull
    {
        TMatrix transposed = (TMatrix)mat.New(mat.Cols, mat.Rows);
        mat.Operate<TMatrix, TData>((i, j) => transposed.AtRef(j, i) = mat.At(i, j));
        return transposed;
    }

    public static TMatrix Fill<TMatrix, TData>(this TMatrix mat, TData value)
    where TMatrix : MatrixBase<TData>
    where TData : notnull
    {
        mat.Operate<TMatrix, TData>((i, j) => mat.AtRef(i, j) = value);
        return mat;
    }

    public static Matrix Randomize(this Matrix mat)
    {
        mat.Operate<Matrix, double>((i, j) => mat.AtRef(i, j) = Random.Shared.NextDouble());

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

    public static TMatrix Copy<TMatrix, TData>(this TMatrix mat)
    where TMatrix : MatrixBase<TData>
    where TData : notnull
    {
        TMatrix destination = (TMatrix)mat.New(mat.Rows, mat.Cols);
        mat.Operate<TMatrix, TData>((i, j) => destination.AtRef(i, j) = mat.At(i, j));

        return destination;
    }
}