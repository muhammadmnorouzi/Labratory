using Labratory.Exceptions;
using Labratory.Mathematics.Algebra.Linear.Algorithms;
using Labratory.Mathematics.Algebra.Linear.Core.Concretes;
using Shouldly;

namespace Laboratory.Test.Mathematics.Algebra.Linear.Core.Concretes;

public partial class MatrixTests
{
    [Fact]
    public void IsDiagonal_ShouldReturnTrue_ForDiagonalMatrix()
    {
        Matrix matrix = new(10, 10);
        matrix.Eye();
        matrix.IsDiagonal<Matrix, double>().ShouldBeTrue();
    }

    [Fact]
    public void IsDiagonal_ShouldReturnTrue_ForDiagonalMatrix2()
    {
        Matrix matrix = new(5, 5);
        matrix.AtRef(0, 0) = 1;
        matrix.IsDiagonal<Matrix, double>().ShouldBeTrue();
    }

    [Fact]
    public void IsDiagonal_ShouldReturnFalse_ForNonDiagonalMatrix()
    {
        Matrix matrix = new(5, 5);
        matrix.Eye();
        matrix.AtRef(1, 0) = 1;
        matrix.IsDiagonal<Matrix, double>().ShouldBeFalse();
    }
}
