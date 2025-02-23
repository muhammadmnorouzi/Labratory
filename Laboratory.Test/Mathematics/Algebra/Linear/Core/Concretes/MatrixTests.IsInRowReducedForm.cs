using Labratory.Mathematics.Algebra.Linear.Algorithms;
using Labratory.Mathematics.Algebra.Linear.Core.Concretes;
using Shouldly;

namespace Laboratory.Test.Mathematics.Algebra.Linear.Core.Concretes;

public partial class MatrixTests
{
    private readonly List<double[,]> _notRowReducedMatrices = [
        new double[4, 5] {
            {1, 1, -2, 4, 7},
            {0, 0, -6, 5, 7},
            {0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0}},
        new double[3,3] {
            {1, 2, 3},
            {0, 0, 0},
            {0, 0, 1}},
        new double[3, 4] {
            {1, 2, 3, 4},
            {0, 0, 1, 2},
            {0, 1, 0, 5}},
        new double[3, 4] {
            {1, -2, 3, 3},
            {0, 0, 1, -3},
            {0, 0, 1, 0}},
    ];

    private readonly List<double[,]> _rowReducedMatrices = [
        new double[4, 5] {
            {1, 1, -2, 4, 7},
            {0, 0, 1, 5, 7},
            {0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0}},
        new double[3,3] {
            {1, 2, 3},
            {0, 0, 1},
            {0, 0, 0}},
        new double[3, 4] {
            {1, 2, 3, 4},
            {0, 1, 0, 5},
            {0, 0, 1, 2}},
        new double[3, 4] {
            {1, -2, 3, 3},
            {0, 1, 1, -3},
            {0, 0, 1, 0}},
    ];

    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    public void IsInRowReducedForm_ShouldReturnTrue_ForRowReducedMatrices(int rowReducedMatrixIndex)
    {
        Matrix mat = new(_rowReducedMatrices[rowReducedMatrixIndex]);
        mat.IsInRowReducedForm().ShouldBeTrue();
    }

    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    public void IsInRowReducedForm_ShouldReturnFalse_ForNotRowReducedMatrices(int notRowReducedMatrixIndex)
    {
        Matrix mat = new(_notRowReducedMatrices[notRowReducedMatrixIndex]);
        mat.IsInRowReducedForm().ShouldBeFalse();
    }
}

