namespace Vendas.API.Domain.Validation;

public class DomainValidationException : Exception
{
    public DomainValidationException(string error) : base(error) { }

    public static void When(bool hasError, string message)
    {
        if (hasError) throw new DomainValidationException(message);
    }

    internal static void When(object value, string v)
    {
        throw new NotImplementedException();
    }
}
