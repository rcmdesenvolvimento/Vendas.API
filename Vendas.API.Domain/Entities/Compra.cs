using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vendas.API.Domain.Validation;

namespace Vendas.API.Domain.Entities
{
    public class Compra
    {
        public int Id { get; private set; }
        public int ProdutoId { get; private set; }
        public int PessoaId { get; private set; }
        public DateTime Data { get; private set; }
        public Pessoa Pessoa { get; set; }
        public Produto Produto { get; set; }

        public Compra(int produtoId, int pessoaId, DateTime? data)
        {
            Validation(produtoId, pessoaId, data);
        }

        public Compra(int id, int produtoId, int pessoaId, DateTime? data)
        {
            DomainValidationException.When(id < 0, "O Id deve ser informado!");
            this.Id = id;
            Validation(produtoId, pessoaId, data);
        }

        private void Validation(int produtoId, int pessoaId, DateTime? data)
        {
            DomainValidationException.When(produtoId < 0, "O Produto deve ser informado!");
            DomainValidationException.When(pessoaId < 0, "A Pessoa deve ser informado!");
            DomainValidationException.When(!data.HasValue, "A data da compra deve informada!");

            this.ProdutoId = produtoId;
            this.PessoaId = pessoaId;
            this.Data = data.Value;
        }

            
    }
}
