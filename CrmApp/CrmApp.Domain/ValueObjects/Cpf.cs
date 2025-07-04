namespace CrmApp.Domain.ValueObjects
{
    public class Cpf : ValueObject
    {
        public string Numero { get; private set; }

        public Cpf(string numero)
        {
            if (string.IsNullOrWhiteSpace(numero))
                throw new DomainException("CPF não pode ser vazio.");

            // Remove pontos e traços
            numero = new string(numero.Where(char.IsDigit).ToArray());

            if (numero.Length != 11)
                throw new DomainException("CPF deve conter 11 dígitos numéricos.");

            Numero = numero;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Numero;
        }

        public override string ToString() => Numero;
    }
}
