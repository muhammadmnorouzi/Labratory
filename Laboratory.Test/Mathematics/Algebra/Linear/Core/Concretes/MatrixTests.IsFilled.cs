using Labratory.Mathematics.Algebra.Linear.Algorithms;
using Labratory.Mathematics.Algebra.Linear.Core.Concretes;
using Shouldly;

namespace Laboratory.Test.Mathematics.Algebra.Linear.Core.Concretes;

public partial class MatrixTests
{
    [Theory]
    [InlineData(0)]
    [InlineData(0.5)]
    [InlineData(1)]
    [InlineData(10)]
    public void IsFilled_ShouldReturnTrue_ForFilledMatrix(double value)
    {
        Matrix matrix = new(Random.Shared.Next(1, 10), Random.Shared.Next(1, 10));
        matrix.Fill(value);
        matrix.IsFilled(value).ShouldBeTrue();
    }

    [Theory]
    [InlineData(0)]
    [InlineData(0.5)]
    [InlineData(1)]
    [InlineData(10)]
    public void IsFilled_ShouldReturnFalse_ForNotFilledMatrix(double value)
    {
        Matrix matrix = new(Random.Shared.Next(1, 10), Random.Shared.Next(1, 10));
        matrix.Randomize();
        matrix.IsFilled(value).ShouldBeFalse();
    }
}
