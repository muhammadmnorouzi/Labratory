using Labratory.Mathematics.Algebra.Linear.Core.Abstractions;

namespace Labratory.Mathematics.Algebra.Linear.Algorithms;

public static partial class LinearAlgebraAlgorithms
{
    public static TMatrix Operate<TMatrix, TData>(this TMatrix mat, Action<int, int> operation)
    where TMatrix : MatrixBase<TData>
    where TData : notnull
    {
        for (int i = 0; i < mat.Rows; i++)
        {
            for (int j = 0; j < mat.Cols; j++)
            {
                operation(i, j);
            }
        }

        return mat;
    }

    public static IEnumerable<TResult> Generate<TMatrix, TData, TResult>(this TMatrix mat, Func<int, int, TResult> operation)
    where TMatrix : MatrixBase<TData>
    where TData : notnull
    {
        for (int i = 0; i < mat.Rows; i++)
        {
            for (int j = 0; j < mat.Cols; j++)
            {
                yield return operation(i, j);
            }
        }
    }

    public static bool IsSymetric<TMatrix, TData>(this TMatrix mat)
    where TMatrix : MatrixBase<TData>
    where TData : notnull
    {
        if (mat.Rows != mat.Cols)
        {
            return false;
        }

        return mat
            .Generate<TMatrix, TData, bool?>((i, j) => mat.At(i, j)?.Equals(mat.At(j, i)))
            .All(x => x == true);
    }
}