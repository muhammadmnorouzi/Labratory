using Labratory.Extensions;
using Labratory.Mathematics.Algebra.Linear.Core.Abstractions;

namespace Labratory.Mathematics.Algebra.Linear.Core.Concretes;

public class Matrix : MatrixBase<double>
{
    public Matrix(int rows, int cols) : base(rows, cols) { }
    public Matrix(double[,] mat) : base(mat) { }

    public override ref double AtRef(int i, int j)
    {
        return ref Mat[i, j];
    }

    public override double At(int i, int j)
    {
        return Mat[i, j];
    }

    public override MatrixBase<double> New(int rows, int cols)
    {
        return new Matrix(rows, cols);
    }

    public override bool IsDefault(double value)
    {
        return ElementsEqual(value, Default());
    }

    public override double Default()
    {
        return default;
    }

    public override bool ElementsEqual(double left, double right)
    {

        return Math.Abs(left - right).IsZero();
    }
}