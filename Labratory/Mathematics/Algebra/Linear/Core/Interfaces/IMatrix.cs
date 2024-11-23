namespace Labratory.Mathematics.Algebra.Linear.Core.Interfaces;

public interface IMatrix<TData>
{
    int Rows { get; }
    int Cols { get; }

    ref TData AtRef(int i, int j);
    TData At(int i, int j);
}