using Labratory.Exceptions;
using Labratory.Mathematics.Algebra.Linear.Algorithms;
using Labratory.Mathematics.Algebra.Linear.Core.Concretes;
using Shouldly;

namespace Laboratory.Test.Mathematics.Algebra.Linear.Core.Concretes;

public partial class MatrixTests
{
    private readonly List<double[,]> _matrices = [
        new double[,] {
            {4, 2, 3, 3},
            {2, 3, 2, 2},
            {-2, 0, 2, 2},
            {0, 0, 0, 2}},
        new double[,] {
            {1 ,0 , 0 , 0},
            {0 ,1 , 0 , 0},
            {0 ,0 , 1 , 0},
            {0 ,0 , 0 , 1}}
    ];

    private readonly List<double[,]> _matricesRowReduced = [
        new double[,] {
            {1 ,0 , 0 , 0},
            {0 ,1 , 0 , 0},
            {0 ,0 , 1 , 0},
            {0 ,0 , 0 , 1}}
    ];

    [Theory]
    [InlineData(0, 0)]
    [InlineData(1, 0)]
    public void TransferToRowReduced_ShouldReturnCorrectlyRowReducedMatrix(int matIndex, int rowReducedMatIndex)
    {
        Matrix mat = new(_matrices[matIndex]);
        mat.TransferToRowReduced();

        mat.Equals(new Matrix(_matricesRowReduced[rowReducedMatIndex]))
           .ShouldBeTrue();
    }
}
