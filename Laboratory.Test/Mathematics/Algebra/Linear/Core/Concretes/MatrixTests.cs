using Labratory.Exceptions;
using Labratory.Mathematics.Algebra.Linear.Core.Concretes;
using Shouldly;

namespace Laboratory.Test.Mathematics.Algebra.Linear.Core.Concretes;

public partial class MatrixTests
{
    [Theory]
    [InlineData(1, 1)]
    [InlineData(10, 10)]
    [InlineData(5, 10)]
    [InlineData(10, 5)]
    [InlineData(11, 1)]
    [InlineData(1, 11)]
    public void ShloudCreateNewMatrix_WithPositiveRowsAndColsNumber(int rows, int cols)
    {
        Matrix matrix = new(rows, cols);
        matrix.Rows.ShouldBe(rows);
        matrix.Cols.ShouldBe(cols);
    }

    [Theory]
    [InlineData(-1, 1)]
    [InlineData(10, -10)]
    [InlineData(10, 0)]
    [InlineData(0, 10)]
    [InlineData(0, 0)]
    [InlineData(-1, -11)]
    public void ShloudThrowException_WhenCreatingNewMatrix_WithNonPositiveGivenRowsAndColsNumber(int rows, int cols)
    {
        Assert.Throws<LaboratoryException>(() => new Matrix(rows, cols));
    }

    [Fact]
    public void ShloudReturnCorrectShapeOfMatrix()
    {
        Matrix matrix = new(10, 15);
        matrix.Shape().ShouldBe((10, 15));
    }

    [Fact]
    public void ShloudReturElementRefAt()
    {
        Matrix matrix = new(10, 15);
        matrix.At(5, 5).ShouldBe(0);
        matrix.AtRef(5, 5) = 10;
        matrix.At(5, 5).ShouldBe(10);
    }
    
    [Fact]
    public void ShouldReturnTrue()
    {
        Matrix matrix = new(10, 15);
        matrix.At(5, 5).ShouldBe(0);
        matrix.AtRef(5, 5) = 10;
        matrix.At(5, 5).ShouldBe(10);
    }
}