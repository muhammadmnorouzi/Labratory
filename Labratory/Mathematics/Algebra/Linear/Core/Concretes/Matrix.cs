using Labratory.Mathematics.Algebra.Linear.Core.Abstractions;

namespace Labratory.Mathematics.Algebra.Linear.Core.Concretes;

public class Matrix : MatrixBase<double>
{
    public Matrix(int rows, int cols) : base(rows, cols) { }
    public Matrix(double[,] mat) : base(mat) { }

    public override ref double AtRef(int i, int j)
    {
        return ref base.Mat[i, j];
    }

    public override double At(int i, int j)
    {
        return base.Mat[i, j];
    }

    public override MatrixBase<double> New(int rows, int cols)
    {
        throw new NotImplementedException();
    }
}