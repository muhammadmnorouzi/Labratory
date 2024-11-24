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



    public static TMatrix Copy<TMatrix, TData>(this TMatrix mat)
    where TMatrix : MatrixBase<TData>
    where TData : notnull
    {
        TMatrix destination = (TMatrix)mat.New(mat.Rows, mat.Cols);
        mat.Operate<TMatrix, TData>((i, j) => destination.AtRef(i, j) = mat.At(i, j));

        return destination;
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

    public static IEnumerable<TData> Row<TMatrix, TData>(this TMatrix mat, int i)
      where TMatrix : MatrixBase<TData>
        where TData : notnull
    {
        // TODO Validate row number throw exception if invalid

        for (int j = 0; j < mat.Cols; j++)
        {
            yield return mat.At(i, j);
        }
    }

    public static IEnumerable<TData> Col<TMatrix, TData>(this TMatrix mat, int j)
              where TMatrix : MatrixBase<TData>
        where TData : notnull
    {
        // TODO Validate col number throw exception if invalid
        for (int i = 0; i < mat.Rows; i++)
        {
            yield return mat.At(i, j);
        }
    }

    public static TMatrix SubMatrix<TMatrix, TData>(this TMatrix mat, Range rowRange, Range colRange)
        where TMatrix : MatrixBase<TData>
        where TData : notnull
    {
        // TODO: validate ranges and throw exception with proper error message if required@

        int rows = rowRange.End.Value - rowRange.Start.Value + 1;
        int cols = colRange.End.Value - colRange.Start.Value + 1;
        TMatrix subMatrix = (TMatrix)mat.New(rows, cols);

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                subMatrix.AtRef(i, j) = mat.At(rowRange.Start.Value + i, colRange.Start.Value + j);
            }
        }

        return subMatrix;
    }
}