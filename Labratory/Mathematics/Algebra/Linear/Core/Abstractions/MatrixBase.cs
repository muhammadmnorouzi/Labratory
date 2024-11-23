using Labratory.Exceptions;
using Labratory.Mathematics.Algebra.Linear.Core.Interfaces;

namespace Labratory.Mathematics.Algebra.Linear.Core.Abstractions;

public abstract class MatrixBase<TData> : IMatrix<TData>
{
    public int Rows { get; }
    public int Cols { get; }
    protected TData[,] Mat { get; }

    public MatrixBase(int rows, int cols)
    {
        LaboratoryException.ThrowIfNot(
            condition:rows > 0 && cols > 0,
            message: $"Creating new instance inheriting {nameof(MatrixBase<TData>)} with non-positive {nameof(rows)} and {nameof(cols)} is not allowed",
            exceptionType: LaboratoryExceptionType.InvalidArgument);

        Rows = rows;
        Cols = cols;

        Mat = new TData[Rows, Cols];
    }

    public abstract TData At(int i, int j);
    public abstract ref TData AtRef(int i, int j);
    public abstract MatrixBase<TData> New(int rows, int cols);
}