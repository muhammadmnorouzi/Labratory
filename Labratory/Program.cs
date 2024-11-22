using Labratory.Mathematics.Algebra.Linear.Core.Concretes;

namespace Labratory;

public class Program
{
    public static void Main(params string[] args)
    {
        Matrix mat = new(5, 5);
        mat.Eye(2);

        Matrix mat2 = new(5, 5);
        mat2.Fill(5);

        mat.Multiplicate(mat2).Print(Console.Out);
    }
}