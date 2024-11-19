using System.Diagnostics.CodeAnalysis;

namespace Labratory.Exceptions;

public sealed class LaboratoryException : Exception
{
    private readonly LaboratoryExceptionType _exceptionType;

    internal LaboratoryException(
        LaboratoryExceptionType exceptionType,
        string message) : base(message)
    {
        _exceptionType = exceptionType;
    }

    [DoesNotReturn]
    internal static void Throw(string message, LaboratoryExceptionType exceptionType = LaboratoryExceptionType.Internal)
    {
        throw new LaboratoryException(exceptionType, message);
    }
}

public enum LaboratoryExceptionType
{
    Internal
}