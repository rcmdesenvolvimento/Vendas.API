using Vendas.API.Domain.Validation;

namespace Vendas.API.Domain.Entities;

public sealed class Pessoa
{
    public int Id { get; private set; }
    public string? Nome { get; private set; }
    public string? Documento { get; private set; }
    public string? Telefone { get; private set; }
    public ICollection<Compra> Compras { get; set; }

    public Pessoa(string nome, string documento, string telefone)
    {
        Validation(nome, documento, telefone);
    }

    //Edição do registro
    public Pessoa(int id, string nome, string documento, string telefone)
    {
        DomainValidationException.When(id < 0, "O Id deve ser maior que zero");

        Id = id;

        Validation(nome, documento, telefone);
    }

    private void Validation(string nome, string documento, string telefone)
    {
        DomainValidationException.When(string.IsNullOrEmpty(nome), "O Nome deve ser informado!");
        DomainValidationException.When(string.IsNullOrEmpty(documento), "O Documento deve ser informado!");
        DomainValidationException.When(string.IsNullOrEmpty(telefone), "O Telefone deve ser informado!");

        Nome = nome;
        Documento = documento;
        Telefone = telefone;
    }

}
