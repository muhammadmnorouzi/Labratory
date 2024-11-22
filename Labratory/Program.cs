using Labratory.Mathematics.Algebra.Linear.Algorithms;
using Labratory.Mathematics.Algebra.Linear.Core.Concretes;

namespace Labratory;

public class Program
{
    public static void Main(params string[] args)
    {
        Matrix mat = new(5, 5);
        mat.Eye(2);

        mat.Print(Console.Out);
        Matrix neg = mat.Negate();
        neg.Print(Console.Out);
    }
}