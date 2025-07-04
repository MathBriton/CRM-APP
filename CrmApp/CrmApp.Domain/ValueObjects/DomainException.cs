namespace CrmApp.Domain.ValueObjects
{
    public class DomainException : Exception
    {
        public DomainException(string message) : base(message) { }

    }
}
