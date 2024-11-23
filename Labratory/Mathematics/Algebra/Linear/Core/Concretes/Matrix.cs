using Labratory.Mathematics.Algebra.Linear.Core.Abstractions;
using Labratory.Mathematics.Algebra.Linear.Core.Interfaces;

namespace Labratory.Mathematics.Algebra.Linear.Core.Concretes;

public class Matrix(int rows, int cols) : MatrixBase<double>(rows, cols)
{
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