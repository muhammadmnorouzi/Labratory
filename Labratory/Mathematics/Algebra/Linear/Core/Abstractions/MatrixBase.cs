using Labratory.Exceptions;
using Labratory.Extensions;
using Labratory.Mathematics.Algebra.Linear.Algorithms;
using Labratory.Mathematics.Algebra.Linear.Core.Interfaces;

namespace Labratory.Mathematics.Algebra.Linear.Core.Abstractions;

public abstract class MatrixBase<TData> : IMatrix<TData>
where TData : notnull
{
    public int Rows { get; }
    public int Cols { get; }
    protected TData[,] Mat { get; }

    public MatrixBase(int rows, int cols)
    {
        LaboratoryException.ThrowIfNot(
            condition: rows > 0 && cols > 0,
            message: $"Creating new instance inheriting {nameof(MatrixBase<TData>)} with non-positive {nameof(rows)} and {nameof(cols)} is not allowed",
            exceptionType: LaboratoryExceptionType.InvalidArgument);

        Rows = rows;
        Cols = cols;

        Mat = new TData[Rows, Cols];
    }

    public MatrixBase(TData[,] mat)
    {
        Rows = mat.GetLength(0);
        Cols = mat.GetLength(1);

        Mat = mat;
    }

    public abstract TData At(int i, int j);
    public abstract ref TData AtRef(int i, int j);
    public abstract MatrixBase<TData> New(int rows, int cols);
    public abstract bool IsDefault(TData value);
    public abstract bool ElementsEqual(TData left, TData right);
    public abstract TData Default();

    public override bool Equals(object? obj)
    {
        if (obj is MatrixBase<TData> matrix)
        {
            if (matrix.Rows == Rows && matrix.Cols == Cols)
            {
                return this.Generate<MatrixBase<TData>, TData, bool>((i, j) => At(i, j).Equals(matrix.At(i, j))).All(x => x);
            }
        }

        return false;
    }

    public override int GetHashCode()
    {
        unchecked
        {
            const int prime = 101;
            int hash = 31;

            hash = hash * prime + Rows;
            hash = hash * prime + Cols;

            foreach (TData value in Mat)

            {
                hash = hash * prime + value.GetHashCode();
            }

            return hash;
        }
    }

    public static bool operator ==(MatrixBase<TData> left, MatrixBase<TData> right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(MatrixBase<TData> left, MatrixBase<TData> right)
    {
        return left.Equals(right).Not();
    }

    public (int Rows, int Cols) Shape()
    {
        return (Rows, Cols);
    }
}