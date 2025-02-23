using Labratory.Extensions;
using Shouldly;

namespace Laboratory.Test.Generics;

public class ExtensionsTests
{
    [Fact]
    public void Permutate_ShouldReturnAllPossibleCombinations()
    {
        // Given
        int[] numbers = [1, 2, 3];
        int[][] expectedCombinations = [[1, 2, 3], [1, 3, 2], [2, 1, 3], [2, 3, 1], [3, 1, 2], [3, 2, 1]];

        foreach (IDictionary<int, int> combination in numbers.Permutations())
        {
            expectedCombinations.Any(permutation => permutation.SequenceEqual(combination.Values)).ShouldBe(true);
        }
    }
}