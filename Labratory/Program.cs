using Labratory.Mathematics.Algebra.Linear.Algorithms;
using Labratory.Mathematics.Algebra.Linear.Core.Concretes;

namespace Labratory;

public class Program
{
    public static void Main(params string[] args)
    {
        Matrix mat = new(5, 5);
        mat.Randomize();

        mat.Print(Console.Out);
        System.Console.WriteLine(mat.IsSymetric<Matrix, double>());
    }
}