using Labratory.Exceptions;
using Labratory.Mathematics.Algebra.Linear.Algorithms;
using Labratory.Mathematics.Algebra.Linear.Core.Concretes;
using Shouldly;

namespace Laboratory.Test.Mathematics.Algebra.Linear.Core.Concretes;

public partial class MatrixTests
{
    [Fact]
    public void IsEye_ShouldReturnTrue_ForEyeMatrix()
    {
        Matrix matrix = new(10, 10);
        matrix.Eye();
        matrix.IsEye(value: 1.0D).ShouldBeTrue();
    }

    [Fact]
    public void IsEye_ShouldReturnFalse_ForNoneEyeMatrix()
    {
        Matrix matrix = new(10, 10);
        matrix.Randomize();
        matrix.IsEye(value: 1.0D).ShouldBeFalse();
    }

    [Fact]
    public void IsEye_ShouldReturnFalse_ForNonEyeMatrix2()
    {
        Matrix matrix = new(10, 10);
        matrix.Eye();
        matrix.AtRef(1, 5) = 1;
        matrix.IsEye(value: 1.0D).ShouldBeFalse();
    }

    [Theory]
    [InlineData(10, 5)]
    [InlineData(5, 10)]
    public void IsEye_ShouldThrowLaboratoryException_ForNonSquareMatrix(int rows, int cols)
    {
        Matrix matrix = new(rows, cols);
        Assert.Throws<LaboratoryException>(() => matrix.IsEye(value: 1.0D));
    }
}
