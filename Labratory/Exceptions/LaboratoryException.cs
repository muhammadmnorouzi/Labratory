using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using Labratory.Extensions;

namespace Labratory.Exceptions;

public sealed class LaboratoryException : Exception
{
    public LaboratoryExceptionType ExceptionType => _exceptionType;
    private readonly LaboratoryExceptionType _exceptionType;

    internal LaboratoryException(
        LaboratoryExceptionType exceptionType,
        string message) : base(message)
    {
        _exceptionType = exceptionType;
    }

    [DoesNotReturn]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static void ThrowIfNot(bool condition, string message, LaboratoryExceptionType exceptionType = LaboratoryExceptionType.Internal)
    {
        if (condition.Not())
        {
            throw new LaboratoryException(exceptionType, message);
        }
    }

    [DoesNotReturn]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ThrowIf(bool condition, string message, LaboratoryExceptionType exceptionType = LaboratoryExceptionType.Internal)
    {
         if (condition)
        {
            throw new LaboratoryException(exceptionType, message);
        }
    } 
}
