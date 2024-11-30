using Labratory.Mathematics.Algebra.Linear.Algorithms;
using Labratory.Mathematics.Algebra.Linear.Core.Concretes;

double[,] array_mat =
{{4, 2, 3, 3},
{2, 3, 2, 2},
{-2, 0, 2, 2},
{0, 0, 0, 2}};

Matrix mat = new(array_mat);

mat.TransferToRowReduced();