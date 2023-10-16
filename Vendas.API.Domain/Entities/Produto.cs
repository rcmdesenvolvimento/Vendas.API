using Vendas.API.Domain.Validation;

namespace Vendas.API.Domain.Entities;

public sealed class Produto
{
    public int Id { get; private set; }
    public string? Nome { get; private set; }
    public string? CodErp { get; set; }
    public decimal Preco { get; private set; }
    public ICollection<Compra> Compras { get; set; }

    public Produto(string nome, string codErp, decimal preco)
    {
        Validation(nome, codErp, preco);
    }

    //Edição do registro
    public Produto(int id, string nome, string codErp, decimal preco)
    {
        DomainValidationException.When(id < 0, "O Id deve ser maior que zero");

        Id = id;

        Validation(nome, codErp, preco);
    }

    private void Validation(string nome, string codErp, decimal preco)
    {
        DomainValidationException.When(string.IsNullOrEmpty(nome), "O Nome deve ser informado!");
        DomainValidationException.When(string.IsNullOrEmpty(codErp), "O CodErp deve ser informado!");
        DomainValidationException.When(preco < 0, "O Preço do produto deve ser informado!");

        Nome = nome;
        CodErp = codErp;
        Preco = preco;
    }
}
