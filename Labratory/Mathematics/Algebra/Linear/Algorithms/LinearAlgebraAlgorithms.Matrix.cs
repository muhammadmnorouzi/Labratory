using System.Diagnostics;
using Labratory.Exceptions;
using Labratory.Generics;
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
                result.AtRef(i, j) = left
                    .Row<Matrix, double>(i)
                    .Zip(right.Col<Matrix, double>(j))
                    .Select(x => x.First * x.Second)
                    .Sum();
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

    public static double Determinant(this Matrix mat)
    {
        LaboratoryException.ThrowIfNot(
            mat.Rows == mat.Cols,
            "Determinant is only defined for square matrices!",
            LaboratoryExceptionType.InvalidArgument);

        IEnumerable<IDictionary<int,int>> permutations = Enumerable.Range(0 , mat.Rows).Permutate();

        double determinant = 0;

        foreach(IDictionary<int, int> permutation in permutations)
        {
            double middle = 1;
            double sign= 0;

            sign = (1 + permutation[1]) % 2 == 0
                ? 1
                : -1;

            for(int i = 0; i < mat.Rows; ++i)
            {
                middle *= mat.At(i , permutation[i]);
            }

            middle *= sign;

            determinant += middle;
        }

        return determinant;
    }
}