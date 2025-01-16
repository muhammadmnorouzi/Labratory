using Labratory.Exceptions;
using Labratory.Mathematics.Algebra.Linear.Algorithms;
using Labratory.Mathematics.Algebra.Linear.Core.Concretes;
using Shouldly;

namespace Laboratory.Test.Mathematics.Algebra.Linear.Core.Concretes;

public partial class MatrixTests
{
    [Fact]
    public void Multiplicate_ShouldReturnTheSameMatrix_MultiplicatedInEye()
    {
        // Given
        Matrix matrix = new Matrix(10, 10).Randomize();
        Matrix eye = new Matrix(10, 10).Eye();
        Matrix expected = matrix.Copy<Matrix, double>();

        // When
        Matrix resultMatEye = matrix.Multiplicate(eye);
        Matrix resultEyeMat = eye.Multiplicate(matrix);

        // Then
        resultMatEye.Equals(expected).ShouldBeTrue();
        resultEyeMat.Equals(expected).ShouldBeTrue();
    }

    [Fact]
    public void Multiplicate_ShouldReturnZero_MultiplicatedInZero()
    {
        // Given
        Matrix matrix = new Matrix(10, 10).Randomize();
        Matrix zero = new Matrix(10, 10).Fill(0D);
        Matrix expected = zero.Copy<Matrix, double>();

        // When
        Matrix resultMatZero = matrix.Multiplicate(zero);
        Matrix resultZeroMat = zero.Multiplicate(matrix);

        // Then
        resultMatZero.Equals(expected).ShouldBeTrue();
        resultZeroMat.Equals(expected).ShouldBeTrue();
    }

    [Fact]
    public void Multiplicate_ShouldReturnATimesB_MultiplicatedAinB()
    {
        // Given
        double a = Random.Shared.NextDouble();
        double b = Random.Shared.NextDouble();
        Matrix matA = new Matrix(1, 1).Fill(a);
        Matrix matB = new Matrix(1, 1).Fill(b);
        Matrix expected = new Matrix(1, 1).Fill(a * b);

        // When
        Matrix resultAB = matA.Multiplicate(matB);
        Matrix resultBA = matB.Multiplicate(matA);

        // Then
        resultAB.Equals(expected).ShouldBeTrue();
        resultBA.Equals(expected).ShouldBeTrue();
    }

    [Fact]
    public void Multiplicate_ShouldReturnResult_WithProperShape()
    {
        // Given
        int a = Random.Shared.Next(10, 50);
        int b = Random.Shared.Next(10, 50);
        int c = Random.Shared.Next(10, 50);
        Matrix left = new Matrix(a, b).Randomize();
        Matrix right = new Matrix(b, c).Randomize();
        (int, int) expectedShape = (a, c);

        // When
        Matrix result = left.Multiplicate(right);

        // Then
        result.Shape().Equals(expectedShape).ShouldBeTrue();
    }

    [Fact]
    public void Multiplicate_ShouldThrowException_ForIncompatibleShapes()
    {
        // Given
        int a = Random.Shared.Next(10, 50);
        int b = 10;
        int c = 11;
        int d = Random.Shared.Next(10, 50);
        Matrix left = new Matrix(a, b).Randomize();
        Matrix right = new Matrix(c, d).Randomize();

        // Then
        Should.Throw<LaboratoryException>(() => left.Multiplicate(right));
    }


    [Fact]
    public void Multiplicate_ShouldWorkCorrectly_ForLargeMatrices()
    {
        // TODO performance optimization
        // Given
        int a = Random.Shared.Next(100, 200);
        int b = Random.Shared.Next(100, 200);
        int c = Random.Shared.Next(100, 200);
        Matrix left = new Matrix(a, b).Randomize();
        Matrix right = new Matrix(b, c).Randomize();

        // Then
        Should.NotThrow(() => left.Multiplicate(right));
    }

    [Fact]
    public void Multiplicate_ShouldSatisfyAssociativity()
    {
        // Given
        Matrix mat1 = new Matrix(20, 25).Randomize();
        Matrix mat2 = new Matrix(25, 15).Randomize();
        Matrix mat3 = new Matrix(15, 20).Randomize();

        Matrix expected = mat1.Multiplicate(mat2).Multiplicate(mat3); ;

        // When
        Matrix result = mat1.Multiplicate(mat2.Multiplicate(mat3));

        // Then
        result.Equals(expected).ShouldBeTrue();
    }

    [Fact]
    public void Multiplicate_ShouldSatisfyDistributivity()
    {
        // Given
        Matrix mat1 = new Matrix(20, 25).Randomize();
        Matrix mat2 = new Matrix(25, 15).Randomize();
        Matrix mat3 = new Matrix(25, 15).Randomize();

        Matrix expected = mat1.Multiplicate(mat2.Copy<Matrix, double>().Add(mat3));

        // When
        Matrix result = mat1.Multiplicate(mat2).Add(mat1.Multiplicate(mat3));

        // Then
        result.Equals(expected).ShouldBeTrue();
    }

    [Fact]
    public void Multiplicate_ShouldSatisfyTranspose()
    {
        // Given
        int a = Random.Shared.Next(10, 20);
        int b = Random.Shared.Next(10, 20);
        Matrix mat1 = new Matrix(a, b).Randomize();
        Matrix mat2 = new Matrix(b, a).Randomize();

        Matrix expected = mat1.Multiplicate(mat2).Transpose<Matrix, double>();

        // When
        Matrix result = mat2.Transpose<Matrix, double>().Multiplicate(mat1.Transpose<Matrix, double>());

        // Then
        result.Equals(expected).ShouldBeTrue();
    }
}