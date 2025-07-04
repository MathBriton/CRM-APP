namespace CrmApp.Domain.ValueObjects
{
    public class Nome : ValueObject
    {
        public string Texto { get; private set; }

        public Nome(string texto)
        {
            if (string.IsNullOrWhiteSpace(texto))
                throw new DomainException("Nome não pode ser vazio.");

            if (texto.Length < 2)
                throw new DomainException("Nome deve ter pelo menos 2 caracteres.");

            Texto = texto.Trim();
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Texto.ToLower(); // Comparação insensível a maiúsculas/minúsculas
        }

        public override string ToString() => Texto;
    }
}
